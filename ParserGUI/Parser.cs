using Chess.Models;
using System.ComponentModel;
using System.Windows.Forms;

namespace ParserGUI
{
    public partial class Parser : Form
    {
        private PGNParser parser = new PGNParser();

        private string InputPath;

        private string OutputPath;

        public Parser()
        {
            InitializeComponent();

            outputTXT.Enabled = false;
            button1.Enabled = false;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.progressBar1.Value += 33;
            this.InputPath = inputPNGDialog.FileName;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.progressBar1.Value += 33;
            this.OutputPath = outputTXTDialog.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            outputTXTDialog.ValidateNames = true;
            outputTXTDialog.Filter = "TXT files (*.txt)|*.txt";

            outputTXTDialog.ShowDialog(this);

            button1.Enabled = true;
        }

        private void inputPNG_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;

            inputPNGDialog.ValidateNames = true;
            inputPNGDialog.Filter = "PGN files (*.pgn)|*.pgn";

            inputPNGDialog.ShowDialog(this);

            outputTXT.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.parser.ParseToTXT(this.InputPath, this.OutputPath);

            this.progressBar1.Value += 34;

            outputTXT.Enabled = false;
            button1.Enabled = false;

            Popup SuccessPopup = new Popup();

            SuccessPopup.Show();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}