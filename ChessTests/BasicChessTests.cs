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