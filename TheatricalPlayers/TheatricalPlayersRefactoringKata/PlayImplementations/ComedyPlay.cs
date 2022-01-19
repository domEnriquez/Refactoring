using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.PlayImplementations
{
    public class ComedyPlay : Play
    {
        public ComedyPlay(string name) : base(name)
        {
        }

        public override int Cost(int audience)
        {
            int cost = 30000;

            if (audience > 20)
                cost += 10000 + 500 * (audience - 20);

            cost += 300 * audience;

            return cost;
        }

        public override int VolumeCredits(int audience)
        {

            return Math.Max(audience - 30, 0)
                + (int)Math.Floor((decimal)audience / 5);
        }
    }
}
