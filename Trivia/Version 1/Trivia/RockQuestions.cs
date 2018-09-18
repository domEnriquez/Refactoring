using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class RockQuestions : Questions
    {
        public override void AddItem(int indexLabel)
        {
            items.AddLast("Rock Question " + indexLabel);
        }

        public override bool CurrentCategory(int playerPos)
        {
            if (playerPos == 3 || playerPos == 7 || playerPos == 11)
                return true;
            else
                return false;
        }

        public override string GetName()
        {
            return "Rock";
        }
    }
}
