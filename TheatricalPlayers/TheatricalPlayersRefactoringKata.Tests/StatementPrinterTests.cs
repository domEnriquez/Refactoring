using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace TheatricalPlayersRefactoringKata.Tests
{
    [TestFixture]
    public class StatementPrinterTests
    {
        private Dictionary<string, Play> plays;
        private StatementPrinter statementPrinter;

        [SetUp]
        public void SetUp()
        {
            plays = new Dictionary<string, Play>();
            statementPrinter = new StatementPrinter();
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void test_statement_example()
        {
            plays.Add("hamlet", Play.Create("Hamlet", "tragedy"));
            plays.Add("as-like", Play.Create("As You Like It", "comedy"));
            plays.Add("othello", Play.Create("Othello", "tragedy"));

            Invoice invoice = new Invoice("BigCo", new List<Performance>{
                new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40)});
            
            var result = statementPrinter.Print(invoice, plays);

            Approvals.Verify(result);
        }

        [Test]
        public void test_statement_with_new_play_types()
        {
            Assert.Throws<Exception>(() => Play.Create("Henry V", "history"));
            Assert.Throws<Exception>(() => Play.Create("Henry V", "pastoral"));
        }
    }
}
