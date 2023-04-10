using Chess.Models;
using System.Text.RegularExpressions;

namespace ChessGUI
{
    public partial class Chess : Form
    {
        static Chessboard Board = new Chessboard(new Dictionary<string, FigureSet>
        {
            { "Black", new FigureSet(new DefaultFigureSet(), ColorEnum.Black) },
            { "White", new FigureSet(new DefaultFigureSet(), ColorEnum.White) }
        });

        private Button[,] Buttons = new Button[Chessboard.WIDTH, Chessboard.HEIGHT];

        private Field? LastClicked;

        public Chess()
        {
            InitializeComponent();
            this.CreateChessboardGrid();

            this.DrawFiguresOnBoard();

            panel2.AutoScroll = true;
            panel2.AutoScrollPosition = Point.Empty;
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
                    Board.MoveFromFieldToField(LastClickedField, CurrentlyClickedField);

                    this.AddNewHistoryElement(Board.HistoryManager.Moves.Last(), Board.HistoryManager.Moves.Count());

                    LastClicked = null;
                }
            }
            else if (!CurrentlyClickedField.IsEmpty())
            {
                foreach (var Position in CurrentlyClickedField.Chess.GetAvailablePositions())
                {
                    Buttons[Position.PosX, Position.PosY].BackColor = !Position.IsEmpty() ?
                        Color.IndianRed : Color.DarkSeaGreen;
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
            int counter = 1;

            for (int i = 0; i < Chessboard.WIDTH; i++)
            {
                for (int j = 0; j < Chessboard.HEIGHT; j++)
                {
                    Field Field = Board.GetField(i, j);

                    Buttons[i, j].Text = "";
                    Buttons[i, j].Image = null;
                    Buttons[i, j].BackColor = counter % 2 == 0 ? Color.Gray : Color.White;

                    counter++;
                }
                counter++;
            }
        }

        private void AddNewHistoryElement(Move Move, int HistoryIndex)
        {
            bool CaptureMove = Move.CapturedChessName is not null && Move.CapturedChessColor is not null;

            PictureBox PictureBox = new PictureBox();

            Label Label = new Label();

            Point ScrollPosition = panel2.AutoScrollPosition;

            Label.Text = string.Format("({0}, {1}) to ({2}, {3})",
                Move.FromField.Item1, Move.FromField.Item2, Move.ToField.Item1, Move.ToField.Item2);

            Label.Location = new Point(120, 20 + (HistoryIndex - 1) * 60 + ScrollPosition.Y);

            panel2.Controls.Add(Label);

            PictureBox.Image = AssetManager.GetTextureByTagName(Move.MovedChess + Move.MovedChessColor);
            PictureBox.Location = new Point(CaptureMove ? 0 : 30, 0 + (HistoryIndex - 1) * 60 + ScrollPosition.Y);
            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            panel2.Controls.Add(PictureBox);

            if (CaptureMove)
            {
                PictureBox CapturedPictureBox = new PictureBox();

                CapturedPictureBox.Image = AssetManager.GetTextureByTagName(Move.CapturedChessName + Move.CapturedChessColor + "Captured");
                CapturedPictureBox.Location = new Point(60, 0 + (HistoryIndex - 1) * 60 + ScrollPosition.Y);
                CapturedPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                panel2.Controls.Add(CapturedPictureBox);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ValidateNames = true;
            saveFileDialog1.Filter = "Xml files (*.xml)|*.xml";

            saveFileDialog1.ShowDialog(this);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ValidateNames = true;
            openFileDialog1.Filter = "Xml files (*.xml)|*.xml";

            openFileDialog1.ShowDialog(this);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = saveFileDialog1.FileName;

            Board.Save(filePath);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;

            Board.Load(filePath);

            this.CleanChessboardFields();
            this.DrawFiguresOnBoard();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}