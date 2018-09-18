using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class SportsQuestions : Questions
    {
        public override void AddItem(int indexLabel)
        {
            items.AddLast("Sports Question " + indexLabel);
        }

        public override bool CurrentCategory(int playerPos)
        {
            if (playerPos == 2 || playerPos == 6 || playerPos == 10)
                return true;
            else
                return false;
        }

        public override string GetName()
        {
            return "Sports";
        }
    }
}
