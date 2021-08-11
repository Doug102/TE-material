namespace Exercises.Classes
{
    public class Airplane
    {
        public string PlaneNumber { get; private set; }
        public int TotalFirstClassSeats { get; private set; }
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats
        {
            get
            {

                return TotalFirstClassSeats - BookedFirstClassSeats;

            }
        }
        public int TotalCoachSeats { get; private set; }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats
        {
            get
            {

                return TotalCoachSeats - BookedCoachSeats;

            }
        }

        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;
        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass)
            {
                int bookedFirstClassSeats = BookedFirstClassSeats + totalNumberOfSeats;

                if (bookedFirstClassSeats <= TotalFirstClassSeats)
                {
                    BookedFirstClassSeats += totalNumberOfSeats;
                    return true;

                }
                return false;
            }
            else
            {
                int bookedCoachSeats = BookedCoachSeats + totalNumberOfSeats;
                                
                if (bookedCoachSeats <= TotalCoachSeats)
                {
                    BookedCoachSeats += totalNumberOfSeats;
                    return true;

                }
                return false;
            }

        }

    }
}
