using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class PawnTests
    {
        Chessboard Chessboard = new Chessboard(new Dictionary<string, FigureSet>());
        
        [TestMethod]
        public void PawnMovementTest()
        {
            Pawn PawnWhite = new Pawn(ColorEnum.White);
            Pawn PawnBlack = new Pawn(ColorEnum.Black);

            // ------ LEFT UP CORNER ------
            Chessboard.GetField(0, 0).AddChess(PawnWhite);

            List<Field> AvailablePositions = PawnWhite.GetAvailablePositions();

            Assert.AreEqual(AvailablePositions.Count(), 0);

            Chessboard.GetField(0, 0).RemoveChess();

            Chessboard.GetField(0, 0).AddChess(PawnBlack);

            AvailablePositions = PawnBlack.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));

            Chessboard.GetField(0, 0).RemoveChess();
        }

        [TestMethod]
        public void PawnCaptureTest()
        {
            Pawn Pawn = new Pawn(ColorEnum.White);
            Pawn LeftPawn = new Pawn(ColorEnum.Black);
            Pawn RightPawn = new Pawn(ColorEnum.Black);

            Chessboard.GetField(2, 2).AddChess(Pawn);
            Chessboard.GetField(1, 0).AddChess(LeftPawn);
            Chessboard.GetField(3, 0).AddChess(RightPawn);

            Chessboard.MoveFromFieldToField(Chessboard.GetField(1, 0), Chessboard.GetField(1, 2));
            Chessboard.MoveFromFieldToField(Chessboard.GetField(3, 0), Chessboard.GetField(3, 2));

            List<Field> AvailablePositions = Pawn.GetAvailablePositions();

            // Passant capture
            Chessboard.MoveFromFieldToField(Chessboard.GetField(2, 2), Chessboard.GetField(1, 1));
        }

        [TestMethod]
        public void PawnEnPassantTest()
        {
            Pawn Pawn = new Pawn(ColorEnum.White);
            Pawn LeftPawn = new Pawn(ColorEnum.Black);
            Pawn RightPawn = new Pawn(ColorEnum.Black);

            Chessboard.GetField(2, 2).AddChess(Pawn);
            Chessboard.GetField(1, 1).AddChess(LeftPawn);
            Chessboard.GetField(3, 1).AddChess(RightPawn);

            List<Field> AvailablePositions = Pawn.GetAvailablePositions();
        }

        [TestMethod]
        public void PawnOtherMethodsTest()
        {
            Pawn Pawn = new Pawn(ColorEnum.Black);

            Assert.AreEqual("Pawn", Pawn.ToString());

            Field First = new Field(Chessboard, 0, 0);
            Field Second = new Field(Chessboard, 1, 2);

            Assert.AreEqual(false, Pawn.HasMoved);

            Pawn.MoveEvent(First, Second);

            Assert.AreEqual(true, Pawn.HasMoved);
        }
    }
}
