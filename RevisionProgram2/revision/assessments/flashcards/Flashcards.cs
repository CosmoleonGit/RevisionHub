using RevisionProgram2.dialogs;
using RevisionProgram2.revision.assessments;
using RevisionProgram2.revision.assessments.flashcards;
using RevisionProgram2.revision.assessments.tests;
using RevisionProgram2.revision.tests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.flashcards
{
    public class Flashcards : Assess
    {
        internal const string flashcardsVersion = "1";

        public static void Create(string dir, Action onNameGet, Action<string, string> onFinish)
        {
            // Take name input for flashcards.
            TextInput.GetInput("Enter a name for your flashcards.", "Flashcards", name =>
            {
                onNameGet();

                if (name == "")
                {
                    onFinish("", dir);
                    return;
                }

                // Initialize and show flashcards editor.
                var editor = new FlashcardsEditor(name);

                editor.onFinish = () =>
                {
                    if (editor.DialogResult == DialogResult.OK)
                    {
                        if (editor.Save(dir + "/" + name))
                        {
                            if (editor.DialogResult == DialogResult.OK)
                                onFinish(name, dir);
                            else
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

        public static void Edit(string name, string dir, Action<string, string> uponCreation)
        {
            var flashcards = new Flashcards(name, dir);

            if (!flashcards.TryLoadCards())
            {
                return;
            }

            var editor = new FlashcardsEditor(name, flashcards.description, flashcards.cards);

            editor.onFinish = () =>
            {
                if (editor.Save(flashcards.path))
                {
                    uponCreation(name, dir);
                }
            };

            editor.Show();
        }

        public static void Duplicate(string from, string dir, Action onNameGet, Action<string, string> onFinish)
        {
            TextInput.GetInput("Enter a name for your flashcards.", "Flashcards", name =>
            {
                onNameGet();

                if (name == "")
                {
                    onFinish("", dir);
                    return;
                }

                var flashcards = new Flashcards(from, dir);

                if (!flashcards.TryLoadCards())
                {
                    return;
                }

                var editor = new FlashcardsEditor(from, flashcards.description, flashcards.cards);

                editor.onFinish = () =>
                {
                    if (editor.Save($"{dir}/{name}"))
                    {
                        onFinish(name, dir);
                    }
                };

                editor.Show();

            }, "", s =>
            {
                return TextInput.dirNameValid(s) && !Helper.Exists(dir + s);
            });
        }

        public Flashcards(string _name, string _dir) : base(_name, _dir) { }

        private Card[] cards;

        public bool TryLoadCards()
        {
            if (cards != null)
            {
                return true;
            }

            try
            {
                var cardList = new List<Card>();
                Queue<string> lineQueue = new Queue<string>();
                
                string[] lines = File.ReadAllLines(path);
                
                foreach (string line in Helper.SplitByLine(lines, char.MaxValue.ToString()))
                {
                    lineQueue.Enqueue(line);
                }

                //MsgBox.Show(lineQueue.Count.ToString());
                lineQueue.Dequeue();

                while(lineQueue.Count > 0)
                {
                    string side1 = lineQueue.Dequeue();
                    if (lineQueue.Count == 0) throw new Exception("Incorrect file formatting.");
                    string side2 = lineQueue.Dequeue();

                    cardList.Add(new Card(side1, side2));
                }

                cards = cardList.ToArray();

                return true;
            } catch(Exception ex)
            {
                Helper.Error("Failed to open flashcards.", ex.Message);
                return false;
            }
        }

        protected override void Begin(Action onFinish = null)
        {
            if (!TryLoadCards())
            {
                return;
            }

            settings?.SaveSettings();

            Organize(ref cards);

            StartFlashcards(name, cards, onFinish);
        }

        internal static void StartFlashcards(string name, IEnumerable<Card> cards, Action onFinish = null)
        {
            var tester = new FlashcardTester(name, cards)
            {
                onFinish = () =>
                {
                    onFinish?.Invoke();
                }
            };

            tester.Show();
        }

        FlashcardsSettings settings;

        void Organize(ref Card[] cards)
        {
            switch (Properties.Settings.Default.flashcardSort)
            {
                case 1:
                    Array.Reverse(cards);
                    break;
                case 2:
                    Helper.ShuffleArray(ref cards);
                    break;
            }

            switch (Properties.Settings.Default.flashcardFlip)
            {
                case 1:
                    for (int i = 0; i < cards.Length; i++)
                    {
                        cards[i].Swap();
                    }

                    break;
                case 2:
                    for (int i = 0; i < cards.Length; i++)
                    {
                        if (Helper.random.Next(2) == 0) cards[i].Swap();
                    }

                    break;
            }
        }

        public override void CreateSettingsPanel(Panel panel)
        {
            panel.Controls.Clear();

            if (settings == null)
            {
                settings = new FlashcardsSettings(this);
            }

            panel.Controls.Add(settings);

            panel.Width = panel.PreferredSize.Width;
        }

        public void AsTest()
        {
            settings?.SaveSettings();

            if (TryLoadCards())
            {
                Organize(ref cards);

                var questions = cards.Select(x => new Question(x.side1, new string[] { x.side2 }, -1));

                Test.StartTest(name, questions, Properties.Settings.Default.testSkippable);
            }
        }

        static SaveFileDialog saveDialog;

        public void SaveAsCSV()
        {
            if (TryLoadCards())
            {
                if (saveDialog == null)
                {
                    saveDialog = new SaveFileDialog()
                    {
                        FileName = name,
                        Filter = "CSV Files | *.csv",
                        DefaultExt = "csv"
                    };
                }

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(saveDialog.FileName);

                    using (var writer = new StreamWriter(saveDialog.FileName))
                    {
                        for (int i = 0; i < cards.Length; i++)
                        {
                            writer.Write(cards[i].side1.Replace(",", "").Replace(";", "").Replace("/n", " ") + ",");
                            writer.Write(cards[i].side2.Replace(",", "").Replace(";", "").Replace("/n", " "));

                            if (i != cards.Length - 1) writer.Write(Environment.NewLine);
                        }
                    }

                    Process.Start(Path.GetDirectoryName(saveDialog.FileName));
                }
            }
        }

        
    }
}
