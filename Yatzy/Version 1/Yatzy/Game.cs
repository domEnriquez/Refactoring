using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    public class Game
    {
        protected int[] dice;

        public Game()
        {
            dice = new int[5];
        }

        public Category Category { get; set; }

        public int GetScore()
        {
            return Category.GetScore(dice);
        }

        public void RollDiceNo(int diceNo, int rollResult)
        {
            dice[diceNo] = rollResult;
        }
    }
}
