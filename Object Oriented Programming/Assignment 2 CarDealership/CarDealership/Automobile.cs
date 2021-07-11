using System;

namespace CarDealership
{
    public class Automobile
    {
        protected int idNumber;
        protected int year;
        protected string make;
        protected float price;

        public Automobile(int idNumber, string make, int year, float price)
        {
            this.idNumber = idNumber;
            this.make = make;
            this.price = price;

            if ((year >= 1950) && (year <= 2020))
                this.year = year;

            else
            {
                Console.WriteLine("A year entered is outside of the parameters 1950 - 2020");
                Environment.Exit(1);
            }
        }

        public Automobile(int idNumber, string make, int year, float price, float discount) : this(idNumber, make, year, price)
        {
            if ((discount >= 0) && (discount <= 20))
            {
                this.price = price - ((price * discount) / 100);
            }

            else
            {
                Console.WriteLine("A discount value entered is outside of the accepted range of 0 - 20%");
                Environment.Exit(1);
            }
        }

        public new virtual string ToString()
        {
            return String.Format("ID Number: {0, -2} | Make: {1, -9} | Year: {2, -5} | Price {3, -5}", idNumber, make, year, price.ToString("C2"));
        }
    }
}
