using System.Collections.Generic;

namespace TripServiceKata.UserSection
{
    public class User
    {
        private List<TripSection.Trip> trips = new List<TripSection.Trip>();
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        } 

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(TripSection.Trip trip)
        {
            trips.Add(trip);
        }

        public List<TripSection.Trip> Trips()
        {
            return trips;
        } 
    }
}
