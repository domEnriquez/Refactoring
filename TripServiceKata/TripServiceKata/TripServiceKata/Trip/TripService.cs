using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.UserSection;

namespace TripServiceKata.TripSection
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            User loggedUser = GetLoggedUser();

            if (loggedUser == null)
                throw new UserNotLoggedInException();


            if (areFriends(user, loggedUser))
                tripList = FindTripsByUser(user);

            return tripList;
        }

        private bool areFriends(User user, User loggedUser)
        {
            bool isFriend = false;

            foreach (User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
                {
                    isFriend = true;
                    break;
                }
            }

            return isFriend;
        }

        public virtual List<Trip> FindTripsByUser(User user)
        {
            return TripDAO.FindTripsByUser(user);
        }

        public virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}
