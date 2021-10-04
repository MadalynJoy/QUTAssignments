using System;
using System.IO;
using System.Text.Json;
using static System.Console;

namespace ExtendableFramework
{
    public class GameManager
    {
        IGame gameBoard;
        int player1Score = 0;
        int player2Score = 0;
        int moveCounter = 0;
        int drawCounter = 0;

        Player player1, player2, currentPlayer;

        public GameManager(IGame gameBoard)
        {
            this.gameBoard = gameBoard;
            InitialiseGame();
            SetupGame();    // Get Human or Computer
            StartGame();    // Initialise & reset gameboard
        }

        // Player makes a move
        public void TakePlayerTurn(Player player)
        {
            gameBoard.PrintBoard();
            WriteLine("Player: {0} Enter 1 - {1} to place your marker, or 99 to save the game and quit: ", player.GetSign(), gameBoard.getTotalSquares());
            int fieldNumber = player.MakeMove(gameBoard.getTotalSquares());

            // Check if the gamne should be saved
            if (fieldNumber == 99)
            {
                string jsonString = JsonSerializer.Serialize(gameBoard);

                // save to disk
                string fileName = "moveHistory.json";
                File.WriteAllText(fileName, jsonString);
                Environment.Exit(0);
            }

            // Checks that the player placement is valid or not
            if (gameBoard.IsValidMove(player, fieldNumber))
            {
                gameBoard.SetSquare(fieldNumber, player.GetSign());
                gameBoard.ClearBoard();
                moveCounter++;

            }
            else
            {
                WriteLine("Placement has already been used. Select another. ");
                TakePlayerTurn(player);
            }
        }

        // Display game menu
        public void GetsMenu()
        {
            gameBoard.GameMenu();
        }

        public void SetupGame()
        {
            // Opponent selection

            player1 = new HumanPlayer(gameBoard.GetPlayer1Marker());
            currentPlayer = player1;

            var menuSelection = gameBoard.GameMenu();

            // Player 2 selection
            if (menuSelection == "1")       // Human opponent
            {
                player2 = new HumanPlayer(gameBoard.GetPlayer2Marker());
            }
            else if (menuSelection == "2")  // Computer opponent
            {
                player2 = new ComputerPlayer(gameBoard.GetPlayer2Marker());
            }
            else if (menuSelection == "3")  // Load a saved game
            {
                // Loading games supports 2 human players
                player2 = new HumanPlayer(gameBoard.GetPlayer2Marker());

                string fileName = "moveHistory.json";
                string jsonString = File.ReadAllText(fileName);

                IGame loadingGameBoard = JsonSerializer.Deserialize<TicTacToeGame>(jsonString);
                foreach (var historyFieldNumber in loadingGameBoard.MoveHistory)
                {
                    gameBoard.SetSquare(historyFieldNumber, currentPlayer.GetSign());
                    currentPlayer = ChangeCurrentPlayer(currentPlayer, player1, player2);
                    moveCounter++;
                }
            }
        }

        public void InitialiseGame()
        {
            // Reset the game, ready to be played
            moveCounter = 0;
            gameBoard.InitialiseBoard();
            gameBoard.ClearBoard();
        }

        public void StartGame()
        {
            gameBoard.ClearBoard();
            bool play = true;

            // While the game has not ended, keep playing
            while (play)
            {
                // Players make move
                TakePlayerTurn(currentPlayer);

                //check for win
                if (gameBoard.CheckWin())
                {
                    Write("Player: {0} wins!", currentPlayer.GetSign());
                    WriteLine("");
                    gameBoard.PrintBoard();
                    play = false;
                }

                //check for draw
                else if (CheckDraw(moveCounter))
                {
                    Write("Draw");
                    WriteLine("");
                    gameBoard.PrintBoard();
                    play = false;
                }
                currentPlayer = ChangeCurrentPlayer(currentPlayer, player1, player2);
            }
            // Game has ended


            // Counts the wins for each player
            if (gameBoard.CheckWin() == false && CheckDraw(moveCounter) == true)
            {
                drawCounter += 1;
            }
            else if (currentPlayer != player1)
            {
                player1Score += 1;
            }
            else
            {
                player2Score += 1;
            }
            WriteLine($"SCORES: Player 1 = {player1Score} | Player 2 = {player2Score} | Draw = {drawCounter}");
            WriteLine("");


            //play again or quit
            string endOfGameOption;

            WriteLine("Enter Y to play again, M to return to menu, or enter any other key to quit");
            endOfGameOption = ReadLine();

            if (endOfGameOption.ToLower() == "y")
            {
                InitialiseGame();
                StartGame();
            }
            else
                Environment.Exit(0);

        }

        // To allow the change of player at the end of a turn
        private Player ChangeCurrentPlayer(Player currentPlayer, Player playerX, Player playerO)
        {
            if (currentPlayer == playerX)
                currentPlayer = playerO;
            else
                currentPlayer = playerX;
            return currentPlayer;
        }

        // If 9 turns have been taken and no winner, the game is a draw
        private bool CheckDraw(int turnCounter)
        {
            if (turnCounter == gameBoard.getTotalSquares())
                return true;
            return false;
        }
    }
}
