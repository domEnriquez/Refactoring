using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class ScienceQuestions : Questions
    {
        public override void AddItem(int indexLabel)
        {
            items.AddLast("Science Question " + indexLabel);
        }

        public override bool CurrentCategory(int playerPos)
        {
            if (playerPos == 1 || playerPos == 5 || playerPos == 9)
                return true;
            else
                return false;
        }

        public override string GetName()
        {
            return "Science";
        }
    }
}
