namespace MovieExample
{
    public class Rental
    {
        public Rental(Movie inMovie, int inDaysRented)
        {
            TheMovie = inMovie;
            DaysRented = inDaysRented;
        }

        public int DaysRented { get; private set; }

        public Movie TheMovie { get; private set; }
    }
}