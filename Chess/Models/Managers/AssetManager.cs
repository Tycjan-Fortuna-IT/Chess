namespace Chess.Models
{
    public static class AssetManager
    {
        /// <summary>
        ///     Returns all needed textures.
        /// </summary>
        /// <param name="Tag">Tag of the texture</param>
        /// <returns>Texture as a bitmap</returns>
        public static System.Drawing.Bitmap GetTextureByTagName(string Tag)
        {
            switch (Tag)
            {
                case "BishopBlack":
                    return Properties.Resources.BishopBlack;
                case "BishopBlackCaptured":
                    return Properties.Resources.BishopBlackCaptured;
                case "BishopBlackPromotion":
                    return Properties.Resources.BishopBlackPromotion;
                case "BishopWhite":
                    return Properties.Resources.BishopWhite;
                case "BishopWhiteCaptured":
                    return Properties.Resources.BishopWhiteCaptured;
                case "BishopWhitePromotion":
                    return Properties.Resources.BishopWhitePromotion;
                case "KingBlack":
                    return Properties.Resources.KingBlack;
                case "KingWhite":
                    return Properties.Resources.KingWhite;
                case "PawnBlack":
                    return Properties.Resources.PawnBlack;
                case "PawnBlackCaptured":
                    return Properties.Resources.PawnBlackCaptured;
                case "PawnWhite":
                    return Properties.Resources.PawnWhite;
                case "PawnWhiteCaptured":
                    return Properties.Resources.PawnWhiteCaptured;
                case "QueenBlack":
                    return Properties.Resources.QueenBlack;
                case "QueenBlackCaptured":
                    return Properties.Resources.QueenBlackCaptured;
                case "QueenBlackPromotion":
                    return Properties.Resources.QueenBlackPromotion;
                case "QueenWhite":
                    return Properties.Resources.QueenWhite;
                case "QueenWhiteCaptured":
                    return Properties.Resources.QueenWhiteCaptured;
                case "QueenWhitePromotion":
                    return Properties.Resources.QueenWhitePromotion;
                case "KnightBlack":
                    return Properties.Resources.KnightBlack;
                case "KnightBlackCaptured":
                    return Properties.Resources.KnightBlackCaptured;
                case "KnightBlackPromotion":
                    return Properties.Resources.KnightBlackPromotion;
                case "KnightWhite":
                    return Properties.Resources.KnightWhite;
                case "KnightWhiteCaptured":
                    return Properties.Resources.KnightWhiteCaptured;
                case "KnightWhitePromotion":
                    return Properties.Resources.KnightWhitePromotion;
                case "RookBlack":
                    return Properties.Resources.RookBlack;
                case "RookBlackCaptured":
                    return Properties.Resources.RookBlackCaptured;
                case "RookBlackPromotion":
                    return Properties.Resources.RookBlackPromotion;
                case "RookWhite":
                    return Properties.Resources.RookWhite;
                case "RookWhiteCaptured":
                    return Properties.Resources.RookWhiteCaptured;
                case "RookWhitePromotion":
                    return Properties.Resources.RookWhitePromotion;
                default:
                    return Properties.Resources.BishopBlack;
            }
        }
    }
}
