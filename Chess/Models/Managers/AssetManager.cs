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
                case "KingBlack":
                    return Properties.Resources.KingBlack;
                case "KingWhite":
                    return Properties.Resources.KingWhite;
                case "PawnBlack":
                    return Properties.Resources.PawnBlack;
                case "PawnWhite":
                    return Properties.Resources.PawnWhite;
                case "QueenBlack":
                    return Properties.Resources.QueenBlack;
                case "QueenWhite":
                    return Properties.Resources.QueenWhite;
                case "KnightBlack":
                    return Properties.Resources.KnightBlack;
                case "KnightWhite":
                    return Properties.Resources.KnightWhite;
                case "RookBlack":
                    return Properties.Resources.RookBlack;
                case "RookWhite":
                    return Properties.Resources.RookWhite;
                default:
                    return Properties.Resources.BishopBlack;
            }
        }
    }
}
