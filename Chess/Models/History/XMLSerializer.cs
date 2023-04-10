using System.Xml;

namespace Chess.Models.History
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

                XmlElement Moved = Document.CreateElement("Moved");
                Move.AppendChild(Moved);
                Moved.InnerText = m.MovedChess;

                XmlElement From = Document.CreateElement("From");
                Move.AppendChild(From);

                XmlElement FromX = Document.CreateElement("X");
                From.AppendChild(FromX);
                FromX.InnerText = m.FromField.Item1.ToString();

                XmlElement FromY = Document.CreateElement("Y");
                From.AppendChild(FromY);
                FromY.InnerText = m.FromField.Item2.ToString();

                XmlElement To = Document.CreateElement("To");
                Move.AppendChild(To);

                XmlElement ToX = Document.CreateElement("X");
                To.AppendChild(ToX);
                ToX.InnerText = m.ToField.Item1.ToString();

                XmlElement ToY = Document.CreateElement("Y");
                To.AppendChild(ToY);
                ToY.InnerText = m.ToField.Item2.ToString();

                if (m.CapturedChessName is not null)
                {
                    XmlElement Captured = Document.CreateElement("Captured");
                    Move.AppendChild(Captured);
                    Captured.InnerText = m.CapturedChessName;
                }
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

            XmlNodeList MovesHistory = Document.GetElementsByTagName("History");

            foreach (XmlNode History in MovesHistory)
            {
                foreach (XmlNode Child in History.ChildNodes)
                {
                    int counter = 0;

                    int FromX = -1;
                    int FromY = -1;
                    int ToX = -1;
                    int ToY = -1;

                    foreach (XmlNode ChildChild in Child.ChildNodes)
                    {
                        foreach(XmlNode Element in ChildChild.ChildNodes)
                        {
                            if (counter == 1)
                            {
                                FromX = Int32.Parse(Element.InnerText);
                            }
                            else if (counter == 2)
                            {
                                FromY = Int32.Parse(Element.InnerText);
                            }
                            else if (counter == 3)
                            {
                                ToX = Int32.Parse(Element.InnerText);
                            }
                            else if (counter == 4)
                            {
                                ToY = Int32.Parse(Element.InnerText);
                            }

                            counter++;
                        }
                    }

                    if (FromX > -1 && FromY > -1 && ToX > -1 && ToY > -1)
                    {
                        Board.MoveFromFieldToField(Board.GetField(FromX, FromY), Board.GetField(ToX, ToY));
                    }
                }
            }
        }
    }
}
