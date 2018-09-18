using ApprovalTests.Reporters;
using ApprovalTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Trivia;
using System.IO;

namespace TriviaTests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class TriviaUITest
    {
        private List<Questions> createQuestionCategories()
        {
            return new List<Questions>() { new PopQuestions(),
                                           new ScienceQuestions(),
                                           new SportsQuestions(),
                                           new RockQuestions() };
        }

        StringBuilder fakeOutput;
        Player p1;
        Game g;

        [SetUp]
        public void SetUp()
        {
            p1 = new Player("Dominic");
            List<Questions> q = createQuestionCategories();
            g = new Game(q);
            fakeOutput = new StringBuilder();
        }

        [Test]
        public void showPlayerNameAndCountWhenAPlayerIsAdded()
        {
            Console.SetOut(new StringWriter(fakeOutput));

            g.Add(p1);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void whenNotInPenaltyAndPlayerNewPositionAfterRollIs048_ThenShowRollEventDetailsAndPopQuestions()
        {
            g.Add(p1);

            Console.SetOut(new StringWriter(fakeOutput));
            g.rollEvent(4);
            g.rollEvent(4);
            g.rollEvent(4);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void whenNotInPenaltyAndPlayerNewPostionAfterRollIs159_ThenShowRollEventDetailsAndScienceQuestions()
        {
            g.Add(p1);

            Console.SetOut(new StringWriter(fakeOutput));
            g.rollEvent(1);
            g.rollEvent(4);
            g.rollEvent(4);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void whenNotInPenaltyAndPlayerNewPositionAfterRollIs2610_ThenShowRollEventDetailsAndSportsQuestions()
        {
            g.Add(p1);

            Console.SetOut(new StringWriter(fakeOutput));
            g.rollEvent(2);
            g.rollEvent(4);
            g.rollEvent(4);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void whenInPenaltyAndRollResultIsEven_ThenShowNotOutOfPenaltyInfo()
        {
            g.Add(p1);
            p1.PutInPenalty();

            Console.SetOut(new StringWriter(fakeOutput));
            g.rollEvent(2);

            Assert.IsTrue(fakeOutput.ToString().Contains(p1.Name + " is not getting out of the penalty box"));
        }

        [Test]
        public void whenInPenaltyAndRollResultIsOdd_ThenShowGettingOutOfPenaltyInfo()
        {
            g.Add(p1);
            p1.PutInPenalty();

            Console.SetOut(new StringWriter(fakeOutput));
            g.rollEvent(1);

            Assert.IsTrue(fakeOutput.ToString().Contains(p1.Name + " is getting out of the penalty box"));
        }

        [Test]
        public void whenNotInPenaltyAndAnsweredCorrectly_showAnswerCorrectInfoAndPlayerCoinsNewValue()
        {
            g.Add(p1);
            g.rollEvent(1);

            Console.SetOut(new StringWriter(fakeOutput));
            g.wasCorrectlyAnswered();

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void whenInPenaltyAndAnsweredCorrectlyAfterOddRoll_ThenShowAnswerCorrectInfoAndPlayerCoinsNewValue()
        {
            g.Add(p1);
            p1.PutInPenalty();
            g.rollEvent(1);

            Console.SetOut(new StringWriter(fakeOutput));
            g.wasCorrectlyAnswered();

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void whenWrongAnswer_thenShowPlayerHasWrongAnswerAndPlacedInPenaltyBox()
        {
            g.Add(p1);
            g.rollEvent(2);

            Console.SetOut(new StringWriter(fakeOutput));
            g.wrongAnswer();

            Approvals.Verify(fakeOutput);
        }
    }
}
