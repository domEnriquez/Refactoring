using Yatzy;

namespace YatzyCategory
{
    public abstract class Straight : Category
    {
        public abstract int StraightStartPoint();

        public override int GetScore(int[] dice)
        {
            if (straight(decreasingRollResultsCountOf(dice), StraightStartPoint()))
                return addAllRollsOf(dice);
            else
                return 0;
        }

        private bool straight(int[] countOf, int start)
        {
            for (int i = start, j = 0; j < 5; i++, j++)
                if (countOf[i] != 1)
                    return false;

            return true;
        }
    }
}
