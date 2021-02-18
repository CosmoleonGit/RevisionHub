using RevisionProgram2.revision.assessments.flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.revision.assessments.tests
{
    public class Question
    {
        public Question(string _question, string[] _answers, int _multipleChoice)
        {
            question = _question;
            answers = _answers;
            multipleChoice = _multipleChoice;
        }

        public string question;
        public string[] answers;
        public int multipleChoice;

        public string GetFullAnswer()
        {
            if (multipleChoice != -1)
            {
                return answers[multipleChoice];
            }
            else
            {
                string ans = "";
                foreach (string a in answers)
                {
                    if (ans != "") ans += " / ";
                    ans += a;
                }

                return ans;
            }
        }

        public Card AsCard()
        {
            return new Card(question, GetFullAnswer());
        }
    }
}
