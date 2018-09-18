using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class GameUI
    {
        public void ShowAddedPlayerDetails(string pName, int pNum)
        {
            Console.WriteLine(pName + " was added");
            Console.WriteLine("They are player number " + pNum);
        }

        public void ShowPlayerToRoll(string pName)
        {
            Console.WriteLine(pName + " is the current player");
        }

        public void ShowRollAction(int roll)
        {
            Console.WriteLine("They have rolled a " + roll);
        }

        public void ShowGettingOutOfPenaltyMessage(string pName)
        {
            Console.WriteLine(pName + " is getting out of the penalty box");
        }

        public void ShowPlayerUpdatedLocation(string pName, int position)
        {
            Console.WriteLine(pName + "'s new location is " + position);
        }

        public void ShowQuestionCategory(string category, string questionItem)
        {
            Console.WriteLine("The category is " + category);
            Console.WriteLine(questionItem);
        }

        public void ShowNotGettingOutOfPenaltyMessage(string pName)
        {
            Console.WriteLine(pName + " is not getting out of the penalty box");
        }

        public void ShowAnswerIsCorrect()
        {
            Console.WriteLine("Answer was correct!!!!");
        }

        public void ShowPlayerCoinsValue(string pName, int pPoints)
        {
            Console.WriteLine(pName
                    + " now has "
                    + pPoints
                    + " Gold Coins.");
        }

        public void ShowAnswerIsWrong()
        {
            Console.WriteLine("Question was incorrectly answered");
        }

        public void ShowPlayerIsPutInPenaltyBox(string pName)
        {
            Console.WriteLine(pName + " was sent to the penalty box");
        }
    }
}
