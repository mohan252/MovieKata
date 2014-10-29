using System;
using MovieExample;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class TestCustomer
    {
        [Test]
        public void Childrens_3DayRental_And_NewRelease_2DayRental()
        {
            var customer = new Customer("Bob");

            var movie = new Movie("Maleficent", Movie.NEW_RELEASE);
            var rental = new Rental(movie, 2);

            customer.AddRental(rental);

            movie = new Movie("Frozen", Movie.CHILDRENS);
            rental = new Rental(movie, 3);

            customer.AddRental(rental);

            var actual = customer.Statement();
            
            var expected2 = "Rental Record for Bob\n" +
                               "\tMaleficent\t6\n" +
                               "\tFrozen\t1.5\n" +
                               "Amount owed is 7.5\n" +
                               "You earned 3 frequent renter points";
            Assert.AreEqual(expected2, actual);

            Console.Write(actual);
        }

        [Test]
        public void Childrens_3DayRental()
        {
            var customer = new Customer("Bob");

            var movie = new Movie("Maleficent", Movie.CHILDRENS);
            var rental = new Rental(movie, 3);

            customer.AddRental(rental);

            var actual = customer.Statement();
            var expected = "Rental Record for Bob\n" +
                               "\tMaleficent\t1.5\n" +
                               "Amount owed is 1.5\n" +
                               "You earned 1 frequent renter points";
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Childrens_4DayRental()
        {
            var customer = new Customer("Bob");

            var movie = new Movie("Maleficent", Movie.CHILDRENS);
            var rental = new Rental(movie, 4);

            customer.AddRental(rental);

            var actual = customer.Statement();
            var expected = "Rental Record for Bob\n" +
                               "\tMaleficent\t3\n" +
                               "Amount owed is 3\n" +
                               "You earned 1 frequent renter points";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NewRelease_2DayRental()
        {
            var customer = new Customer("Bob");

            var movie = new Movie("Maleficent", Movie.NEW_RELEASE);
            var rental = new Rental(movie, 2);

            customer.AddRental(rental);

            var actual = customer.Statement();
            var expected = "Rental Record for Bob\n" +
                               "\tMaleficent\t6\n" +
                               "Amount owed is 6\n" +
                               "You earned 2 frequent renter points";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Regular_2DayRental()
        {
            var customer = new Customer("Bob");

            var movie = new Movie("Maleficent", Movie.REGULAR);
            var rental = new Rental(movie, 2);

            customer.AddRental(rental);

            var actual = customer.Statement();
            var expected = "Rental Record for Bob\n" +
                               "\tMaleficent\t2\n" +
                               "Amount owed is 2\n" +
                               "You earned 1 frequent renter points";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Regular_3DayRental()
        {
            var customer = new Customer("Bob");

            var movie = new Movie("Maleficent", Movie.REGULAR);
            var rental = new Rental(movie, 3);

            customer.AddRental(rental);

            var actual = customer.Statement();
            var expected = "Rental Record for Bob\n" +
                               "\tMaleficent\t3.5\n" +
                               "Amount owed is 3.5\n" +
                               "You earned 1 frequent renter points";
            Assert.AreEqual(expected, actual);
        }



        // if i have new release, days for which normal price is applicable
        // if i have new release, days exeeds the normal price days
    }
}