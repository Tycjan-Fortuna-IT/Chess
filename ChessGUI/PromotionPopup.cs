using Chess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGUI
{
    public partial class PromotionPopup : Form
    {
        public string PromotionColor;

        private Chess MyReferenceToParent;

        public PromotionPopup(Chess MyReferenceToParent, string Color)
        {
            InitializeComponent();

            this.PromotionColor = Color;

            this.ControlBox = false;

            this.MyReferenceToParent = MyReferenceToParent;
             
            this.DisplayPromotionFiguresPanel();
        }

        private void DisplayPromotionFiguresPanel()
        {
            PictureBox QueenPictureBox = new PictureBox();
            PictureBox RookPictureBox = new PictureBox();
            PictureBox BishopPictureBox = new PictureBox();
            PictureBox KnightPictureBox = new PictureBox();

            QueenPictureBox.Image = AssetManager.GetTextureByTagName("Queen" + PromotionColor + "Promotion");
            QueenPictureBox.Location = new Point(0, 0);
            QueenPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            RookPictureBox.Image = AssetManager.GetTextureByTagName("Rook" + PromotionColor + "Promotion");
            RookPictureBox.Location = new Point(60, 0);
            RookPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            BishopPictureBox.Image = AssetManager.GetTextureByTagName("Bishop" + PromotionColor + "Promotion");
            BishopPictureBox.Location = new Point(120, 0);
            BishopPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            KnightPictureBox.Image = AssetManager.GetTextureByTagName("Knight" + PromotionColor + "Promotion");
            KnightPictureBox.Location = new Point(180, 0);
            KnightPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            panel1.Controls.Add(QueenPictureBox);
            panel1.Controls.Add(RookPictureBox);
            panel1.Controls.Add(BishopPictureBox);
            panel1.Controls.Add(KnightPictureBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IChess Choice = new Queen(PromotionColor == "White" ? ColorEnum.White : ColorEnum.Black);

            if (radioButton2.Checked)
                Choice = new Rook(PromotionColor == "White" ? ColorEnum.White : ColorEnum.Black);
            else if (radioButton3.Checked)
                Choice = new Bishop(PromotionColor == "White" ? ColorEnum.White : ColorEnum.Black);
            else if (radioButton4.Checked)
                Choice = new Knight(PromotionColor == "White" ? ColorEnum.White : ColorEnum.Black);

            this.MyReferenceToParent.PromoteChessTo(Choice);

            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PromotionPopup_Load(object sender, EventArgs e)
        {

        }
    }
}
