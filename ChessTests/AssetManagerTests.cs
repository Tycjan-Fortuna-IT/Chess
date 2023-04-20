using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class AssetManagerTests
    {
        [TestMethod]
        public void GetTextureByTagNameTest()
        {
            Assert.IsNotNull(AssetManager.GetTextureByTagName("BishopBlack"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("BishopBlackCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("BishopBlackPromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("BishopWhite"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("BishopWhiteCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("BishopWhitePromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KingBlack"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KingWhite"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("PawnBlack"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("PawnBlackCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("PawnWhite"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("PawnWhiteCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("QueenBlack"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("QueenBlackCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("QueenBlackPromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("QueenWhite"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("QueenWhiteCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("QueenWhitePromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KnightBlack"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KnightBlackCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KnightBlackPromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KnightWhite"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KnightWhiteCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("KnightWhitePromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("RookBlack"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("RookBlackCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("RookBlackPromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("RookWhite"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("RookWhiteCaptured"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("RookWhitePromotion"));
            Assert.IsNotNull(AssetManager.GetTextureByTagName("sadsd"));
        }
    }
}
