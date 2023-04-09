namespace Chess.Models
{
    public class DefaultFigureSet : IFigureSet
    {
        public void Generate(Chessboard Chessboard, List<IChess> Figures, ColorEnum Color)
        {
            if (Color == ColorEnum.White)
            {
                // ------ ADDING ROOKS ------
                Rook RookLeft = new Rook(Color);
                Rook RookRight = new Rook(Color);

                Figures.Add(RookLeft);
                Figures.Add(RookRight);

                Chessboard.GetField(0, 7).AddChess(RookLeft);
                Chessboard.GetField(7, 7).AddChess(RookRight);

                // ------ ADDING KNIGHTS ------
                Knight KnightLeft = new Knight(Color);
                Knight KnightRight = new Knight(Color);

                Figures.Add(KnightLeft);
                Figures.Add(KnightRight);

                Chessboard.GetField(1, 7).AddChess(KnightLeft);
                Chessboard.GetField(6, 7).AddChess(KnightRight);

                // ------ ADDING BISHOPS ------
                Bishop BishopLeft = new Bishop(Color);
                Bishop BishopRight = new Bishop(Color);

                Figures.Add(BishopLeft);
                Figures.Add(BishopRight);

                Chessboard.GetField(2, 7).AddChess(BishopLeft);
                Chessboard.GetField(5, 7).AddChess(BishopRight);

                // ------ ADDING QUEEN ------
                Queen Queen = new Queen(Color);

                Figures.Add(Queen);

                Chessboard.GetField(3, 7).AddChess(Queen);

                // ------ ADDING KING ------
                King King = new King(Color);

                Figures.Add(King);

                Chessboard.GetField(4, 7).AddChess(King);

                // ------ ADDING PAWNS ------
                Pawn Pawn1 = new Pawn(Color);
                Pawn Pawn2 = new Pawn(Color);
                Pawn Pawn3 = new Pawn(Color);
                Pawn Pawn4 = new Pawn(Color);
                Pawn Pawn5 = new Pawn(Color);
                Pawn Pawn6 = new Pawn(Color);
                Pawn Pawn7 = new Pawn(Color);
                Pawn Pawn8 = new Pawn(Color);

                Figures.Add(Pawn1);
                Figures.Add(Pawn2);
                Figures.Add(Pawn3);
                Figures.Add(Pawn4);
                Figures.Add(Pawn5);
                Figures.Add(Pawn6);
                Figures.Add(Pawn7);
                Figures.Add(Pawn8);

                Chessboard.GetField(0, 6).AddChess(Pawn1);
                Chessboard.GetField(1, 6).AddChess(Pawn2);
                Chessboard.GetField(2, 6).AddChess(Pawn3);
                Chessboard.GetField(3, 6).AddChess(Pawn4);
                Chessboard.GetField(4, 6).AddChess(Pawn5);
                Chessboard.GetField(5, 6).AddChess(Pawn6);
                Chessboard.GetField(6, 6).AddChess(Pawn6);
                Chessboard.GetField(7, 6).AddChess(Pawn8);
            }
            else
            {
                // ------ ADDING ROOKS ------
                Rook RookLeft = new Rook(Color);
                Rook RookRight = new Rook(Color);

                Figures.Add(RookLeft);
                Figures.Add(RookRight);

                Chessboard.GetField(0, 0).AddChess(RookLeft);
                Chessboard.GetField(7, 0).AddChess(RookRight);

                // ------ ADDING KNIGHTS ------
                Knight KnightLeft = new Knight(Color);
                Knight KnightRight = new Knight(Color);

                Figures.Add(KnightLeft);
                Figures.Add(KnightRight);

                Chessboard.GetField(1, 0).AddChess(KnightLeft);
                Chessboard.GetField(6, 0).AddChess(KnightRight);

                // ------ ADDING BISHOPS ------
                Bishop BishopLeft = new Bishop(Color);
                Bishop BishopRight = new Bishop(Color);

                Figures.Add(BishopLeft);
                Figures.Add(BishopRight);

                Chessboard.GetField(2, 0).AddChess(BishopLeft);
                Chessboard.GetField(5, 0).AddChess(BishopRight);

                // ------ ADDING QUEEN ------
                Queen Queen = new Queen(Color);

                Figures.Add(Queen);

                Chessboard.GetField(3, 0).AddChess(Queen);

                // ------ ADDING KING ------
                King King = new King(Color);

                Figures.Add(King);

                Chessboard.GetField(4, 0).AddChess(King);

                // ------ ADDING PAWNS ------
                Pawn Pawn1 = new Pawn(Color);
                Pawn Pawn2 = new Pawn(Color);
                Pawn Pawn3 = new Pawn(Color);
                Pawn Pawn4 = new Pawn(Color);
                Pawn Pawn5 = new Pawn(Color);
                Pawn Pawn6 = new Pawn(Color);
                Pawn Pawn7 = new Pawn(Color);
                Pawn Pawn8 = new Pawn(Color);

                Figures.Add(Pawn1);
                Figures.Add(Pawn2);
                Figures.Add(Pawn3);
                Figures.Add(Pawn4);
                Figures.Add(Pawn5);
                Figures.Add(Pawn6);
                Figures.Add(Pawn7);
                Figures.Add(Pawn8);

                Chessboard.GetField(0, 1).AddChess(Pawn1);
                Chessboard.GetField(1, 1).AddChess(Pawn2);
                Chessboard.GetField(2, 1).AddChess(Pawn3);
                Chessboard.GetField(3, 1).AddChess(Pawn4);
                Chessboard.GetField(4, 1).AddChess(Pawn5);
                Chessboard.GetField(5, 1).AddChess(Pawn6);
                Chessboard.GetField(6, 1).AddChess(Pawn6);
                Chessboard.GetField(7, 1).AddChess(Pawn8);
            }
        }
    }
}
