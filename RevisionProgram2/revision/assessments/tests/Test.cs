using RevisionProgram2.dialogs;
using RevisionProgram2.revision.assessments;
using RevisionProgram2.revision.assessments.flashcards;
using RevisionProgram2.revision.assessments.tests;
using RevisionProgram2.revision.flashcards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RevisionProgram2.revision.assessments.tests.TestTester;

namespace RevisionProgram2.revision.tests
{
    public class Test : Assess
    {
        public const string testVersion = "1";
        public Test(string _name, string _dir) : base(_name, _dir) { }

        public static void Create(string dir, Action onNameGet, Action<string, string> onFinish)
        {
            // Asks for the name of the test.
            TextInput.GetInput("Enter a name for your test.", "Test", name =>
            {
                onNameGet();

                // Cancels if they didn't input anything.
                if (name == "")
                {
                    onFinish("", dir);
                    return;
                }

                var editor = new TestEditor(name);

                /*
                 * If the test is discarded or it fails to save,
                 * it calls the onFinish delegate but without
                 * a returned name.
                 */

                editor.onFinish = () =>
                {
                    if (editor.DialogResult == DialogResult.OK)
                    {
                        if (editor.Save(dir + "/" + name))
                        {
                            onFinish(name, dir);
                        }
                        else
                        {
                            onFinish("", dir);
                        }
                    }
                    else
                    {
                        onFinish("", dir);
                    }
                };

                editor.Show();
            }, "", s =>
            {
                return TextInput.dirNameValid(s) && !Helper.Exists(dir + s);
            });

            
        }

        private Question[] questions;

        public bool TryLoadQuestions()
        {
            if (questions != null)
            {
                return true;
            }

            try
            {
                
                var qList = new List<Question>();
                Queue<string> lineQueue = new Queue<string>();

                string[] lines = File.ReadAllLines(path);

                foreach (string line in Helper.SplitByLine(lines, char.MaxValue.ToString()))
                {
                    lineQueue.Enqueue(line);
                }

                lineQueue.Dequeue();

                if (lineQueue.Count == 0) throw new Exception("This test contains no questions.");

                while (lineQueue.Count > 0)
                {
                    string question = lineQueue.Dequeue();
                    if (lineQueue.Count == 0) throw new Exception("Incorrect formatting. (Question)");

                    if (!int.TryParse(lineQueue.Dequeue(), out int r))
                    {
                        throw new Exception("Failed to parse int. (Multiple Choice Check)");
                    }

                    List<string> answers = new List<string>();

                    foreach (string s in Helper.SplitIntoLines(lineQueue.Dequeue()))
                    {
                        answers.Add(s);
                    }

                    qList.Add(new Question(question, answers.ToArray(), r));
                }

                questions = qList.ToArray();

                return true;
            }
            catch (Exception ex)
            {
                Helper.Error("Failed to open test.", $"Reason: {ex.Message}");
                return false;
            }
        }

        protected override void Begin(Action onFinish = null)
        {
            if (!TryLoadQuestions())
            {
                Helper.Error("Error loading questions.", "Reason: Incorrect formatting.");
                return;
            }

            bool shuffle = false;

            settings?.SaveSettings();

            switch (Properties.Settings.Default.testSort)
            {
                case 1:
                    Array.Reverse(questions);
                    break;
                case 2:
                    shuffle = true;
                    Helper.ShuffleArray(ref questions);
                    break;
            }

            StartTest(name, questions, shuffle, onFinish);
        }

        internal static void StartTest(string name, Question[] questions, bool shuffle, Action onFinish = null)
        {
            var tester = new TestTester(name, questions, Properties.Settings.Default.testSkippable);

            Action testFinish = null;

            testFinish = () =>
            {
                if (tester.DialogResult == DialogResult.OK) // Finished test
                {
                    bool end = false;

                    var results = new ResultsForm(name, tester.questions);

                    results.FormClosing += (s, e) =>
                    {
                        var result = results.DialogResult;

                        if (result == DialogResult.Cancel || result == DialogResult.None)   // Clicked exit or X
                        {
                            end = true;
                        }
                        else if (result == DialogResult.OK) // Clicked Try Again
                        {
                            // Reshuffle questions

                            if (shuffle) Helper.ShuffleArray(ref questions);
                            tester = new TestTester(name, questions, Properties.Settings.Default.testSkippable);
                            tester.onFinish = testFinish;
                        }
                        else   // Clicked Test Incorrect Answers
                        {
                            var questionList = new List<Question>();

                            foreach (AskingQuestion q in results.questions)
                            {
                                if (!q.Correct) questionList.Add(q.question);
                            }

                            var qArr = questionList.ToArray();
                            if (shuffle) Helper.ShuffleArray(ref qArr);

                            tester = new TestTester(name, qArr, Properties.Settings.Default.testSkippable);
                            tester.onFinish = testFinish;
                        }

                        if (!end)
                        {
                            tester.Show();
                        }
                        else
                        {
                            onFinish?.Invoke();
                        }
                    };

                    results.Show();
                }
                else
                {
                    onFinish?.Invoke();
                }
            };

            tester.onFinish = testFinish;

            tester.Show();
        }

        TestSettings settings;

        public override void CreateSettingsPanel(Panel panel)
        {
            panel.Controls.Clear();

            if (settings == null)
            {
                settings = new TestSettings(this);

                panel.Controls.Add(settings);
            }

            panel.Width = panel.PreferredSize.Width;
        }

        public void AsFlashcards()
        {
            if (TryLoadQuestions())
            {
                var cards = new List<Card>();

                foreach (Question q in questions)
                {
                    Card card = q.AsCard();

                    if (Properties.Settings.Default.testSort == (int)SortType.REVERSE)
                        card.Swap();

                    cards.Add(card);
                }

                if (Properties.Settings.Default.testSort == (int)SortType.REVERSE)
                    cards.Shuffle();

                Flashcards.StartFlashcards(name, cards.ToArray());
            }
        }

        static SaveFileDialog saveDialog;

        public void SaveAsCSV()
        {
            if (TryLoadQuestions())
            {
                if (saveDialog == null)
                {
                    saveDialog = new SaveFileDialog()
                    {
                        Filter = "CSV Files | *.csv",
                        DefaultExt = "csv"
                    };
                }

                saveDialog.FileName = name;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(saveDialog.FileName);

                    using (var writer = new StreamWriter(saveDialog.FileName))
                    {
                        for (int i = 0; i < questions.Length; i++)
                        {
                            writer.Write(questions[i].question.Replace(",", "").Replace(";", "").Replace("/n", " ") + ",");
                            writer.Write(questions[i].GetFullAnswer().Replace(",", "").Replace(";", "").Replace("/n", " "));

                            if (i != questions.Length - 1) writer.Write(Environment.NewLine);
                        }
                    }

                    Process.Start(Path.GetDirectoryName(saveDialog.FileName));
                }
            }
        }

        public static void Edit(string name, string dir, Action<string, string> onFinish)
        {
            var test = new Test(name, dir);

            if (!test.TryLoadQuestions())
            {
                return;
            }

            var editor = new TestEditor(name, test.description, test.questions);

            editor.onFinish = () =>
            {
                editor.Save(dir + "/" + name);

                onFinish(name, dir);
            };

            editor.Show();
        }

        public static void Duplicate(string from, string dir, Action onNameGet, Action<string, string> onFinish)
        {
            TextInput.GetInput("Enter a name for your test.", "Test", name =>
            {
                onNameGet();

                // Cancels if they didn't input anything.
                if (name == "")
                {
                    onFinish("", dir);
                    return;
                }

                var test = new Test(from, dir);

                if (!test.TryLoadQuestions())
                {
                    return;
                }

                var editor = new TestEditor(name, test.description, test.questions);

                editor.onFinish = () =>
                {
                    editor.Save(dir + "/" + name);

                    onFinish(name, dir);
                };

                editor.Show();
            }, "", s =>
            {
                return TextInput.dirNameValid(s) && !Helper.Exists(dir + s);
            });

            
        }
    }
}
