using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.TripSection
{
    public class TripDAO
    {
        public static List<Trip> FindTripsByUser(UserSection.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
    }
}
