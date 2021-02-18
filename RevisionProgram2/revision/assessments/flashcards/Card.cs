using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.revision.assessments.flashcards
{
    public struct Card
    {
        public Card(string s1, string s2)
        {
            side1 = s1; side2 = s2;
        }
        public string side1, side2;

        private const string defSide1 = "Side 1";
        private const string defSide2 = "Side 2";

        public string GetSide(bool right)
        {
            if (right)
            {
                return side2;
            }
            else
            {
                return side1;
            }
        }

        public void SetSide(bool right, string value)
        {
            if (right)
            {
                side2 = value;
            } else
            {
                side1 = value;
            }
        }

        public static Card DefaultCard => new Card(defSide1, defSide2);
        public bool IsDefault =>
            side1 == defSide1 && side2 == defSide2;

        public void Swap()
        {
            string s = side1;
            side1 = side2;
            side2 = s;
        }
    }
}
