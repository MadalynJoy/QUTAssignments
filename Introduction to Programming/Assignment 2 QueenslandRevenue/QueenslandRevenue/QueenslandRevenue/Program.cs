using System;
using static System.Console;

namespace QueenslandRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            int entry2019, entry2020, entry2019Double;

            string userInput;

            const int MIN = 0;

            const int MAX = 30;

            // User can input the number of contestants for 2019 and 2020. If the input is incorrect the user is prompted to try again.
            WriteLine("Enter No. of Contestants in 2019 >>> ");

            userInput = ReadLine();

            entry2019 = Convert.ToInt32(userInput);

            while (entry2019 < MIN || entry2019 > MAX)
            {
                WriteLine("Invalid number. Retry >>> ");
                userInput = ReadLine();
                entry2019 = Convert.ToInt32(userInput);
            }

            WriteLine("Enter No. of Contestants in 2020 >>> ");

            userInput = ReadLine();

            entry2020 = Convert.ToInt32(userInput);

            while (entry2020 < MIN || entry2020 > MAX)
            {
                WriteLine("Invalid number. Retry >>> ");
                userInput = ReadLine();
                entry2020 = Convert.ToInt32(userInput);
            }

            WriteLine($"There were {entry2019} contestants in 2019 and {entry2020} contestants in 2020");

            // A message will appear based on the comparison of the number of contestants between 2019 and 2020.
            // Variable entry2019Double has been created to capture the contestant imput for 2019 and then doubled it.
            entry2019Double = entry2019 * 2;

            if (entry2020 > entry2019Double)
            {
                WriteLine("The competition is more than twice as big this year!");
            }

            else if ((entry2020 >= entry2019) && (entry2020 <= entry2019Double))
            {
                WriteLine("The competition is bigger than ever!");
            }

            else
                WriteLine("A tighter race this year! Come out and cast your vote!");

            //Array has been created to capture contestant names for 2020. Array length is based on the number of contestants for 2020 from previous user input.
            int i;

            string[] names2020 = new string[entry2020];

            for (i = 0; i < names2020.Length; ++i)

            {
                Write($"Please enter contestant number {(i + 1)} name >>> ");
                names2020[i] = ReadLine();
            }

            string[] compCodes = new string[names2020.Length];


            // A second array has been created to capture talent codes for the named contestants.  Variables have also been created to count each time a specific code is entered.
            // If the code is invalid the user is prompted to enter a correct code.
            int countS = 0;
            int countD = 0;
            int countM = 0;
            int countO = 0;

            for (i = 0; i < compCodes.Length; ++i)

            {
                Write($"Please enter talent code S, D, M or O for contestant {(i + 1)} >>> ");
                compCodes[i] = ReadLine();

                switch (compCodes[i])
                {
                    case "S":
                        countS++;
                        break;

                    case "D":
                        countD++;

                        break;
                    case "M":
                        countM++;
                        break;

                    case "O":
                        countO++;
                        break;

                    default:
                        WriteLine("Invalid Code");
                        i--;
                        break;
                }

            }

            //The counted talent codes for each category are displayed below:
            WriteLine($"This year there are {countS} singer(s), {countD} dancer(s), {countM} musician(s), and {countO} other talent(s)");

            //The user can input a valid talent code to view all contestant names that have been assigned that code.
            //If the code is invalid the user is prompted to enter a correct code.
            //The user can quit the loop at any point with the sentinel value '!'.
            const string quit = "!";

            Write("Enter valid talent code for list of contestant names or press ! to Quit >>> ");
            string inputCode = ReadLine();

            while (inputCode != quit)
            {
                if (inputCode == "S" || inputCode == "D" || inputCode == "M" || inputCode == "O")
                {
                    for (i = 0; i < names2020.Length; i++)
                    {
                        if (compCodes[i] == inputCode)
                        {
                            WriteLine(names2020[i]);

                        }

                    }
                }

                else
                    WriteLine("Please enter a valid code (S, D, M, O)");

                Write("Enter talent code or press ! to Quit >>> ");
                inputCode = ReadLine();
            }

        }
    }
}