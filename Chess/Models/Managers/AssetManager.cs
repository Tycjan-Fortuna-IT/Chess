namespace Chess.Models
{
    public static class AssetManager
    {
        public static System.Drawing.Bitmap GetTextureByTagName(string Tag)
        {
            switch (Tag)
            {
                case "BishopBlack":
                    return Properties.Resources.BishopBlack;
                case "BishopBlackCaptured":
                    return Properties.Resources.BishopBlackCaptured;
                case "BishopWhite":
                    return Properties.Resources.BishopWhite;
                case "BishopWhiteCaptured":
                    return Properties.Resources.BishopWhiteCaptured;
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
                case "QueenWhite":
                    return Properties.Resources.QueenWhite;
                case "QueenWhiteCaptured":
                    return Properties.Resources.QueenWhiteCaptured;
                case "KnightBlack":
                    return Properties.Resources.KnightBlack;
                case "KnightBlackCaptured":
                    return Properties.Resources.KnightBlackCaptured;
                case "KnightWhite":
                    return Properties.Resources.KnightWhite;
                case "KnightWhiteCaptured":
                    return Properties.Resources.KnightWhiteCaptured;
                case "RookBlack":
                    return Properties.Resources.RookBlack;
                case "RookBlackCaptured":
                    return Properties.Resources.RookBlackCaptured;
                case "RookWhite":
                    return Properties.Resources.RookWhite;
                case "RookWhiteCaptured":
                    return Properties.Resources.RookWhiteCaptured;
                default:
                    return Properties.Resources.BishopBlack;
            }
        }
    }
}
