using System;

namespace CarDealership
{
    public class FinancedAutomobile : Automobile
    {
        private float finance;

        public FinancedAutomobile(int idNumber, string make, int year, float price, float finance) : base(idNumber, make, year, price)
        {
            if ((finance >= 0) && (finance <= 10))
                this.finance = finance;

            else
            {
                Console.WriteLine("A finance value entered is outside of the permitted range of 0 - 10%");
                Environment.Exit(1);
            }
        }

        public override string ToString()
        {
            return String.Format("ID Number: {0, -2} | Make: {1, -9} | Year: {2, -5} | Price {3, -5} | Interest Rate: {4, -5}", idNumber, make, year, price.ToString("C2"), (finance / 100).ToString("P"));
        }

    }
}