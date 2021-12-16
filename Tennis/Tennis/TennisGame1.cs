namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
                return equalScoreDisplay();
            else if (m_score1 > ScoreConstants.FORTY || m_score2 > ScoreConstants.FORTY)
                return winnerPlayerDisplay();
            else
                return scoreDisplay();
        }

        private string equalScoreDisplay()
        {
            switch (m_score1)
            {
                case ScoreConstants.LOVE:
                    return "Love-All";
                case ScoreConstants.FIFTEEN:
                    return "Fifteen-All";
                case ScoreConstants.THIRTY:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private string scoreDisplay()
        {
            string p1Score = equivalentScore(m_score1);
            string p2Score = equivalentScore(m_score2);

            return p1Score + "-" + p2Score;
        }

        private string winnerPlayerDisplay()
        {
            int minusResult = m_score1 - m_score2;

            if (minusResult == 1)
                return "Advantage " + player1Name;
            else if (minusResult == -1)
                return "Advantage " + player2Name;
            else if (minusResult >= 2)
                return "Win for " + player1Name;
            else
                return "Win for " + player2Name;
        }

        private string equivalentScore(int score)
        {
            switch (score)
            {
                case ScoreConstants.LOVE:
                    return "Love";
                case ScoreConstants.FIFTEEN:
                    return "Fifteen";
                case ScoreConstants.THIRTY:
                    return "Thirty";
                case ScoreConstants.FORTY:
                    return "Forty";
                default:
                    return string.Empty;
            }
        }
    }
}

