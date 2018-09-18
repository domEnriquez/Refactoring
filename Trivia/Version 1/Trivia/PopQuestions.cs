using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class PopQuestions : Questions
    {
        public override void AddItem(int indexLabel)
        {
            items.AddLast("Pop Question " + indexLabel);
        }

        public override bool CurrentCategory(int playerPos)
        {
            if (playerPos == 0 || playerPos == 4 || playerPos == 8)
                return true;
            else
                return false;
        }

        public override string GetName()
        {
            return "Pop";
        }
    }
}
