namespace Chess.Models
{
    public class Chessboard
    {
        private static readonly short WIDTH = 8;

        private static readonly short HEIGHT = 8;

        private static readonly int AMOUNT_OF_FIELDS = WIDTH * HEIGHT;

        public string Uuid { get; }

        public Field[] Fields = new Field[AMOUNT_OF_FIELDS];

        public Chessboard()
        {
            this.Uuid = Guid.NewGuid().ToString();
            this.Fields = new Field[AMOUNT_OF_FIELDS];

            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                this.Fields[i] = new Field();
            }
        }

        public void Display()
        {
            System.Console.WriteLine("12");

            foreach (var field in this.Fields) 
                System.Console.WriteLine(field.ToString());
        }

        public bool IsPositionInBounds(int x, int y)
        {
            return x >= 0 && x < WIDTH && y >= 0 && y < HEIGHT;
        }
    }
}
