using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieExample
{
    public class Customer
    {
        public List<Rental> Rentals { get; private set; }

        public Customer(String inName)
        {
            Name = inName;
            Rentals = new List<Rental>();
        }

        public String Name { get; private set; }
        
        public void AddRental(Rental arg)
        {
            Rentals.Add(arg);
        }

        public string Statement()
        {
            //double totalAmount = 0;
            var statement = new StatementFactory().Prepare(this);

            return new StatementFormatter().Format(statement);
        }

        
    }

    public class RentalLineItem
    {
        public double Amount { get; set; }

        public string Title { get; set; }
    }

    public class Statement
    {
        public string CustomerName { get; set; }

        public List<RentalLineItem> RentalLineItems { get; set; }

        public double AmountOwed { get; set; }

        public int FrequentRenterPoints { get; set; }

        public Statement()
        {
            RentalLineItems = new List<RentalLineItem>();
        }
    }
}