using System.Collections.Generic;

namespace ExtendableFramework
{
    public interface IGame
    {
        void InitialiseBoard();

        void PrintBoard();

        bool IsValidMove(Player player, int fieldNumber);

        void ClearBoard();

        bool CheckWin();

        void SetSquare(int fieldNumber, char marker);

        int getTotalSquares();

        char GetPlayer1Marker();

        char GetPlayer2Marker();

        string GameMenu();

        List<int> MoveHistory { get; set; }
    }
}
