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

        public Dictionary<string, FigureSet> FigureSets;

        private int MoveNumber = 0;

        private int PassantClearMove = 3;

        public bool IsWhiteMove = true;

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

        /// <summary>
        ///     Fill empty board with defined sets.
        /// </summary>
        private void InitializeChessboard()
        {
            foreach (FigureSet Set in this.FigureSets.Values)
            {
                Set.PlaceFiguresOnBoard(this);
            }
        }

        /// <summary>
        ///     Remove all figures from the board.
        /// </summary>
        private void ClearChessboard()
        {
            foreach (Field Field in this.Fields)
            {
                if (!Field.IsEmpty())
                    Field.RemoveChess();
            }
        }

        /// <summary>
        ///     Check if specified position is within the boundaries of the board.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Inside or outside as boolean</returns>
        public bool IsPositionInBounds(int x, int y)
        {
            return x >= 0 && x < WIDTH && y >= 0 && y < HEIGHT;
        }

        /// <summary>
        ///     Get field from board using x,y coordinates.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
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
                bool IsMoveEnPassant = this.HandleEnPassant(First, Second);
                ColorEnum? CastleColor = this.HandleCastle(First, Second);

                this.HistoryManager.RegisterMove(First, Second, IsMoveEnPassant, CastleColor);                

                if (CastleColor is null)
                {
                    Second.AddChess(ChessToMove);

                    First.RemoveChess();
                }

                if (this.PassantClearMove == this.MoveNumber)
                {
                    this.ClearEnPassantable();
                    this.PassantClearMove = this.MoveNumber + 1;
                }

                ChessToMove.MoveEvent(First, Second);

                this.MoveNumber++;

                if (this.CheckIfKingIsBeingChecked(ColorEnum.White))
                {
                    this.HistoryManager.RegisterKingCheck(ColorEnum.White);
                }
                else if (this.CheckIfKingIsBeingChecked(ColorEnum.Black))
                {
                    this.HistoryManager.RegisterKingCheck(ColorEnum.Black);
                }

                this.IsWhiteMove = !this.IsWhiteMove;
            }
        }

        /// <summary>
        ///     Check if move was castle and perform operations accordingly to chess's rules.
        /// </summary>
        /// <param name="First">Move from field</param>
        /// <param name="Second">Move to field</param>
        /// <returns>Color of castled king or null</returns>
        private ColorEnum? HandleCastle(Field First, Field Second)
        {
            if (First.Chess is King && Second.Chess is Rook)
            {
                Dictionary<string, List<Tuple<int, int>>> Placement =
                    this.FigureSets[First.Chess.Color == ColorEnum.White ? "White" : "Black"].GetCastleFields(First.Chess.Color);
                
                Tuple<int, int> KingPosition = Placement["KingField"].First();
                Field KingField = this.GetField(KingPosition.Item1, KingPosition.Item2);

                // Kingside castle
                if (Second.PosX - First.PosX == 3)
                {
                    Tuple<int, int> KingsideRook = Placement["KingsideRook"].First();
                    Field KingsideRookField = this.GetField(KingsideRook.Item1, KingsideRook.Item2);

                    Field KingTo = this.GetField(KingField.PosX + 2, KingField.PosY);
                    Field RookTo = this.GetField(KingField.PosX + 1, KingField.PosY);

                    KingTo.AddChess(KingField.Chess);
                    KingField.RemoveChess();
                    RookTo.AddChess(KingsideRookField.Chess);
                    KingsideRookField.RemoveChess();

                    return KingTo.Chess.Color;
                }

                // Quenside castle
                else if (Second.PosX - First.PosX == -4)
                {
                    Tuple<int, int> QueensideRook = Placement["QueensideRook"].First();
                    Field QueensideRookField = this.GetField(QueensideRook.Item1, QueensideRook.Item2);

                    Field KingTo = this.GetField(KingField.PosX - 2, KingField.PosY);
                    Field RookTo = this.GetField(KingField.PosX - 1, KingField.PosY);

                    KingTo.AddChess(KingField.Chess);
                    KingField.RemoveChess();
                    RookTo.AddChess(QueensideRookField.Chess);
                    QueensideRookField.RemoveChess();

                    return KingTo.Chess.Color;
                }
            }

            return null;
        }

        /// <summary>
        ///     Check if move was en passant and perform operations accordingly to chess's rules.
        /// </summary>
        /// <param name="First">Move from field</param>
        /// <param name="Second">Move to field</param>
        /// <returns>Bool if passant move happened</returns>
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

        /// <summary>
        ///     Clear the ability to use a en passant move.
        /// </summary>
        private void ClearEnPassantable()
        {
            foreach (Field Field in this.Fields)
                if (!Field.IsEmpty())
                    if (Field.Chess is Pawn)
                        ((Pawn)Field.Chess).EnPassantable = false;
        }

        /// <summary>
        ///     Check if king is being checked.
        /// </summary>
        /// <param name="Color">Color of king to check</param>
        /// <returns>bool</returns>
        private bool CheckIfKingIsBeingChecked(ColorEnum Color)
        {
            King King = this.GetSpecificKing(Color);

            if (King is null)
                return false;

            return this.IsFieldBeingAttacked(King.Field, King.Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White);
        }

        /// <summary>
        ///     Check if king is being check-mated.
        /// </summary>
        /// <param name="Color">Color of king to check</param>
        /// <returns>bool</returns>
        public bool CheckIfKingIsCheckmated(ColorEnum Color) 
        {
            Dictionary<IChess, List<Field>> Fields = this.GetLegalMovesForPlayer(Color);

            bool IsCheckmate = true;

            foreach (KeyValuePair<IChess, List<Field>> Position in Fields)
            {
                IChess SuspectedDefender = Position.Key;
                Field InitialDefenderField = SuspectedDefender.Field;

                foreach (Field MoveToField in Position.Value)
                {
                    IChess? MoveToChess = MoveToField.Chess;

                    MoveToField.RemoveChess();
                    MoveToField.AddChess(SuspectedDefender);

                    InitialDefenderField.RemoveChess();

                    bool temp = this.CheckIfKingIsBeingChecked(Color);

                    MoveToField.RemoveChess();
                    InitialDefenderField.AddChess(SuspectedDefender);

                    if (MoveToChess is not null)
                        MoveToField.AddChess(MoveToChess);

                    if (!temp)
                        IsCheckmate = false;
                }
            }

            return IsCheckmate;
        }

        /// <summary>
        ///     Returns king of specified color if present.
        /// </summary>
        /// <param name="Color">Color of king to return</param>
        /// <returns>King reference or null</returns>
        private King? GetSpecificKing(ColorEnum Color)
        {
            foreach (Field Field in this.Fields)
                if (!Field.IsEmpty() && Field.Chess is King && Field.Chess.Color == Color)
                    return (King)Field.Chess;

            return null;
        }

        /// <summary>
        ///     Check if certain field if being attacked by figures of specified color.
        /// </summary>
        /// <param name="SuspectedField">Field to check</param>
        /// <param name="Color">Color of attacking figures</param>
        /// <returns>bool</returns>
        public bool IsFieldBeingAttacked(Field SuspectedField, ColorEnum Color)
        {
            foreach(Field Field in this.Fields)
            {
                if (!Field.IsEmpty() && Field.Chess is not King)
                {
                    List<Field> List = Field.Chess.GetAvailablePositions();

                    if (Field.Chess is Pawn)
                    {
                        int Direction = Color == ColorEnum.White ? -1 : 1;

                        if (IsPositionInBounds(Field.PosX - 1, Field.PosY + (1 * Direction)))
                        {
                            Field LeftField = Field.Board.GetField(Field.PosX - 1, Field.PosY + (1 * Direction));

                            if (!List.Contains(LeftField))
                                List.Add(LeftField);
                        }

                        if (IsPositionInBounds(Field.PosX + 1, Field.PosY + (1 * Direction)))
                        {
                            Field RightField = Field.Board.GetField(Field.PosX + 1, Field.PosY + (1 * Direction));

                            if (!List.Contains(RightField))
                                List.Add(RightField);
                        }

                        if (this.IsPositionInBounds(Field.PosX, Field.PosY + Direction))
                        {
                            Field FieldAhead = this.GetField(Field.PosX, Field.PosY + Direction);

                            if (List.Contains(FieldAhead))
                                List.Remove(FieldAhead);                        
                        }
                    }

                    if (Field.Chess.Color == Color && List.Contains(SuspectedField))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Check if move was performed diagonally.
        /// </summary>
        /// <param name="First">Move from field</param>
        /// <param name="Second">Move to field</param>
        /// <returns>bool</returns>
        private bool IsDiagonalMove(Field First, Field Second)
        {
            int LenghtX = Math.Abs(Second.PosX - First.PosX);
            int LenghtY = Math.Abs(Second.PosY - Second.PosX);

            return LenghtX == LenghtY;
        }

        /// <summary>
        ///     Returns list of fields that can be used to promote Pawn for given color.
        /// </summary>
        /// <param name="Color">Promotion color</param>
        /// <returns>list of fields</returns>
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

        /// <summary>
        ///     Returns all legal moves for player of given color. Goes through all pieces that player
        ///     has placed on the board.
        /// </summary>
        /// <param name="Color">Color of player</param>
        /// <returns>Legal moves</returns>
        public Dictionary<IChess, List<Field>> GetLegalMovesForPlayer(ColorEnum Color)
        {
            Dictionary<IChess, List<Field>> LegalMovesForPlayer = new Dictionary<IChess, List<Field>>();
            List<Field> Positions = new List<Field>();

            foreach (Field Field in this.Fields)
            {
                if (!Field.IsEmpty() && Field.Chess.Color == Color)
                {
                    foreach (Field f in Field.Chess.GetAvailablePositions())
                    {
                        Positions.Add(f);
                    }
                    LegalMovesForPlayer.Add(Field.Chess, Positions);
                }
            }

            return LegalMovesForPlayer;
        }

        /// <summary>
        ///     Promote pawn placed on specified field into chosen option.
        /// </summary>
        /// <param name="PromotionField">Specified field to promote</param>
        /// <param name="PromotionChoice">Figure of choice</param>
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
