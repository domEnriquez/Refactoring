using Yatzy;

namespace YatzyCategory
{
    public class AddAllInstancesOf : Category
    {
        private int numToAdd;

        public AddAllInstancesOf(int numToAdd)
        {
            this.numToAdd = numToAdd;
        }

        public override int GetScore(int[] dice)
        {
            return addAll(numToAdd, dice);
        }

        private int addAll(int num, int[] dice)
        {
            int sum = 0;

            for (int i = 0; i < dice.Length; i++)
                if (dice[i] == num)
                    sum += num;

            return sum;
        }
    }
}
