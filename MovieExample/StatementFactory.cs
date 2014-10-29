using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExample
{
    public class StatementPreparer
    {
        public StatementPreparer(IStatementFactory factory, IStatementFormatter formatter)
        {
        }
    }

    public class StatementFactory
    {
        public Statement Prepare(Customer customer)
        {
            var frequentRenterPoints = 0;
            var statement = new Statement { CustomerName = customer.Name };

            foreach (var rental in customer.Rentals)
            {
                var rentalItem = new RentalLineItem
                {
                    Amount = CalculateRentalAmount(rental),
                    Title = rental.TheMovie.Title
                };

                frequentRenterPoints += PointsToAward(rental);
                statement.RentalLineItems.Add(rentalItem);
            }

            statement.AmountOwed = statement.RentalLineItems.Sum(x => x.Amount);
            statement.FrequentRenterPoints = frequentRenterPoints;
            return statement;
        }

        private static int PointsToAward(Rental rental)
        {
            return IsTwoDayNewRelease(rental) ? 2 : 1;
        }

        private static bool IsTwoDayNewRelease(Rental rental)
        {
            return (rental.TheMovie.PriceCode == Movie.NEW_RELEASE) && rental.DaysRented > 1;
        }

        private static double CalculateRentalAmount(Rental rental)
        {
            double thisAmount = 0;
            switch (rental.TheMovie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.DaysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }
    }

    public class StatementFormatter
    {
        public string Format(Statement statement)
        {
            var result = "";
            result = "Rental Record for " + statement.CustomerName + "\n";
            foreach (var rentalItem in statement.RentalLineItems)
            {
                result += "\t" + rentalItem.Title + "\t" + rentalItem.Amount + "\n";
            }
            result += "Amount owed is " + statement.AmountOwed + "\n";
            result += "You earned " + statement.FrequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
