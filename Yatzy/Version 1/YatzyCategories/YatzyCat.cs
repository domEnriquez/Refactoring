using Yatzy;

namespace YatzyCategory
{
    public class YatzyCat : Category
    {
        public override int GetScore(int[] dice)
        {
            for (int i = 0; i < dice.Length - 1; i++)
                if (dice[i] != dice[i + 1])
                    return 0;

            return 50;
        }
    }
}
