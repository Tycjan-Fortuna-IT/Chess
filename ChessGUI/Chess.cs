using Chess.Models;

namespace ChessGUI
{
    public partial class Chess : Form
    {
        static Chessboard Board = new Chessboard();

        private FigureSet WhiteFigureSet = new FigureSet(new DefaultFigureSet(), ColorEnum.White);
        private FigureSet BlackFigureSet = new FigureSet(new DefaultFigureSet(), ColorEnum.Black);

        private Button[,] Buttons = new Button[Chessboard.WIDTH, Chessboard.HEIGHT];

        private Field? LastClicked;

        public Chess()
        {
            InitializeComponent();
            CreateChessboardGrid();

            this.WhiteFigureSet.PlaceFiguresOnBoard(Board);
            this.BlackFigureSet.PlaceFiguresOnBoard(Board);

            this.DrawFiguresOnBoard();
        }

        private void Chess_Load(object sender, EventArgs e)
        {

        }

        private void CreateChessboardGrid()
        {
            int ButtonWidth = panel1.Width / Chessboard.WIDTH;
            int ButtonHeight = panel1.Height / Chessboard.HEIGHT;

            int counter = 1;

            for (int i = 0; i < Chessboard.WIDTH; i++)
            {
                for (int j = 0; j < Chessboard.HEIGHT; j++)
                {
                    Buttons[i, j] = new Button();

                    Buttons[i, j].Height = ButtonHeight;
                    Buttons[i, j].Width = ButtonWidth;

                    Buttons[i, j].Click += this.ClickChessboardField;

                    Buttons[i, j].BackColor = counter % 2 == 0 ? Color.Gray : Color.White;

                    Buttons[i, j].Margin = new Padding(0);
                    Buttons[i, j].Padding = new Padding(0);

                    panel1.Controls.Add(Buttons[i, j]);

                    Buttons[i, j].Location = new Point(i * ButtonWidth, j * ButtonHeight);

                    //Buttons[i, j].Text = i + "|" + j;
                    counter++;

                }
                counter++;
            }
        }

        private void ClickChessboardField(object sender, EventArgs args)
        {
            this.CleanChessboardFields();

            Button ClickedButton = (Button)sender;

            int FieldPositionX = ClickedButton.Location.X / (panel1.Width / Chessboard.WIDTH);
            int FieldPositionY = ClickedButton.Location.Y / (panel1.Height / Chessboard.HEIGHT);

            Field CurrentlyClickedField = Board.GetField(FieldPositionX, FieldPositionY);

            if (LastClicked is not null)
            {
                Field LastClickedField = Board.GetField(LastClicked.PosX, LastClicked.PosY);

                if (!LastClickedField.IsEmpty())
                {
                    IChess ChessToMove = LastClickedField.Chess;

                    CurrentlyClickedField.AddChess(ChessToMove);

                    LastClicked.RemoveChess();

                    LastClicked = null;
                }
            }
            else if (!CurrentlyClickedField.IsEmpty())
            {
                foreach (var Position in CurrentlyClickedField.Chess.GetAvailablePositions())
                {
                    Buttons[Position.PosX, Position.PosY].Text = "Legal";
                }

                LastClicked = CurrentlyClickedField;
            }

            this.DrawFiguresOnBoard();
        }

        private void DrawFiguresOnBoard()
        {
            for (int i = 0; i < Chessboard.WIDTH; i++)
            {
                for (int j = 0; j < Chessboard.HEIGHT; j++)
                {
                    Field Field = Board.GetField(i, j);

                    if (!Field.IsEmpty())
                    {
                        Buttons[i, j].Image = Field.Chess.Texture;
                    }
                }
            }
        }

        private void CleanChessboardFields()
        {
            for (int i = 0; i < Chessboard.WIDTH; i++)
            {
                for (int j = 0; j < Chessboard.HEIGHT; j++)
                {
                    Field Field = Board.GetField(i, j);

                    Buttons[i, j].Text = "";
                    Buttons[i, j].Image = null;
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}