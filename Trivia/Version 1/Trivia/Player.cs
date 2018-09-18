using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; set; }

        private int position;
        private int points;
        private bool inPenalty;

        public Player(string playerName)
        {
            Name = playerName;
        }

        public void PutInPenalty()
        {
            inPenalty = true;
        }

        public void RemovePenalty()
        {
            inPenalty = false;
        }

        public bool InPenaltyBox()
        {
            return inPenalty;
        }

        public int GetPoints()
        {
            return points;
        }

        public void IncreasePoints()
        {
            points++;
        }

        public int GetPosition()
        {
            return position;
        }

        public void IncreasePositionBy(int increase, int maxPos)
        {
            position += increase;

            if (position > maxPos)
                position -= maxPos + 1;
        }
    }
}
