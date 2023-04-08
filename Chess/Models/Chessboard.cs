namespace Chess.Models
{
    public class Chessboard
    {
        public static readonly short WIDTH = 8;

        public static readonly short HEIGHT = 8;

        private static readonly int AMOUNT_OF_FIELDS = WIDTH * HEIGHT;

        public string Uuid { get; }

        private Field[] Fields = new Field[AMOUNT_OF_FIELDS];

        public Chessboard()
        {
            this.Uuid = Guid.NewGuid().ToString();
            this.Fields = new Field[AMOUNT_OF_FIELDS];

            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                this.Fields[i] = new Field(this, i % WIDTH, i / HEIGHT);
            }
        }

        public void Display()
        {
            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                if (i % WIDTH == 0 && i != 0)
                {
                    System.Console.WriteLine(' ');
                }

                this.Fields[i].Display();
            }
        }

        public bool IsPositionInBounds(int x, int y)
        {
            return x >= 0 && x < WIDTH && y >= 0 && y < HEIGHT;
        }

        public Field GetField(int x, int y)
        {
            return Fields[x + WIDTH * y];
        }
    }
}
