using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            PopulatePrinters();
        }

        private void PopulatePrinters()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                cmbPrinters.Items.Add(printer);
        }

        private void btnOpenDrawer_Click(object sender, EventArgs e)
        {
            StringBuilder command = new StringBuilder();
            command.Append((char)27);
            command.Append((char)112);
            command.Append((char)0);
            command.Append((char)25);
            command.Append((char)255);
            RawPrinterHelper.SendStringToPrinter(cmbPrinters.Text, command.ToString());
        }
    }
}
