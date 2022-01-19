using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.PlayImplementations
{
    public class TragedyPlay : Play
    {
        public TragedyPlay(string name) : base(name)
        {
        }

        public override int Cost(int audience)
        {
            int cost = 40000;

            if (audience > 30)
                cost += 1000 * (audience - 30); cost = 40000;

            if (audience > 30)
                cost += 1000 * (audience - 30);

            return cost;
        }

        public override int VolumeCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }

    }
}
