using Yatzy;

namespace YatzyCategory
{
    public class Chance : Category
    {
        public override int GetScore(int[] dice)
        {
            return addAllRollsOf(dice);
        }
    }
}
