using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class BasicChessTests
    {
        [TestMethod]
        public void ChessPlacementTests() 
        {
            Chessboard chessboard = new Chessboard(new Dictionary<string, FigureSet>());

            Bishop bishop = new Bishop(ColorEnum.White);

            chessboard.GetField(0, 0).AddChess(bishop);

            Assert.AreEqual(chessboard.GetField(0, 0).Chess, bishop);

            chessboard.GetField(0, 0).RemoveChess();

            Assert.AreEqual(chessboard.GetField(0, 0).Chess, null);
        }

        [TestMethod]
        public void KingAllowedPositionsTest()
        {
            Chessboard chessboard = new Chessboard(new Dictionary<string, FigureSet>());

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
        public void ProjectionTests()
        {
            Chessboard chessboard = new Chessboard(new Dictionary<string, FigureSet>());

            chessboard.GetField(1, 1).AddChess(new Bishop(ColorEnum.White));

            bool Test1 = chessboard.GetField(3, 3).CheckForProjectedObstacle(new Tuple<int, int>(-1, -1), ColorEnum.White, 3);
            bool Test2 = chessboard.GetField(3, 3).CheckForProjectedObstacle(new Tuple<int, int>(-1, -1), ColorEnum.White, 2);
            bool Test3 = chessboard.GetField(3, 3).CheckForProjectedObstacle(new Tuple<int, int>(-1, -1), ColorEnum.White, 1);
            bool Test4 = chessboard.GetField(3, 3).CheckForProjectedObstacle(new Tuple<int, int>(-1, -1), ColorEnum.White, 0);
            bool Test5 = chessboard.GetField(3, 3).CheckForProjectedObstacle(new Tuple<int, int>(-1, -1), ColorEnum.Black, 3);

            Assert.IsTrue(Test1);
            Assert.IsTrue(Test2);
            Assert.IsFalse(Test3);
            Assert.IsFalse(Test4);
            Assert.IsFalse(Test5);
        }
    }
}