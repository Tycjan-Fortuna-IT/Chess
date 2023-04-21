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
            // Parser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(541, 145);
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
    }
}