using System.Xml;

namespace Chess.Models.History
{
    public class XMLSerializer : ISerializer
    {
        //private readonly string path;

        //private readonly string folder;

        //public XMLSerializer(string path, string folder)
        //{
        //    this.path = path;
        //    this.folder = folder;
        //}

        /// <summary>
        ///     Save current state of the Chessboard into XML file. All moves will be saved.
        /// </summary>
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

            //string Filename = now.Day + "." + now.Month + "." + now.Year + "_" + now.Hour + "." + now.Minute + "." + now.Second;

            // Save the XML document to a file in a folder within the solution
            //string filePath = Path.Combine(path, folder, Filename + ".xml");
            string filePath = Path.Combine(path);

            Document.Save(filePath);
        }
    }
}
