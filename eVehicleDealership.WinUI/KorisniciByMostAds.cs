using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVehicleDealership.WinUI
{
    public partial class KorisniciByMostAds : Form
    {
        public KorisniciByMostAds()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_170073DataSet.KorisniciSaNajviseOglasa' table. You can move, or remove it, as needed.
            this.KorisniciSaNajviseOglasaTableAdapter.Fill(this._170073DataSet.KorisniciSaNajviseOglasa);

            this.reportViewer1.RefreshReport();
        }
    }
}
