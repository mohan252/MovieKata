using System;

namespace MovieExample
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public Movie(string inTitle, int inPriceCode)
        {
            Title = inTitle;
            PriceCode = inPriceCode;
        }

        public int PriceCode { set; get; }

        public String Title { get; private set; }
    }
}