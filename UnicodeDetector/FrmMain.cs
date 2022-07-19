using System.Windows.Forms;

namespace UnicodeDetector
{
    public partial class FrmMain : Form
    {
        public void Setup()
        {
            txtInput.TextChanged += (sender, args) =>
            {
                var asciiOnly = txtInput.Text.EnsureAscii();
                var distance = txtInput.Text.ComputeDistance(asciiOnly);

                txtOutput.Text = asciiOnly;

                lblCount.Text = $"Unicode Characters Found : {distance}";
            };

            txtOutput.ReadOnly = true;
        }

        public FrmMain()
        {
            InitializeComponent();
        }
    }
}
