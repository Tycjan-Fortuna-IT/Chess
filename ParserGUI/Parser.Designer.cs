namespace ParserGUI
{
    partial class Parser
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
            inputPNGDialog = new OpenFileDialog();
            outputTXTDialog = new SaveFileDialog();
            inputPGN = new Button();
            outputTXT = new Button();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            progressBar2 = new ProgressBar();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // inputPNGDialog
            // 
            inputPNGDialog.FileOk += openFileDialog1_FileOk;
            // 
            // outputTXTDialog
            // 
            outputTXTDialog.FileOk += saveFileDialog1_FileOk;
            // 
            // inputPGN
            // 
            inputPGN.Location = new Point(85, 43);
            inputPGN.Name = "inputPGN";
            inputPGN.Size = new Size(75, 23);
            inputPGN.TabIndex = 0;
            inputPGN.Text = "Input";
            inputPGN.UseVisualStyleBackColor = true;
            inputPGN.Click += inputPNG_Click;
            // 
            // outputTXT
            // 
            outputTXT.Location = new Point(230, 43);
            outputTXT.Name = "outputTXT";
            outputTXT.Size = new Size(75, 23);
            outputTXT.TabIndex = 1;
            outputTXT.Text = "Output";
            outputTXT.UseVisualStyleBackColor = true;
            outputTXT.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(85, 90);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(369, 23);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(368, 43);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 3;
            button1.Text = "Parse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 16);
            label1.Name = "label1";
            label1.Size = new Size(467, 15);
            label1.TabIndex = 4;
            label1.Text = "Choose file in PGN chess notation to convert it to a TXT file, where one line is one game";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 125);
            label2.Name = "label2";
            label2.Size = new Size(481, 15);
            label2.TabIndex = 5;
            label2.Text = "Choose file in TXT chess notation to convert it to a XML file, which stores proper positions.";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(368, 165);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 9;
            button2.Text = "Parse";
            button2.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(85, 212);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(369, 23);
            progressBar2.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(230, 165);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 7;
            button3.Text = "Output";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(85, 165);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Input";
            button4.UseVisualStyleBackColor = true;
            // 
            // Parser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(541, 258);
            Controls.Add(button2);
            Controls.Add(progressBar2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(outputTXT);
            Controls.Add(inputPGN);
            Name = "Parser";
            Text = "Parser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog inputPNGDialog;
        private SaveFileDialog outputTXTDialog;
        private Button inputPGN;
        private Button outputTXT;
        private ProgressBar progressBar1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private ProgressBar progressBar2;
        private Button button3;
        private Button button4;
    }
}