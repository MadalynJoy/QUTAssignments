using System;

namespace CarDealership
{
    class TestAutomobile
    {
        static void Main(string[] args)
        {
            Automobile car0 = new Automobile(1, "Toyota", 2020, 1400, 0F);
            Automobile car1 = new Automobile(2, "Subaru", 1950, 1500, 2.2F);
            Automobile car2 = new Automobile(3, "Honda", 2010, 2000, 2.3F);
            Automobile car3 = new Automobile(4, "Suzuki", 1999, 1750, 4.0F);
            Automobile car4 = new Automobile(5, "Mazda", 2000, 1250, 20F);

            Automobile car5 = new FinancedAutomobile(6, "BMW", 1970, 1000, 0F);
            Automobile car6 = new FinancedAutomobile(7, "Mercedes", 1950, 1200, 10F);
            Automobile car7 = new FinancedAutomobile(8, "VW", 2006, 1500, 4.8F);
            Automobile car8 = new FinancedAutomobile(9, "SAAB", 2017, 4000, 3.9F);
            Automobile car9 = new FinancedAutomobile(10, "Renault", 2020, 6000, 2.0F);

            Automobile[] cars = new Automobile[10];
            cars[0] = car0;
            cars[1] = car1;
            cars[2] = car2;
            cars[3] = car3;
            cars[4] = car4;
            cars[5] = car5;
            cars[6] = car6;
            cars[7] = car7;
            cars[8] = car8;
            cars[9] = car9;

            foreach (Automobile c in cars)
            {
                Console.WriteLine(c.ToString());
            }

        }
    }
}
