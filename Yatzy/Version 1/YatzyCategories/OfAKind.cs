using Yatzy;

namespace YatzyCategory
{
    public class OfAKind : Category
    {
        private int num;

        public OfAKind(int num)
        {
            this.num = num;
        }

        public override int GetScore(int[] dice)
        {
            return largestNumOccurringGreaterOrEqualTo(num, decreasingRollResultsCountOf(dice)) * num;
        }

        private int largestNumOccurringGreaterOrEqualTo(int reqOccur, int[] countOf)
        {
            for (int i = countOf.Length - 1; i >= 0; i--)
                if (countOf[i] >= reqOccur)
                    return i + 1;

            return 0;
        }
    }
}
