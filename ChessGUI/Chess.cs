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

            HistoryPanel.AutoScroll = true;
            HistoryPanel.AutoScrollPosition = Point.Empty;
        }

        private void Chess_Load(object sender, EventArgs e)
        {

        }

        private void CreateChessboardGrid()
        {
            int ButtonWidth = ChessboardPanel.Width / Chessboard.WIDTH;
            int ButtonHeight = ChessboardPanel.Height / Chessboard.HEIGHT;

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

                    ChessboardPanel.Controls.Add(Buttons[i, j]);

                    Buttons[i, j].Location = new Point(i * ButtonWidth, j * ButtonHeight);

                    //Buttons[i, j].Text = i + "|" + j;
                    counter++;

                }
                counter++;
            }
        }

        private void ClickChessboardField(object sender, EventArgs args)
        {
            Button ClickedButton = (Button)sender;

            int FieldPositionX = ClickedButton.Location.X / (ChessboardPanel.Width / Chessboard.WIDTH);
            int FieldPositionY = ClickedButton.Location.Y / (ChessboardPanel.Height / Chessboard.HEIGHT);

            Field CurrentlyClickedField = Board.GetField(FieldPositionX, FieldPositionY);

            if (LastClicked is null)
            {
                if (CurrentlyClickedField.IsEmpty())
                    return;

                if (Board.IsWhiteMove && CurrentlyClickedField.Chess.Color != ColorEnum.White)
                    return;
                else if (!Board.IsWhiteMove && CurrentlyClickedField.Chess.Color != ColorEnum.Black)
                    return;
            }

            this.CleanChessboardFields();

            if (LastClicked is not null)
            {
                Field LastClickedField = Board.GetField(LastClicked.PosX, LastClicked.PosY);

                if (!LastClickedField.IsEmpty())
                {
                    Board.MoveFromFieldToField(LastClickedField, CurrentlyClickedField);

                    this.RefreshHistory();

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

            foreach (Field Position in Board.GetFieldsForPromotion(ColorEnum.White))
            {
                Buttons[Position.PosX, Position.PosY].BackColor = Color.LightGoldenrodYellow;
                this.PromotionDisplay(Position, "Black");
            }

            foreach (Field Position in Board.GetFieldsForPromotion(ColorEnum.Black))
            {
                Buttons[Position.PosX, Position.PosY].BackColor = Color.LightGoldenrodYellow;
                this.PromotionDisplay(Position, "White");
            }

            this.DrawFiguresOnBoard();
        }

        static PromotionPopup? PromotionPopup = null;
        static Tuple<int, int>? PromotionFieldCords = null;

        public void PromotionDisplay(Field Field, string Color)
        {
            if (PromotionPopup is null)
            {
                PromotionFieldCords = new Tuple<int, int>(Field.PosX, Field.PosY);

                PromotionPopup = new PromotionPopup(this, Color);

                PromotionPopup.Owner = this;

                int x = this.Location.X + (this.Width - PromotionPopup.Width) / 2;
                int y = this.Location.Y + (this.Height - PromotionPopup.Height) / 2;

                PromotionPopup.Location = new Point(x, y);

                PromotionPopup.Show();
            }
        }

        public void PromoteChessTo(IChess PromotionChoice)
        {
            if (PromotionFieldCords is not null)
            {
                Field Field = Board.GetField(PromotionFieldCords.Item1, PromotionFieldCords.Item2);

                Board.PromoteChessTo(Field, PromotionChoice);

                this.RefreshHistory();

                this.CleanChessboardFields();
                this.DrawFiguresOnBoard();

                PromotionPopup = null;
                PromotionFieldCords = null;
            }
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
                        Buttons[i, j].Image = AssetManager.GetTextureByTagName(Field.Chess.ToString() + Field.Chess.Color);
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

        static int LastHistoryIndex = 0;

        private void RefreshHistory()
        {
            for (int i = LastHistoryIndex; i < Board.HistoryManager.Moves.Count(); i++)
            {
                this.AddNewHistoryElement(Board.HistoryManager.Moves[i], LastHistoryIndex);

                LastHistoryIndex++;
            }
        }

        private void AddNewHistoryElement(Move Move, int HistoryIndex)
        {
            bool CaptureMove = Move.CapturedChessName is not null && Move.CapturedChessColor is not null;

            bool PromotionMove = Move.PromotionMove;

            bool CastleMove = Move.CastleMove;

            bool CheckMove = Move.CheckMove;

            PictureBox PictureBox = new PictureBox();


            Point ScrollPosition = HistoryPanel.AutoScrollPosition;

            Label Label = new Label();

            if (PromotionMove)
            {
                PictureBox.Image = AssetManager.GetTextureByTagName(Move.CapturedChessName + Move.CapturedChessColor + "Promotion");
                PictureBox.Location = new Point(30, 0 + HistoryIndex * 60 + ScrollPosition.Y);

                Label.Text = "Promotion!";
            }
            else if (CastleMove)
            {
                PictureBox.Image = AssetManager.GetTextureByTagName(Move.CapturedChessName + Move.CapturedChessColor);
                PictureBox.Location = new Point(30, 0 + HistoryIndex * 60 + ScrollPosition.Y);

                Label.Text = "Castle!";
            }
            else if (CheckMove)
            {
                PictureBox.Image = AssetManager.GetTextureByTagName(Move.CapturedChessName + Move.CapturedChessColor);
                PictureBox.Location = new Point(30, 0 + HistoryIndex * 60 + ScrollPosition.Y);

                Label.Text = "In check!";

                if (Board.CheckIfKingIsCheckmated(Move.CapturedChessColor ?? ColorEnum.Black))
                {
                    Label.Text = "Checkmate!";
                }
            }
            else
            {
                PictureBox.Image = AssetManager.GetTextureByTagName(Move.MovedChess + Move.MovedChessColor);

                Label.Text = string.Format("({0}, {1}) to ({2}, {3})",
                    Move.FromField.Item1, Move.FromField.Item2, Move.ToField.Item1, Move.ToField.Item2);

                if (CaptureMove)
                {
                    PictureBox CapturedPictureBox = new PictureBox();

                    CapturedPictureBox.Image = AssetManager.GetTextureByTagName(Move.CapturedChessName + Move.CapturedChessColor + "Captured");
                    CapturedPictureBox.Location = new Point(60, 0 + HistoryIndex * 60 + ScrollPosition.Y);
                    CapturedPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                    HistoryPanel.Controls.Add(CapturedPictureBox);
                }

                PictureBox.Location = new Point(CaptureMove ? 0 : 30, 0 + HistoryIndex * 60 + ScrollPosition.Y);
            }

            Label.Location = new Point(120, 20 + HistoryIndex * 60 + ScrollPosition.Y);

            HistoryPanel.Controls.Add(Label);

            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            HistoryPanel.Controls.Add(PictureBox);

            HistoryPanel.VerticalScroll.Value = HistoryPanel.VerticalScroll.Maximum;
        }

        private void CleanHistory()
        {
            while (HistoryPanel.Controls.Count > 0)
            {
                HistoryPanel.Controls[0].Dispose();
            }

            Board.HistoryManager.Moves = new List<Move>();

            LastHistoryIndex = 0;
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

            this.CleanHistory();

            Board.Load(filePath);

            this.CleanChessboardFields();
            this.DrawFiguresOnBoard();

            this.RefreshHistory();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}