using Chess.Models;
using System.Collections.Generic;
using System.ComponentModel.Design;

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

        private Dictionary<string, FigureSet> FigureSets;

        private int MoveNumber = 0;

        private int PassantClearMove = 3;

        public Chessboard(Dictionary<string, FigureSet> FigureSets)
        {
            this.Uuid = Guid.NewGuid().ToString();
            this.Fields = new Field[AMOUNT_OF_FIELDS];

            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                this.Fields[i] = new Field(this, i % WIDTH, i / HEIGHT);
            }

            this.Serializer = new XMLSerializer();
            this.FigureSets = FigureSets;

            this.InitializeChessboard();
        }

        private void InitializeChessboard()
        {
            foreach (FigureSet Set in this.FigureSets.Values)
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
                HistoryManager.RegisterMove(First, Second, this.HandleEnPassant(First, Second));                

                Second.AddChess(ChessToMove);

                First.RemoveChess();

                if (this.PassantClearMove == this.MoveNumber)
                {
                    this.ClearEnPassantable();
                    this.PassantClearMove = this.MoveNumber + 1;
                }

                ChessToMove.MoveEvent(First, Second);

                this.MoveNumber++;
            }
        }

        private bool HandleEnPassant(Field First, Field Second)
        {
            if (First.Chess is Pawn && Second.IsEmpty())
            {
                if ((Second.PosX - First.PosX < 0) && (Second.PosY - First.PosY < 0))
                {
                    this.GetField(Second.PosX, Second.PosY + 1).RemoveChess();
                    return true;
                }
                if ((Second.PosX - First.PosX > 0) && (Second.PosY - First.PosY < 0))
                {
                    this.GetField(Second.PosX, Second.PosY + 1).RemoveChess();
                    return true;
                }
                if ((Second.PosX - First.PosX < 0) && (Second.PosY - First.PosY > 0))
                {
                    this.GetField(Second.PosX, Second.PosY - 1).RemoveChess();
                    return true;
                }
                if ((Second.PosX - First.PosX > 0) && (Second.PosY - First.PosY > 0))
                {
                    this.GetField(Second.PosX, Second.PosY - 1).RemoveChess();
                    return true;
                }
            }

            return false;
        }

        private void ClearEnPassantable()
        {
            foreach (Field Field in this.Fields)
                if (!Field.IsEmpty())
                    if (Field.Chess is Pawn)
                        ((Pawn)Field.Chess).EnPassantable = false;
        }

        private bool IsDiagonalMove(Field First, Field Second)
        {
            int LenghtX = Math.Abs(Second.PosX - First.PosX);
            int LenghtY = Math.Abs(Second.PosY - Second.PosX);

            return LenghtX == LenghtY;
        }

        public List<Field> GetFieldsForPromotion(ColorEnum Color)
        {
            List<Field> PromotionFields = new List<Field>();

            foreach (FigureSet FigureSet in this.FigureSets.Values)
            {
                foreach (Tuple<int, int> Cords in FigureSet.FigureSetPlacement.GetPromotionMap(Color))
                {
                    Field SuspectedField = this.GetField(Cords.Item1, Cords.Item2);

                    if (!SuspectedField.IsEmpty() && SuspectedField.Chess.Color != Color && SuspectedField.Chess is Pawn)
                        PromotionFields.Add(SuspectedField);
                }
            }

            return PromotionFields;
        }

        public void PromoteChessTo(Field PromotionField, IChess PromotionChoice)
        {
            if (this.GetFieldsForPromotion(PromotionChoice.Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White).Contains(PromotionField))
            {
                HistoryManager.RegisterPromotion(PromotionField, PromotionChoice);

                PromotionField.RemoveChess();

                PromotionField.AddChess(PromotionChoice);
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
