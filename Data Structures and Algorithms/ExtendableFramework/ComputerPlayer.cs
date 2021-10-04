using System;

namespace ExtendableFramework
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(char playerSign) : base(playerSign)
        {
        }

        // Computer player makes a random move (easy mode)
        public override int MakeMove(int maxSize)
        {
            Random _random = new Random();
            var randomNumber = _random.Next(1, maxSize + 1);

            return randomNumber;
        }

    }
}