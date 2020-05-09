using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eVehicleDealership.Modeli.Requests;
using Flurl.Http;

namespace eVehicleDealership.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _apiService = new APIService("Korisnici");
        public frmKorisnici()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            KorisnikSearchRequest request;

            var imePrezime = txtPretraga.Text.Split(' ');
            if (imePrezime.Length >= 2)
            {
                request = new KorisnikSearchRequest
                {
                    Ime = imePrezime[0],
                    Prezime = imePrezime[1]
                };
            }
            else
            {
                request = new KorisnikSearchRequest
                {
                    Ime = imePrezime[0],
                };
            }

            var result = await _apiService.Get<List<Modeli.Korisnik>>(request);

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<Modeli.Korisnik>>(null);

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvKorisnici.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            dgvKorisnici.DataSource = result;
        }

        private void dgvKorisnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = int.Parse(dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString());

            var frm = new frmKorisnikDetalji(id);
            frm.Show();
        }
    }
}
