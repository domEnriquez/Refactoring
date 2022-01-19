using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata
{
    public class Invoice
    {
        private string customer;
        private List<Performance> performances;

        public string Customer { get => customer; set => customer = value; }
        public List<Performance> Performances { get => performances; set => performances = value; }

        public Invoice(string customer, List<Performance> performances)
        {
            this.customer = customer;
            this.performances = performances;
        }

        public int GetTotalAmount(Dictionary<string, Play> plays)
        {
            int totalAmount = 0;

            foreach (Performance perf in Performances)
            {
                Play play = plays[perf.PlayID];

                totalAmount += play.Cost(perf.Audience);
            }

            return totalAmount;
        }

        public int GetTotalVolumeCredits(Dictionary<string, Play> plays)
        {
            int volumeCredits = 0;

            foreach (var perf in Performances)
            {
                Play play = plays[perf.PlayID];

                volumeCredits += play.VolumeCredits(perf.Audience);
            }

            return volumeCredits;
        }
    }
}
