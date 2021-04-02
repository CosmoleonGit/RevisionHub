using System;
using System.Linq;

namespace RevisionProgram2.revision.assessments.tests
{
    public struct AskingQuestion
    {
        public AskingQuestion(Question _question)
        {
            question = _question;
            guess = null;
            Correct = false;
        }

        public readonly Question question;

        string guess;
        public string Guess => guess == "" ? "(Skipped)" : guess;
        public bool Correct { get; private set; }

        public bool Attempt(string _guess)
        {
            guess = _guess.Trim();

            if (question.multipleChoice == -1)
            {
                foreach (string a in question.answers)
                {
                    if (guess.ToLower().Contains(a.ToLower()))
                    {
                        Correct = true;
                        return true;
                    }
                }

                return false;
            } else
            {
                string correctAnswer = question.answers[question.multipleChoice];

                if (guess == correctAnswer)
                {
                    Correct = true;
                    return true;
                } else { return false; }
            }
        }

        public string AnswerList()
        {
            if (question.multipleChoice != -1)
                return $"Correct Answer:\n\n{question.answers[question.multipleChoice]}";

            string s = "Correct answer" + ((question.answers.Length > 1) ? "s" : "") + ":" + Environment.NewLine;

            foreach (string a in question.answers)
            {
                s += Environment.NewLine + a;
            }

            return s;
        }
    }
}
