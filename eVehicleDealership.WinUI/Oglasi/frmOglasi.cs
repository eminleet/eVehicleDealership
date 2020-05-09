using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVehicleDealership.WinUI.Oglasi
{
    public partial class frmOglasi : Form
    {
        private readonly APIService _apiService = new APIService("Vozila");

        public frmOglasi()
        {
            InitializeComponent();
        }

        private async void frmOglasi_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<OglasDetaljiModel>>(null);

            dgvOglasi.AutoGenerateColumns = false;
            dgvOglasi.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvOglasi.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            dgvOglasi.DataSource = result;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {

            OglasSearchRequest request = new OglasSearchRequest();

            var kategorija = txtKategorijaPretraga.Text;
            if (kategorija != null)
                request.Kategorija = kategorija;

            var korisnik = txtKorisnikPretraga.Text;
            if (korisnik != null)
                request.Korisnik = korisnik;

            var naslov = txtNaslovPretraga.Text;
            if (naslov != null)
                request.Naslov = naslov;

            var proizvodjac = txtProizvodjacPretraga.Text;
            if (proizvodjac != null)
                request.Proizvodjac = proizvodjac;

            var result = await _apiService.Get<List<Modeli.OglasDetaljiModel>>(request);

            dgvOglasi.AutoGenerateColumns = false;
            dgvOglasi.DataSource = result;
        }

        private void dgvOglasi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = int.Parse(dgvOglasi.SelectedRows[0].Cells[0].Value.ToString());

            var frm = new frmOglasDetalji(id);
            frm.Show();
        }
    }
}
