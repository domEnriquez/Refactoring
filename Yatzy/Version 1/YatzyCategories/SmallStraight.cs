namespace YatzyCategory
{
    public class SmallStraight : Straight
    {
        private const int START_AT_1 = 0;

        public override int StraightStartPoint()
        {
            return START_AT_1;
        }
    }
}
