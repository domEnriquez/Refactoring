using System.Collections.Generic;
using Yatzy;

namespace YatzyCategory
{
    public class TwoPair : Category
    {
        public override int GetScore(int[] dice)
        {
            List<int> twoPair = getTwoPairs(decreasingRollResultsCountOf(dice));

            if (twoPair.Count >= 2)
                return twoPair[0] * 2 + twoPair[1] * 2;
            else
                return 0;
        }

        private List<int> getTwoPairs(int[] countOf)
        {
            List<int> targetNums = new List<int>();

            for (int i = countOf.Length - 1; i >= 0; i--)
                if (countOf[i] >= 2)
                    targetNums.Add(i + 1);

            return targetNums;
        }
    }
}
