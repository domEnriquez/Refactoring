using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;
        private string player1Name;
        private string player2Name;

        private Dictionary<int, string> scoreMap = new Dictionary<int, string>()
        {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" }
        };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (equalScoreLessForty())
            {
                return scoreMap[p1point] + "-All";
            }
            else if (isDeuce())
            {
                return "Deuce";
            }
            else if (isAdvantage())
            {
                if (p1point - p2point > 0)
                    return "Advantage " + player1Name;
                else
                    return "Advantage " + player2Name;
            }
            else if (isWon())
            {
                if (p1point - p2point > 0)
                    return "Win for " + player1Name;
                else
                    return "Win for " + player2Name;
            }
            else
            {
                return scoreMap[p1point] + "-" + scoreMap[p2point];
            }
        }

        private bool equalScoreLessForty()
        {
            return p1point == p2point &&
                p1point < Score.FORTY;
        }

        private bool isDeuce()
        {
            return p1point == p2point &&
                p1point > Score.THIRTY;
        }

        private bool isAdvantage()
        {
            int scoreDiff = p1point - p2point;

            return ((p1point > Score.FORTY ||
                p2point > Score.FORTY) &&
                (scoreDiff == 1 || scoreDiff == -1));
        }

        private bool isWon()
        {
            int scoreDiff = p1point - p2point;

            return ((p1point > Score.FORTY ||
                p2point > Score.FORTY) &&
                (scoreDiff >= 2 || scoreDiff <= -2));
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                p1point++;
            else
                p2point++;
        }
    }
}

