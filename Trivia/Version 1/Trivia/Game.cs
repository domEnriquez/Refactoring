using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Game
    {
        private const int MAX_POSITION = 11;
        private const int MAX_POINTS = 6;
        private const int NO_OF_QUESTIONS_PER_CATEGORY = 50;

        private List<Questions> questions;
        private List<Player> players = new List<Player>();
        private GameUI ui;
        private int currentPlayer = 0;

        public Game(List<Questions> q)
        {
            questions = q;
            populateQuestions();
            ui = new GameUI();
        }

        private void populateQuestions()
        {
            for (int i = 0; i < questions.Count; i++)
                questions[i].AddMultipleItems(NO_OF_QUESTIONS_PER_CATEGORY);
        }

        public bool Add(Player p)
        {
            players.Add(p);
            ui.ShowAddedPlayerDetails(p.Name, PlayersCount());
            return true;
        }

        public int PlayersCount()
        {
            return players.Count;
        }

        public void rollEvent(int roll)
        {
            ui.ShowPlayerToRoll(GetCurrentPlayer().Name);
            ui.ShowRollAction(roll);

            if (GetCurrentPlayer().InPenaltyBox())
            {
                if (odd(roll))
                {
                    removePenaltyProcess(GetCurrentPlayer());
                    increasePositionProcess(roll, GetCurrentPlayer());
                    askQuestion();
                }
                else
                {
                    ui.ShowNotGettingOutOfPenaltyMessage(GetCurrentPlayer().Name);
                }
            }
            else
            {
                increasePositionProcess(roll, GetCurrentPlayer());
                askQuestion();
            }

        }

        private bool odd(int roll)
        {
            return roll % 2 != 0;
        }

        private void increasePositionProcess(int roll, Player currPlayer)
        {
            currPlayer.IncreasePositionBy(roll, MaximumPosition());
            ui.ShowPlayerUpdatedLocation(currPlayer.Name, currPlayer.GetPosition());
        }

        private void removePenaltyProcess(Player currPlayer)
        {
            currPlayer.RemovePenalty();
            ui.ShowGettingOutOfPenaltyMessage(currPlayer.Name);
        }

        public int MaximumPosition()
        {
            return MAX_POSITION;
        }

        private void askQuestion()
        {
            Questions q = getCurrQuestionCat();
            LinkedList<string> items = q.GetItems();
            ui.ShowQuestionCategory(q.GetName(), items.First());
            items.RemoveFirst();
        }

        private Questions getCurrQuestionCat()
        {
            for (int i = 0; i < questions.Count; i++)
                if (questions[i].CurrentCategory(GetCurrentPlayer().GetPosition()))
                    return questions[i];

            return null;
        }

        public bool wasCorrectlyAnswered()
        {
            if (GetCurrentPlayer().InPenaltyBox())
            {
                goToNextPlayer();
                return true;
            }
            else
            {
                ui.ShowAnswerIsCorrect();
                GetCurrentPlayer().IncreasePoints();
                ui.ShowPlayerCoinsValue(GetCurrentPlayer().Name, GetCurrentPlayer().GetPoints());
                goToNextPlayer();

                return notYetWins(GetCurrentPlayer());
            }
        }

        private void goToNextPlayer()
        {
            currentPlayer++;
            if (currentPlayer == PlayersCount())
                currentPlayer = 0;
        }

        public bool wrongAnswer()
        {
            ui.ShowAnswerIsWrong();
            ui.ShowPlayerIsPutInPenaltyBox(GetCurrentPlayer().Name);
            GetCurrentPlayer().PutInPenalty();

            goToNextPlayer();
            return true;
        }

        private bool notYetWins(Player p)
        {
            return !(p.GetPoints() == MaximumPoints());
        }
        public Player GetCurrentPlayer()
        {
            return players[currentPlayer];
        }

        public int MaximumPoints()
        {
            return MAX_POINTS;
        }
    }

}
