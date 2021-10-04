using System;
using static System.Console;

namespace ExtendableFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainMenuInput;
            // Menu to start selected game
            // for future extensions, each input would select a specific game
            WriteLine("Welcome to the Game Framework Application");
            WriteLine("Currently only Tic Tac Toe is available to play");
            Write("\n");
            WriteLine("Enter 1 for Tic Tac Toe or any other key to quit");
            mainMenuInput = ReadLine();
            if (mainMenuInput == "1")
            {
                GameManager game = new GameManager(new TicTacToeGame());
                ReadKey();
            }
            else
                Environment.Exit(0);
        }
    }
}