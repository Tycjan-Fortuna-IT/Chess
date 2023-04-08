namespace ChessGUI
{
    partial class Chess
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(34, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 640);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Bishop", "King", "Knight", "Pawn", "Queen", "Rook" });
            comboBox1.Location = new Point(695, 74);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(715, 27);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 2;
            label1.Text = "Choose piece";
            // 
            // Chess
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 662);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            Name = "Chess";
            Text = "Chess";
            Load += Chess_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Label label1;
    }
}