using static System.Console;

namespace ExtendableFramework
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(char playerSign) : base(playerSign)
        {
        }

        // Human player manually enters move
        public override int MakeMove(int maxSize)
        {
            int fieldNumber = int.Parse(ReadLine());
            return fieldNumber;
        }
    }
}