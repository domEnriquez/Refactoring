using NUnit.Framework;
using Yatzy;
using YatzyCategory;

namespace YatzyTest
{
 
    [TestFixture]
    public class YatzyTest
    {
        private void rollFive(params int[] rolls)
        {
            for (int i = 0; i < rolls.Length; i++)
                game.RollDiceNo(i, rolls[i]);
        }

        Game game; 

        [SetUp]
        public void givenANewGame()
        {
            game = new Game();
        }

        [Test]
        public void whenChanceCategory_thenAddAllDiceRolls()
        {
            game.Category = new Chance();

            rollFive(1, 1, 3, 3, 6);
            Assert.AreEqual(14, game.GetScore());

            rollFive(4, 5, 5, 6, 1);
            Assert.AreEqual(21, game.GetScore());
        }

        [Test]
        public void whenYatzyCategoryAndAllRollsAreSame_thenScoreIs50()
        {
            game.Category = new YatzyCat();

            rollFive(1, 1, 1, 1, 1);
            Assert.AreEqual(50, game.GetScore());;

            rollFive(2, 2, 2, 2, 2);
            Assert.AreEqual(50, game.GetScore());
        }

        [Test]
        public void whenYatzyCategoryAndRollsAreNotSame_thenScoreIsZero()
        {
            game.Category = new YatzyCat();

            rollFive(1, 1, 2, 1, 1);
            Assert.AreEqual(0, game.GetScore());

            rollFive(1, 3, 1, 1, 1);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenOnesCategory_thenAddAllOnesInRolls()
        {
            game.Category = new AddAllInstancesOf(1);

            rollFive(1, 1, 1, 1, 1);
            Assert.AreEqual(5, game.GetScore());

            rollFive(1, 2, 3, 1, 1);
            Assert.AreEqual(3, game.GetScore());

            rollFive(2, 3, 4, 4, 2);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenTwosCategory_thenAddAllTwosInRolls()
        {
            game.Category = new AddAllInstancesOf(2);

            rollFive(2, 2, 2, 2, 2);
            Assert.AreEqual(10, game.GetScore());

            rollFive(1, 2, 3, 4, 5);
            Assert.AreEqual(2, game.GetScore());

            rollFive(1, 3, 4, 5, 6);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenThreesCategory_thenAddAllThreesInRolls()
        {
            game.Category = new AddAllInstancesOf(3);

            rollFive(3, 3, 3, 3, 3);
            Assert.AreEqual(15, game.GetScore());

            rollFive(4, 3, 1, 2, 6);
            Assert.AreEqual(3, game.GetScore());

            rollFive(1, 2, 4, 5, 6);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenFoursCategory_thenAddAllFoursInRolls()
        {
            game.Category = new AddAllInstancesOf(4);

            rollFive(4, 4, 4, 4, 4);
            Assert.AreEqual(20, game.GetScore());

            rollFive(4, 1, 2, 3, 5);
            Assert.AreEqual(4, game.GetScore());

            rollFive(1, 3, 5, 6, 2);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenFivesCategory_thenAddAllFivesInRolls()
        {
            game.Category = new AddAllInstancesOf(5);

            rollFive(5, 5, 5, 5, 5);
            Assert.AreEqual(25, game.GetScore());

            rollFive(1, 5, 2, 3, 4);
            Assert.AreEqual(5, game.GetScore());

            rollFive(1, 4, 2, 6, 3);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenSixesCategory_thenAddAllSixesInRolls()
        {
            game.Category = new AddAllInstancesOf(6);

            rollFive(6, 6, 6, 6, 6);
            Assert.AreEqual(30, game.GetScore());

            rollFive(6, 1, 3, 2, 5);
            Assert.AreEqual(6, game.GetScore());

            rollFive(1, 2, 3, 4, 5);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenPairsCategory_thenAddTwoHighestMatchingRolls()
        {
            game.Category = new OfAKind(2);

            rollFive(3, 3, 3, 4, 4);
            Assert.AreEqual(8, game.GetScore());

            rollFive(1, 1, 6, 2, 6);
            Assert.AreEqual(12, game.GetScore());

            rollFive(3, 3, 3, 3, 1);
            Assert.AreEqual(6, game.GetScore());

            rollFive(1, 2, 3, 4, 5);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenTwoPairsCategory_thenAddTheTwoPairs()
        {
            game.Category = new TwoPair();

            rollFive(1, 1, 2, 3, 3);
            Assert.AreEqual(8, game.GetScore());

            rollFive(1, 1, 2, 3, 4);
            Assert.AreEqual(0, game.GetScore());

            rollFive(1, 1, 2, 2, 2);
            Assert.AreEqual(6, game.GetScore());

            rollFive(1, 1, 1, 1, 1);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenFourOfAKindCategory_thenAddAllFourSameNumbers()
        {
            game.Category = new OfAKind(4);

            rollFive(1, 1, 1, 1, 2);
            Assert.AreEqual(4, game.GetScore());

            rollFive(2, 2, 3, 2, 2);
            Assert.AreEqual(8, game.GetScore());

            rollFive(6, 6, 6, 6, 6);
            Assert.AreEqual(24, game.GetScore());

            rollFive(4, 4, 4, 3, 2);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenThreeOfAKindCategory_thenAddAllThreeSameNumbers()
        {
            game.Category = new OfAKind(3);

            rollFive(3, 3, 3, 4, 5);
            Assert.AreEqual(9, game.GetScore());

            rollFive(3, 3, 4, 5, 6);
            Assert.AreEqual(0, game.GetScore());

            rollFive(3, 3, 3, 3, 1);
            Assert.AreEqual(9, game.GetScore());

            rollFive(5, 5, 5, 5, 5);
            Assert.AreEqual(15, game.GetScore());
        }

        [Test]
        public void whenSmallStraightCategory_thenAddAllRolls()
        {
            game.Category = new SmallStraight();

            rollFive(1, 2, 3, 4, 5);
            Assert.AreEqual(15, game.GetScore());

            rollFive(1, 2, 3, 4, 4);
            Assert.AreEqual(0, game.GetScore());

            rollFive(2, 3, 4, 5, 6);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenLargeStraightCategory_thenAddAllRolls()
        {
            game.Category = new LargeStraight();

            rollFive(2, 3, 4, 5, 6);
            Assert.AreEqual(20, game.GetScore());

            rollFive(1, 2, 3, 4, 5);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void whenFullHouseCategory_thenAddAllRolls()
        {
            game.Category = new FullHouse();

            rollFive(1, 1, 2, 2, 2);
            Assert.AreEqual(8, game.GetScore());

            rollFive(2, 2, 3, 3, 4);
            Assert.AreEqual(0, game.GetScore());

            rollFive(4, 4, 4, 4, 4);
            Assert.AreEqual(0, game.GetScore());
        }
    }
}
