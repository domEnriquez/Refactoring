using ApprovalTests.Reporters;
using NUnit.Framework;
using System.Collections.Generic;
using Trivia;

namespace TriviaTests
{
    public class TriviaTest
    {
        private List<Questions> createQuestionCategories()
        {
            return new List<Questions>() { new PopQuestions(),
                                           new ScienceQuestions(),
                                           new SportsQuestions(),
                                           new RockQuestions() };
        }

        Game g;
        Player p1;

        [SetUp]
        public void SetUp()
        {
            List<Questions> q = createQuestionCategories();
            g = new Game(q);
            p1 = new Player("Dominic");
        }

        [TestFixture]
        public class OnePlayerTests : TriviaTest
        {
            [Test]
            public void populateQuestionsListWhenCreatingNewGame()
            {
                List<Questions> q = createQuestionCategories();
                Game game = new Game(q);

                for (int i = 0; i < q.Count; i++)
                {
                    Assert.AreEqual(50, q[i].GetItems().Count);
                }
            }


            [Test]
            public void newlyAddedPlayersPointsIsZero()
            {
                g.Add(p1);

                Assert.AreEqual(0, p1.GetPoints());
            }

            [Test]
            public void returnTrueWhenAddIsCalled()
            {
                Assert.IsTrue(g.Add(p1));
            }

            [Test]
            public void whenNotInPenaltyAndPlayerRolled_ThenIncreasePlayerPositionBasedOnRollResult()
            {
                g.Add(p1);

                g.rollEvent(2);

                Assert.AreEqual(2, p1.GetPosition());
            }

            [Test]
            public void whenInPenaltyAndRollResultIsOdd_ThenIncreasePlayerPositionBasedOnRollResult()
            {
                g.Add(p1);
                p1.PutInPenalty();

                g.rollEvent(3);

                Assert.AreEqual(3, p1.GetPosition());
            }

            [Test]
            public void newlyAddPlayersIsNotInPenaltyBox()
            {
                g.Add(p1);

                Assert.IsFalse(p1.InPenaltyBox());
            }

            [Test]
            public void whenInPenaltyAndRollResultIsEven_ThenNoChangeInPlayerPosition()
            {
                g.Add(p1);
                p1.PutInPenalty();

                g.rollEvent(2);

                Assert.AreEqual(0, p1.GetPosition());
            }

            [Test]
            public void whenNotInPenaltyAndMaximumPositionIsReachedAfterRoll_ThenPlayerPositionShouldCountBackFromZero()
            {
                g.Add(p1);
                p1.IncreasePositionBy(g.MaximumPosition(), g.MaximumPosition());

                g.rollEvent(6);

                Assert.AreEqual(5, p1.GetPosition());
            }

            [Test]
            public void whenInPenaltyAndMaximumPositionIsReachedAfterRollResultOfOdd_ThenPlayerPositionShouldCountBackFromZero()
            {
                g.Add(p1);
                p1.PutInPenalty();
                p1.IncreasePositionBy(g.MaximumPosition(), g.MaximumPosition());

                g.rollEvent(5);

                Assert.AreEqual(4, p1.GetPosition());
            }

            [Test]
            public void whenNotInPenaltyAndAnsweredCorrectly_ThenGoToNextPlayer()
            {
                g.Add(p1);
                g.Add(new Player("Genie"));

                g.rollEvent(1);
                g.wasCorrectlyAnswered();
                Assert.AreEqual("Genie", g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenNotInPenaltyAndAnsweredCorrectly_ThenIncreasePlayerCoins()
            {
                g.Add(p1);

                g.rollEvent(1);
                g.wasCorrectlyAnswered();
                Assert.AreEqual(1, p1.GetPoints());
            }

            [Test]
            public void whenNotInPenaltyAndPlayerWinsAfterAnswering_ThenReturnFalse()
            {
                g.Add(p1);

                for (int i = 1; i < g.MaximumPoints(); i++)
                {
                    g.rollEvent(1);
                    g.wasCorrectlyAnswered();
                }

                g.rollEvent(1);
                Assert.IsFalse(g.wasCorrectlyAnswered());
            }

            [Test]
            public void whenNotInPenaltyAndPlayerNotYetWinsAfterAnswering_ThenReturnTrue()
            {
                g.Add(p1);

                g.rollEvent(1);

                Assert.True(g.wasCorrectlyAnswered());
            }

            [Test]
            public void whenInPenaltyAndAnsweredCorrectlyAfterOddRollResult_ThenIncreasePlayerPoints()
            {
                p1.PutInPenalty();
                g.Add(p1);

                g.rollEvent(1);

                g.wasCorrectlyAnswered();

                Assert.AreEqual(1, p1.GetPoints());
            }

            [Test]
            public void whenInPenaltyAndPlayerWinsAfterOddRollResult_ThenReturnFalse()
            {
                g.Add(p1);
                p1.PutInPenalty();

                for (int i = 1; i < g.MaximumPoints(); i++)
                {
                    g.rollEvent(1);
                    g.wasCorrectlyAnswered();
                }

                g.rollEvent(1);
                Assert.IsFalse(g.wasCorrectlyAnswered());
            }

            [Test]
            public void whenInPenaltyAndPlayerNotYetWinsAfterOddRollResult_ThenReturnTrue()
            {
                g.Add(p1);
                p1.PutInPenalty();
                g.rollEvent(1);

                Assert.IsTrue(g.wasCorrectlyAnswered());
            }

            [Test]
            public void whenInPenaltyAndAnsweredCorrectlyAfterEvenRollResult_ThenReturnTrue()
            {
                g.Add(p1);
                g.rollEvent(2);

                Assert.IsTrue(g.wasCorrectlyAnswered());
            }

            [Test]
            public void whenWrongAnswer_thenPutPlayerInPenaltyBox()
            {
                g.Add(p1);
                g.rollEvent(1);

                g.wrongAnswer();

                Assert.IsTrue(p1.InPenaltyBox());
            }

            [Test]
            public void whenWrongAnswer_ThenReturnTrue()
            {
                g.Add(p1);
                g.rollEvent(1);

                Assert.IsTrue(g.wrongAnswer());
            }
        }


        [TestFixture]
        public class TwoPlayersTests : TriviaTest
        {
            Player p2;

            [SetUp]
            public void SetUp()
            {
                p2 = new Player("Genie");
            }

            [Test]
            public void incrementPlayerCountWhenAddingPlayer()
            {
                g.Add(p1);
                g.Add(p2);

                Assert.AreEqual(2, g.PlayersCount());
            }


            [Test]
            public void newlyAddedPlayersLocationIsZero()
            {
                g.Add(p1);
                g.Add(p2);

                Assert.AreEqual(0, p1.GetPosition());
                Assert.AreEqual(0, p2.GetPosition());
            }

            [Test]
            public void whenLastPlayerNotInPenaltyAndAnsweredCorrectly_ThenGoBackToFirstPlayer()
            {
                g.Add(p1);
                g.Add(p2);


                g.rollEvent(1);
                g.wasCorrectlyAnswered();
                g.rollEvent(1);
                g.wasCorrectlyAnswered();

                Assert.AreEqual(p1.Name, g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenInPenaltyAndAnsweredCorrectlyAfterOddRollResult_ThenGoToNextPlayer()
            {
                p1.PutInPenalty();
                g.Add(p1);
                g.Add(p2);

                g.rollEvent(1);

                g.wasCorrectlyAnswered();

                Assert.AreEqual(p2.Name, g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenLastPlayerIsInPenaltyAndAnsweredCorrectlyAfterOddRollResult_ThenGoBackToFirstPlayer()
            {
                g.Add(p1);
                g.Add(p2);
                p2.PutInPenalty();

                g.rollEvent(1); //First player roll
                g.wasCorrectlyAnswered();
                g.rollEvent(1); //Second player roll
                g.wasCorrectlyAnswered();

                Assert.AreEqual(p1.Name, g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenInPenaltyAndAnsweredCorrectlyAfterEvenRollResult_TheGoToNextPlayer()
            {
                g.Add(p1);
                g.Add(p2);
                p1.PutInPenalty();
                g.rollEvent(2);

                g.wasCorrectlyAnswered();

                Assert.AreEqual(p2.Name, g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenLastPlayerInPenaltyAndAnsweredCorrectlyAfterEvenRollResult_ThenGoBackToFirstPlayer()
            {
                g.Add(p1);
                g.Add(p2);
                p2.PutInPenalty();

                g.rollEvent(1); //First player roll
                g.wasCorrectlyAnswered();
                g.rollEvent(2); //Second player roll
                g.wasCorrectlyAnswered();

                Assert.AreEqual(p1.Name, g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenWrongAnswer_thenGoToNextPlayer()
            {
                g.Add(p1);
                g.Add(p2);
                g.rollEvent(1);

                g.wrongAnswer();

                Assert.AreEqual(p2.Name, g.GetCurrentPlayer().Name);
            }

            [Test]
            public void whenLastPlayerMadeWrongAnswer_thenGoBackToFirstPlayer()
            {
                g.Add(p1);
                g.Add(p2);

                g.rollEvent(1); //First player
                g.wasCorrectlyAnswered();
                g.rollEvent(1); //Second player
                g.wrongAnswer();

                Assert.AreEqual(p1.Name, g.GetCurrentPlayer().Name);
            }
        }


    }
}
