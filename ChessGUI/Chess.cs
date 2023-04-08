using Chess.Models;

namespace ChessGUI
{
    public partial class Chess : Form
    {
        static Chessboard Board = new Chessboard();

        private Button[,] Buttons = new Button[Chessboard.WIDTH, Chessboard.HEIGHT];

        public Chess()
        {
            InitializeComponent();
            CreateChessboardGrid();
        }

        private void Chess_Load(object sender, EventArgs e)
        {

        }

        private void CreateChessboardGrid()
        {
            int ButtonWidth = panel1.Width / Chessboard.WIDTH;
            int ButtonHeight = panel1.Height / Chessboard.HEIGHT;

            for (int i = 0; i < Chessboard.WIDTH; i++)
            {
                for (int j = 0; j < Chessboard.HEIGHT; j++)
                {
                    Buttons[i, j] = new Button();

                    Buttons[i, j].Height = ButtonHeight;
                    Buttons[i, j].Width = ButtonWidth;

                    Buttons[i, j].Click += ClickChessboardField;

                    panel1.Controls.Add(Buttons[i, j]);

                    Buttons[i, j].Location = new Point(i * ButtonWidth, j * ButtonHeight);

                    Buttons[i, j].Text = i + "|" + j;
                }
            }
        }

        private void ClickChessboardField(object sender, EventArgs args)
        {
            CleanChessboardFields();

            Button ClickedButton = (Button)sender;

            int FieldPositionX = ClickedButton.Location.X / (panel1.Width / Chessboard.WIDTH);
            int FieldPositionY = ClickedButton.Location.Y / (panel1.Height / Chessboard.HEIGHT);

            Field Field = Board.GetField(FieldPositionX, FieldPositionY);

            IChess Chess = new Bishop(ColorEnum.White);
       
            switch(comboBox1.SelectedItem)
            {
                case "Bishop":
                    Chess = new Bishop(ColorEnum.White); break;
                case "King":
                    Chess = new King(ColorEnum.White); break;
                case "Knight":
                    Chess = new Knight(ColorEnum.White); break;
                case "Pawn":
                    Chess = new Pawn(ColorEnum.White); break;
                case "Queen":
                    Chess = new Queen(ColorEnum.White); break;
                case "Rook":
                    Chess = new Rook(ColorEnum.White); break;
            }

            Field.AddChess(Chess);

            foreach (var Position in Chess.GetAvailablePositions())
            {
                Buttons[Position.PosX, Position.PosY].Text = "Legal";
            }
        }

        private void CleanChessboardFields()
        {
            for (int i = 0; i < Chessboard.WIDTH; i++)
            {
                for (int j = 0; j < Chessboard.HEIGHT; j++)
                {
                    Field Field = Board.GetField(i, j);

                    if (!Field.IsEmpty())
                        Field.RemoveChess();

                    Buttons[i, j].Text = "";
                }
            }
        }
    }
}