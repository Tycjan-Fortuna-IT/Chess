using System.Xml;

namespace Chess.Models
{
    public class TXTParser
    {
        private List<string> lines = new List<string>();

        private List<Move> MovesToRegister = new List<Move>();

        /// <summary>
        ///     
        /// </summary>
        /// <param name="ReadPath"></param>
        /// <param name="WritePath"></param>
        public void ParseToXML(string ReadPath, string WritePath)
        {
            using (StreamReader reader = new StreamReader(ReadPath))
            {
                string line;

                XmlDocument Document = new XmlDocument();

                XmlElement History = Document.CreateElement("History");
                Document.AppendChild(History);

                while ((line = reader.ReadLine()) != null)
                {
                    XmlElement Game = Document.CreateElement("Game");
                    History.AppendChild(Game);

                    int counter = 0;
                    int t;

                    List<string> Moves = line.Split(new char[] { '.', ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => !(int.TryParse(x, out t) || x[0] == '$')).ToList();

                    if (new string[] { "*", "1-0", "0-1", "1/2-1/2" }.Contains(Moves[Moves.Count - 1]))
                    {
                        Moves.RemoveAt(Moves.Count - 1);
                    }

                    //foreach (var move in Moves)
                    //{
                    //    counter++;
                    //    Console.WriteLine(counter + ": " + move);
                    //}
                    //return;
                    foreach (string SAN in Moves)
                    {
                        Console.WriteLine(SAN);
                        //if (counter % 2 == 0)
                        //{
                        //    Move m = Move.ConvertSanToMove(SAN, ColorEnum.White);
                        //    MovesToRegister.Add(m);
                        //}
                        //else
                        //{
                        //    Move m = Move.ConvertSanToMove(SAN, ColorEnum.Black);
                        //    MovesToRegister.Add(m);
                        //}
                        //counter++;
                        //    Move.SetAttribute("FromX", m.FromField.Item1.ToString());
                        //    Move.SetAttribute("FromY", m.FromField.Item2.ToString());
                        //    Move.SetAttribute("ToX", m.ToField.Item1.ToString());
                        //    Move.SetAttribute("ToY", m.ToField.Item2.ToString());

                        //    if (m.PromotionMove)
                        //    {
                        //        Move.SetAttribute("Promotion", "true");
                        //        Move.SetAttribute("Color", m.MovedChessColor == ColorEnum.White ? "White" : "Black");
                        //        Move.SetAttribute("Choice", m.CapturedChessName);
                        //    }

                        //    if (m.CheckMove)
                        //    {
                        //        Move.SetAttribute("CheckMove", m.CheckMove.ToString());
                        //    }
                    }
                }

                //Document.Save(WritePath);
            }
        }

        private void AddGameToHistory(Move Move)
        {

        }
    }
}
