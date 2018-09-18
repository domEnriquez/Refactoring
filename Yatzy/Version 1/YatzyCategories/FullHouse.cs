using Yatzy;

namespace YatzyCategory
{
    public class FullHouse : Category
    {
        public override int GetScore(int[] dice)
        {
            int[] rollsTally = decreasingRollResultsCountOf(dice);

            int twice = largestNumOccurringEqualTo(2, rollsTally);
            int thrice = largestNumOccurringEqualTo(3, rollsTally);

            if (twice > 0 && thrice > 0)
                return twice * 2 + thrice * 3;
            else
                return 0;
        }

        private int largestNumOccurringEqualTo(int reqOccur, int[] countOf)
        {
            for (int i = countOf.Length - 1; i >= 0; i--)
                if (countOf[i] == reqOccur)
                    return i + 1;

            return 0;
        }
    }
}
