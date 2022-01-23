using Moq;
using NUnit.Framework;

namespace Game.tests
{
    [TestFixture]
    public class AttackCalculatorTests 
    {

        private Mock<AttackCalculator> mockCalcu;
        private Character atk;
        private Character def;


        [SetUp]
        public void SetUp()
        {
            mockCalcu = new Mock<AttackCalculator>();
            atk = new Character(1, 2, "Goblin", 3);
            def = new Character(10, 1, "Turtle", 1);
        }

        [Test]
        public void GivenAtkForcePlusDiceLessThanDefArmor_WhenCalculateDamage_ThenReturnZero()
        {
            mockCalcu.Setup(x => x.DiceRoll()).Returns(1);

            atk = new Character(1, 2, "Goblin", 3);
            def = new Character(10, 1, "Turtle", 1);

            Assert.That(mockCalcu.Object.CalculateDamage(atk, def), 
                Is.EqualTo(0));
        }

        [Test]
        public void GivenAtkForcePlusDiceMoreThanDefArmor_WhenCalculateDamage_ThenReturnAtkDamage()
        {
            mockCalcu.Setup(x => x.DiceRoll()).Returns(15);

            atk = new Character(1, 2, "Goblin", 3);
            def = new Character(10, 1, "Turtle", 1);

            Assert.That(mockCalcu.Object.CalculateDamage(atk, def), 
                Is.EqualTo(2));
        }

        [Test]
        public void GivenAtkForcePlusDiceMoreThanDefArmorAndDiceRollIsOne_WhenCalculateDamage_ThenReturnZero()
        {
            mockCalcu.Setup(x => x.DiceRoll()).Returns(1);

            atk = new Character(1, 2, "Goblin", 3);
            def = new Character(2, 1, "Turtle", 1);

            Assert.That(mockCalcu.Object.CalculateDamage(atk, def),
                Is.EqualTo(0));
        }

        [Test]
        public void GivenAtkForcePlusDiceMoreThanDefArmorAndDiceRollIsTwenty_WhenCalculateDamage_ThenReturnTwiceAtkDamage()
        {
            mockCalcu.Setup(x => x.DiceRoll()).Returns(20);

            atk = new Character(1, 2, "Goblin", 3);
            def = new Character(2, 1, "Turtle", 1);

            Assert.That(mockCalcu.Object.CalculateDamage(atk, def),
                Is.EqualTo(4));
        }
    }
}
