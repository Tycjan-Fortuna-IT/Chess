using Chess.Models.History;

namespace Chess.Models
{
    public class Chessboard : IBoard
    {
        public static readonly int WIDTH = 8;

        public static readonly int HEIGHT = 8;

        private static readonly int AMOUNT_OF_FIELDS = WIDTH * HEIGHT;

        public string Uuid { get; }

        private Field[] Fields = new Field[AMOUNT_OF_FIELDS];

        public HistoryManager HistoryManager = new HistoryManager();

        private ISerializer Serializer;

        private Dictionary<string, FigureSet> FigureSet;

        public Chessboard(Dictionary<string, FigureSet> FigureSet)
        {
            this.Uuid = Guid.NewGuid().ToString();
            this.Fields = new Field[AMOUNT_OF_FIELDS];

            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                this.Fields[i] = new Field(this, i % WIDTH, i / HEIGHT);
            }

            this.Serializer = new XMLSerializer();
            this.FigureSet = FigureSet;

            this.InitializeChessboard();
        }

        private void InitializeChessboard()
        {
            foreach (FigureSet Set in FigureSet.Values)
            {
                Set.PlaceFiguresOnBoard(this);
            }
        }

        private void ClearChessboard()
        {
            foreach (Field Field in this.Fields)
            {
                if (!Field.IsEmpty())
                    Field.RemoveChess();
            }
        }

        /// <summary>
        ///     Just for the sake of debugging. Prints the board in console terminal.
        /// </summary>
        [Obsolete]
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

        /// <summary>
        ///     Move IChess from one Field to second Field if it is allowed.
        /// </summary>
        /// <param name="First">First Field from which we want to move</param>
        /// <param name="Second">Second Field to which we want to move</param>
        public void MoveFromFieldToField(Field First, Field Second)
        {
            IChess ChessToMove = First.Chess;

            List<Field> FieldsToMove = ChessToMove.GetAvailablePositions();

            if (FieldsToMove.Contains(Second))
            {
                HistoryManager.RegisterMove(First, Second);

                Second.AddChess(ChessToMove);

                First.RemoveChess();
            }
        }

        /// <summary>
        ///     Save current state of the Chessboard into serializer's storage. All moves will be saved.
        /// </summary>
        /// <param name="path">Path to file where state of the Chessboard should be saved</param>
        public void Save(string path)
        {
            this.Serializer.Save(this, path);
        }

        /// <summary>
        ///     Load saved state of the Chessboard.
        /// </summary>
        /// <param name="path">Path to save file</param>
        public void Load(string path)
        {
            this.ClearChessboard();

            this.InitializeChessboard();
            
            this.Serializer.Load(this, path);
        }
    }
}
