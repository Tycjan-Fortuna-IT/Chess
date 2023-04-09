using System.Xml;

namespace Chess.Models
{
    public class Chessboard
    {
        public static readonly int WIDTH = 8;

        public static readonly int HEIGHT = 8;

        private static readonly int AMOUNT_OF_FIELDS = WIDTH * HEIGHT;

        public string Uuid { get; }

        private Field[] Fields = new Field[AMOUNT_OF_FIELDS];

        public Chessboard()
        {
            this.Uuid = Guid.NewGuid().ToString();
            this.Fields = new Field[AMOUNT_OF_FIELDS];

            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                this.Fields[i] = new Field(this, i % WIDTH, i / HEIGHT);
            }
        }

        /// <summary>
        ///     Just for the sake of debugging. Prints the board in console terminal.
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < AMOUNT_OF_FIELDS; i++)
            {
                if (i % WIDTH == 0 && i != 0)
                {
                    System.Console.WriteLine(' ');
                }

                this.Fields[i].Display();
            }
        }

        public bool IsPositionInBounds(int x, int y)
        {
            return x >= 0 && x < WIDTH && y >= 0 && y < HEIGHT;
        }

        public Field GetField(int x, int y)
        {
            return Fields[x + WIDTH * y];
        }

        /// <summary>
        ///     Save current state of the Chessboard into XML file. All moves will be saved.
        /// </summary>
        public void SaveToXML()
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

            SizeWidth.InnerText = WIDTH.ToString();

            XmlElement SizeHeight = Document.CreateElement("SizeHeight");
            Size.AppendChild(SizeHeight);

            SizeHeight.InnerText = HEIGHT.ToString();

            #endregion SizeElement

            #region MoveHistory

            XmlElement History = Document.CreateElement("History");

            #endregion MoveHistory

            BoardUuid.InnerText = this.Uuid;

            string Filename = now.Day + "." + now.Month + "." + now.Year + "_" +  now.Hour + "." + now.Minute + "." + now.Second;

            // Save the XML document to a file in a folder within the solution
            string folderName = "History";
            string filePath = Path.Combine("../../../", folderName, Filename + ".xml");
            Document.Save(filePath);
        }
    }
}
