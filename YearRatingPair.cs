namespace NinetiesTV
{
    // This class is used in the challenges
    public class YearRatingPair
    {
        public YearRatingPair(int year, double rating)
        {
            Year = year;
            Rating = rating;
        }

        public int Year { get; }
        public double Rating { get; }
    }
}