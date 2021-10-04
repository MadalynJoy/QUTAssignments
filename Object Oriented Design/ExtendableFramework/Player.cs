namespace ExtendableFramework
{
    public abstract class Player
    {
        readonly char sign;

        public Player(char playerSign)
        {
            sign = playerSign;
        }

        // Assign player marker
        public char GetSign()
        {
            return sign;
        }

        public abstract int MakeMove(int maxSize);

    }
}