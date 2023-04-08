using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class ChessTests
    {
        [TestMethod]
        public void ChessPlacementTests() 
        {
            Chessboard chessboard = new Chessboard();

            Bishop bishop = new Bishop(ColorEnum.White);

            chessboard.GetField(0, 0).AddChess(bishop);

            Assert.AreEqual(chessboard.GetField(0, 0).Chess, bishop);

            chessboard.GetField(0, 0).RemoveChess();

            Assert.AreEqual(chessboard.GetField(0, 0).Chess, null);
        }

        [TestMethod]
        public void BishopAllowedPositionsTest()
        {
            Chessboard chessboard = new Chessboard();

            Bishop bishop = new Bishop(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            chessboard.GetField(0, 0).AddChess(bishop);

            List<Field> AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            chessboard.GetField(7, 0).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));

            chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            chessboard.GetField(0, 7).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));

            chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            chessboard.GetField(7, 7).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));

            chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            chessboard.GetField(3, 0).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));

            chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            chessboard.GetField(0, 3).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));

            chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            chessboard.GetField(3, 7).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));

            chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            chessboard.GetField(7, 3).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));

            chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            chessboard.GetField(3, 3).AddChess(bishop);

            AvailablePositions = bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void KnightAllowedPositionsTest()
        {
            Chessboard chessboard = new Chessboard();

            Knight knight = new Knight(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            chessboard.GetField(0, 0).AddChess(knight);

            List<Field> AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));

            chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            chessboard.GetField(7, 0).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 2)));

            chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            chessboard.GetField(0, 7).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 6)));

            chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            chessboard.GetField(7, 7).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 6)));

            chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            chessboard.GetField(3, 0).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 1)));

            chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            chessboard.GetField(0, 3).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 5)));

            chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            chessboard.GetField(3, 7).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 6)));

            chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            chessboard.GetField(7, 3).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 5)));

            chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            chessboard.GetField(3, 3).AddChess(knight);

            AvailablePositions = knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 4)));

            chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void RookAllowedPositionsTest()
        {
            Chessboard chessboard = new Chessboard();

            Rook rook = new Rook(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            chessboard.GetField(0, 0).AddChess(rook);

            List<Field> AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));

            chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            chessboard.GetField(7, 0).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            chessboard.GetField(0, 7).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            chessboard.GetField(7, 7).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));

            chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            chessboard.GetField(3, 0).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));

            chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            chessboard.GetField(0, 3).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));

            chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            chessboard.GetField(3, 7).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            chessboard.GetField(7, 3).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            chessboard.GetField(3, 3).AddChess(rook);

            AvailablePositions = rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));

            chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void QueenAllowedPositionsTest()
        {
            Chessboard chessboard = new Chessboard();

            Queen queen = new Queen(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            chessboard.GetField(0, 0).AddChess(queen);

            List<Field> AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            chessboard.GetField(7, 0).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));

            chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            chessboard.GetField(0, 7).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 6)));

            chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            chessboard.GetField(7, 7).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));

            chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            chessboard.GetField(3, 0).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));

            chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            chessboard.GetField(0, 3).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));

            chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            chessboard.GetField(3, 7).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));

            chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            chessboard.GetField(7, 3).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));

            chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            chessboard.GetField(3, 3).AddChess(queen);

            AvailablePositions = queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 7)));

            chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void KingAllowedPositionsTest()
        {
            Chessboard chessboard = new Chessboard();

            King king = new King(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            chessboard.GetField(0, 0).AddChess(king);

            List<Field> AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 1)));

            chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            chessboard.GetField(7, 0).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 1)));

            chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            chessboard.GetField(0, 7).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 7)));

            chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            chessboard.GetField(7, 7).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 7)));

            chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            chessboard.GetField(3, 0).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 1)));

            chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            chessboard.GetField(0, 3).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(1, 4)));

            chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            chessboard.GetField(3, 7).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 6)));

            chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            chessboard.GetField(7, 3).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(6, 4)));

            chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            chessboard.GetField(3, 3).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(chessboard.GetField(4, 4)));

            chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void PawnAllowedPositionsTest()
        {
            // ------ LEFT UP CORNER ------
            // ------ RIGHT UP CORNER ------
            // ------ LEFT DOWN CORNER ------
            // ------ RIGHT DOWN CORNER ------
            // ------ TOP BORDER CENTER ------
            // ------ LEFT BORDER CENTER ------
            // ------ DOWN BORDER CENTER ------
            // ------ RIGHT BORDER CENTER ------
            // ------ CENTER ------
        }
    }
}