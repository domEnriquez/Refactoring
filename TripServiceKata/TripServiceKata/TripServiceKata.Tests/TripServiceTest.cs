using Moq;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.TripSection;
using TripServiceKata.UserSection;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceTest
    {
        private Mock<TripService> mockTripService;

        [SetUp]
        public void SetUp()
        {
            mockTripService = new Mock<TripService>();
        }

        [Test]
        public void GivenLoggedUserIsNull_WhenGetTripsByUser_ThenThrowUserNotLoggedInException()
        {
            mockTripService.Setup(t => t.GetLoggedUser()).Returns<User>(null);

            Assert.That(() => mockTripService.Object.GetTripsByUser(new User()),
                Throws.TypeOf<UserNotLoggedInException>());
        }

        [Test]
        public void GivenTheInputUserIsNotFriendOfLoggedInUser_WhenGetTripsByUser_ThenReturnEmptyTripList()
        {
            mockTripService.Setup(t => t.GetLoggedUser()).Returns(new User());

            Assert.That(mockTripService.Object.GetTripsByUser(new User()), Is.Empty);
        }

        [Test]
        public void GivenInputUserIsFriendOfLoggedInUser_WhenGetTripsByUser_ThenReturnTripsofInputUser()
        {
            User loggedInUser = new User();
            User inputUser = new User();
            inputUser.AddFriend(loggedInUser);
            inputUser.AddTrip(new Trip());

            mockTripService.Setup(t => t.GetLoggedUser()).Returns(loggedInUser);
            mockTripService.Setup(t => t.FindTripsByUser(inputUser)).Returns(inputUser.Trips());

            Assert.That(mockTripService.Object.GetTripsByUser(inputUser), Has.Count.EqualTo(1));
        }
    }
}
