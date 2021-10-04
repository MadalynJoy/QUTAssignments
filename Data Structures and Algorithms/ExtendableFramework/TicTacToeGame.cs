using static System.Console;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace ExtendableFramework
{
    public class TicTacToeGame : IGame
    {
        public char[,] Board;
        private const int BOARD_SIZE = 3;
        char FLD_EMPTY = ' ';

        // List for storing history of moves
        public List<int> MoveHistory { get; set; }

        // Set player markers
        public char GetPlayer1Marker()
        {
            return 'X';
        }

        public char GetPlayer2Marker()
        {
            return 'O';
        }

        // Set board size
        public TicTacToeGame()
        {
            Board = new char[BOARD_SIZE, BOARD_SIZE];
            InitialiseBoard();
        }

        // Initialise the board 
        public void InitialiseBoard()
        {
            MoveHistory = new List<int>();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Board[i, j] = FLD_EMPTY;
                }
            }
        }

        // Create the board
        public void PrintBoard()
        {
            const int ASCII_CODE_0 = 48;
            int fieldNumber = 1;
            WriteLine("-----");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (Board[i, j] == FLD_EMPTY)
                        Write((char)(ASCII_CODE_0 + fieldNumber));
                    else
                        Write(Board[i, j]);
                    fieldNumber++;

                    if (j < BOARD_SIZE - 1)
                    {
                        Write("|");
                    }
                }
                Write("\n");
            }
            WriteLine("-----");
        }

        // Set the square on the grid where the marker will be placed
        public void SetSquare(int fieldNumber, char marker)
        {
            int verticalY = (fieldNumber - 1) / 3;
            int horizontalX = (fieldNumber - 1) % 3;
            Board[verticalY, horizontalX] = marker;
        }

        // Player places their marker on the grid if valid
        public bool IsValidMove(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / 3;
            int horizontalX = (fieldNumber - 1) % 3;
            if (Board[verticalY, horizontalX] == FLD_EMPTY)
            {
                MoveHistory.Add(fieldNumber);
                return true;
            }

            else
            {
                return false;
            }
        }

        // Clears board
        public void ClearBoard()
        {
            Clear();
        }

        // Checks all rows to determine if a win has occurred
        private bool CheckRowsForWin()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (CheckRowCol(Board[i, 0], Board[i, 1], Board[i, 2]))
                    return true;
            }
            return false;
        }

        // Checks all columns to determine if a win has occurred
        private bool CheckColumnsForWin()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (CheckRowCol(Board[0, i], Board[1, i], Board[2, i]))
                    return true;
            }
            return false;
        }

        // Checks diagonals to determine if a win has occurred
        private bool CheckDiagonalsForWin()
        {
            return ((CheckRowCol(Board[0, 0], Board[1, 1], Board[2, 2]) == true) || (CheckRowCol(Board[0, 2], Board[1, 1], Board[2, 0]) == true));
        }

        // Checks to see if all three markers are the same for a win

        private bool CheckRowCol(char c1, char c2, char c3)
        {

            return (c1 != FLD_EMPTY) && (c1 == c2) && (c2 == c3);
        }

        // Checks for if a win condition has occurred
        public bool CheckWin()
        {
            return (CheckRowsForWin() || CheckColumnsForWin() || CheckDiagonalsForWin());
        }

        // returns the total number of squares/fields on the board
        public int getTotalSquares()
        {
            return BOARD_SIZE * BOARD_SIZE;
        }

        // Displays the in-game menu
        public string GameMenu()
        {
            string menuInputTTT;


            WriteLine("To play Human vs Human enter 1");
            WriteLine("To play Human vs Computer enter 2");
            WriteLine("To load a saved game enter 3");
            WriteLine("To get help enter H");
            menuInputTTT = ReadLine();
            if (menuInputTTT.ToLower() == "h")
            {
                WebsiteHelp();
                GameMenu();
            }
            return menuInputTTT;

        }

        // Loads HTML file for primitive web page
        private void WebsiteHelp()
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@".\index.html")
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }
}