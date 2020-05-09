using eVehicleDealership.WinUI.Korisnici;
using eVehicleDealership.WinUI.ModeliVozila;
using eVehicleDealership.WinUI.Oglasi;
using eVehicleDealership.WinUI.Proizvodjaci;
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
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKorisnikDetalji();
            frm.Show();
        }

        private void unosIPregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProizvodjaci();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pregledOglasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmOglasi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void unosIPregledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmModeli();
            frm.MdiParent = this;
            frm.Show();
        }

        private void oglasiUPerioduODDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new OglasiFromDateToDate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void najskupljaVozilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new NajskupljaVozila();
            frm.MdiParent = this;
            frm.Show();
        }

        private void top10KorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new KorisniciByMostAds();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
