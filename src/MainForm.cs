using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using CoordinateSharp;


namespace FlightPlanConverter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DialogResult result = convertFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                FplTemplate template = new FplTemplate();

                string pln = template.FPLToPLN(convertFileDialog.FileName, tbCrusingAlt.Text);

                string outFilename = convertFileDialog.FileName.Replace(".fpl", ".PLN");
                File.WriteAllText(outFilename, pln);
            }
        }
    }
}
