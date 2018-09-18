namespace Yatzy
{
    public abstract class Category
    {
        public abstract int GetScore(int[] dice);

        protected int[] decreasingRollResultsCountOf(int[] dice)
        {
            int[] countOf = new int[6];

            for (int i = 0; i < dice.Length; i++)
                countOf[dice[i] - 1]++;

            return countOf;
        }

        protected int addAllRollsOf(int[] dice)
        {
            int total = 0;

            for (int i = 0; i < dice.Length; i++)
                total += dice[i];

            return total;
        }
    }
}
