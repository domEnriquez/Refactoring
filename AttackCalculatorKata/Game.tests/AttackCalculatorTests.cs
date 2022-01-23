using NUnit.Framework;

namespace Game.tests
{
    [TestFixture]
    public class AttackCalculatorTests 
    {
        [Test]
        public void ThisTestShouldPass()
        {          
            Assert.That(0, Is.EqualTo(0));
        }

       [Test]
        public void ThisTestShouldFail()
        {          
            Assert.That(0, Is.EqualTo(42));
        }
    }
}
