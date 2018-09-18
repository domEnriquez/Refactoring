using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDMicroExercises.TurnTicketDispenser
{
    [TestFixture]
    public class TurnTicketDispenserTest
    {
        [SetUp]
        public void GivenAZeroTurnNumber()
        {
            TurnNumberSequence.SetNextTurnNumber(0);
        }

        [Test]
        public void GivenOneTicketDispenser_WhenGetTurnTicket_ThenIncrementTurnNumber()
        {
            TicketDispenser td = new TicketDispenser();

            Assert.AreEqual(0, td.GetTurnTicket().TurnNumber);
            Assert.AreEqual(1, td.GetTurnTicket().TurnNumber);
            Assert.AreEqual(2, td.GetTurnTicket().TurnNumber);
        }

        [Test]
        public void GivenMultipleTicketDispensers_WhenGetTurnTicketInAnyDispenser_ThenAlwaysIncrementTurnNumber()
        {
            TicketDispenser td1 = new TicketDispenser();
            TicketDispenser td2 = new TicketDispenser();
            TicketDispenser td3 = new TicketDispenser();

            Assert.AreEqual(0, td1.GetTurnTicket().TurnNumber);
            Assert.AreEqual(1, td2.GetTurnTicket().TurnNumber);
            Assert.AreEqual(2, td3.GetTurnTicket().TurnNumber);
            Assert.AreEqual(3, td2.GetTurnTicket().TurnNumber);
            Assert.AreEqual(4, td3.GetTurnTicket().TurnNumber);
            Assert.AreEqual(5, td1.GetTurnTicket().TurnNumber);
        }
    }
}
