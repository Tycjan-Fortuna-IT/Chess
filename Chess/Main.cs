using System.Text.RegularExpressions;
using Chess.Models;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard(new Dictionary<string, FigureSet>
            {
                { "Black", new FigureSet(new DefaultFigureSet(), ColorEnum.Black) },
                { "White", new FigureSet(new DefaultFigureSet(), ColorEnum.White) }
            });

            //TXTParser Parser = new TXTParser();

            //Parser.ParseToXML("C:\\Users\\tycja\\Desktop\\SicilianRossolimo\\test.txt", "C:\\Users\\tycja\\Desktop\\SicilianRossolimo\\1.xml");
        }
    }
}
