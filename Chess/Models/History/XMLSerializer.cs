using System.Xml;

namespace Chess.Models
{
    public class XMLSerializer : ISerializer
    {
        /// <summary>
        ///     Save current state of the Chessboard into XML file. All moves will be saved.
        /// </summary>
        /// <param name="Board">Reference to the main Chessboard from which we take move history</param>
        /// <param name="path">Path to where the data should saved</param>
        public void Save(Chessboard Board, string path)
        {
            // Create a new XML document
            XmlDocument Document = new XmlDocument();

            // Create an XML declaration
            XmlDeclaration declaration = Document.CreateXmlDeclaration("1.0", "UTF-8", null);
            Document.AppendChild(declaration);

            // Create a root element
            XmlElement Root = Document.CreateElement("Chessboard");
            Document.AppendChild(Root);

            XmlElement BoardUuid = Document.CreateElement("Uuid");
            Root.AppendChild(BoardUuid);

            DateTime now = DateTime.Now;

            #region Date

            XmlElement Date = Document.CreateElement("Date");
            Root.AppendChild(Date);

            Date.InnerText = now.ToUniversalTime().ToString();

            #endregion Date

            #region SizeElement
            XmlElement Size = Document.CreateElement("Size");
            Root.AppendChild(Size);

            XmlElement SizeWidth = Document.CreateElement("SizeWidth");
            Size.AppendChild(SizeWidth);

            SizeWidth.InnerText = Chessboard.WIDTH.ToString();

            XmlElement SizeHeight = Document.CreateElement("SizeHeight");
            Size.AppendChild(SizeHeight);

            SizeHeight.InnerText = Chessboard.HEIGHT.ToString();

            #endregion SizeElement

            #region MoveHistory

            XmlElement History = Document.CreateElement("History");
            Root.AppendChild(History);

            foreach (Move m in Board.HistoryManager.Moves)
            {
                XmlElement Move = Document.CreateElement("Move");
                History.AppendChild(Move);

                //Move.SetAttribute("Moved", m.MovedChess);
                Move.SetAttribute("FromX", m.FromField.Item1.ToString());
                Move.SetAttribute("FromY", m.FromField.Item2.ToString());
                Move.SetAttribute("ToX", m.ToField.Item1.ToString());
                Move.SetAttribute("ToY", m.ToField.Item2.ToString());

                if (m.PromotionMove)
                {
                    Move.SetAttribute("Promotion", "true");
                    Move.SetAttribute("Color", m.MovedChessColor == ColorEnum.White ? "White" : "Black");
                    Move.SetAttribute("Choice", m.CapturedChessName);
                }

                //if (m.CapturedChessName is not null)
                //{
                //    Move.SetAttribute("Captured", m.CapturedChessName);
                //    Move.SetAttribute("Color", Enum.GetName(typeof(ColorEnum), m.CapturedChessColor));
                //}
            }

            #endregion MoveHistory

            BoardUuid.InnerText = Board.Uuid;

            Document.Save(path);
        }

        /// <summary>
        ///     Load saved state of the Chessboard from XML file. All moves will be recreated.
        /// </summary>
        /// <param name="Board">Reference to the main Chessboard for which we will recreate moves</param>
        /// <param name="path">Path from where the data should be loaded</param>
        public void Load(Chessboard Board, string path)
        {
            XmlDocument Document = new XmlDocument();
            Document.Load(path);

            XmlNode HistoryNode = Document.SelectSingleNode("//History");

            foreach (XmlNode moveNode in HistoryNode.ChildNodes)
            {
                //string moved = moveNode.Attributes["Moved"].Value;
                int FromX = int.Parse(moveNode.Attributes["FromX"].Value);
                int FromY = int.Parse(moveNode.Attributes["FromY"].Value);
                int ToX = int.Parse(moveNode.Attributes["ToX"].Value);
                int ToY = int.Parse(moveNode.Attributes["ToY"].Value);
                //string? captured = moveNode.Attributes["Captured"].Value;

                if (moveNode.Attributes["Promotion"] is not null)
                {
                    ColorEnum Color = moveNode.Attributes["Color"].Value == "White" ? ColorEnum.White : ColorEnum.Black;
                    IChess Chess = new Queen(Color);

                    switch(moveNode.Attributes["Choice"].Value)
                    {
                        case "Rook":
                            Chess = new Rook(Color); break;
                        case "Knight":
                            Chess = new Knight(Color); break;
                        case "Bishop":
                            Chess = new Bishop(Color); break;
                    }

                    Board.PromoteChessTo(Board.GetField(FromX, FromY), Chess);
                }
                else
                {
                    Board.MoveFromFieldToField(Board.GetField(FromX, FromY), Board.GetField(ToX, ToY));
                }
            }
        }
    }
}
