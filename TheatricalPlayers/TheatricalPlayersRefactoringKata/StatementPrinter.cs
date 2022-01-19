using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        private CultureInfo cultureInfo;

        public StatementPrinter()
        {
            cultureInfo = new CultureInfo("en-US");
        }

        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            string result = headerLine(invoice);

            foreach (var perf in invoice.Performances)
                result += playOrderLine(plays[perf.PlayID], perf.Audience);

            result += totalAmountLine(invoice.GetTotalAmount(plays));
            result += totalCreditsLine(invoice.GetTotalVolumeCredits(plays));

            return result;
        }

        private static string headerLine(Invoice invoice)
        {
            return string.Format("Statement for {0}\n", invoice.Customer);
        }
        private string playOrderLine(Play play, int audience)
        {
            decimal amount = Convert.ToDecimal(play.Cost(audience) / 100);

            return string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", 
                play.Name, 
                amount, 
                audience);
        }

        private string totalAmountLine(int totalAmount)
        {
            return String.Format(cultureInfo, 
                "Amount owed is {0:C}\n", 
                Convert.ToDecimal(totalAmount / 100));
        }
        private string totalCreditsLine(int volumeCredits)
        {
            return String.Format("You earned {0} credits\n", volumeCredits);
        }


    }
}
