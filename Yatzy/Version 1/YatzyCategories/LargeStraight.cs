namespace YatzyCategory
{
    public class LargeStraight : Straight
    {
        private const int START_AT_2 = 1;

        public override int StraightStartPoint()
        {
            return START_AT_2;
        }
    }
}
