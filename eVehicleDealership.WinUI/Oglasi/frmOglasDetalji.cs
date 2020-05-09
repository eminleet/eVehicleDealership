using eVehicleDealership.Modeli.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVehicleDealership.WinUI.Oglasi
{
    public partial class frmOglasDetalji : Form
    {
        private readonly APIService _voziloService = new APIService("Vozila");
        private readonly int _voziloId;
        public frmOglasDetalji(int id)
        {
            _voziloId = id;
            InitializeComponent();
        }

        private async void frmOglasDetalji_Load(object sender, EventArgs e)
        {
            var oglasDetalji = await _voziloService.GetById<Modeli.VoziloDetalji>(_voziloId);

            if (oglasDetalji.SlikaVozila != null)
            {
                MemoryStream ms = new MemoryStream(oglasDetalji.SlikaVozila);
                Image image = Image.FromStream(ms);
                PbVoziloSlika.Image = image;
            }

            if (oglasDetalji.SlikaKorisnika != null)
            {
                MemoryStream ms2 = new MemoryStream(oglasDetalji.SlikaKorisnika);
                Image image2 = Image.FromStream(ms2);
                PbKorisnikSlika.Image = image2;
            }

            txtBoja.Text = oglasDetalji.Boja;
            txtCijena.Text = "€" + oglasDetalji.Cijena;
            txtEmail.Text = oglasDetalji.Email;
            txtGodiste.Text = oglasDetalji.GodinaProizvodnje.ToString();
            txtGorivo.Text = oglasDetalji.Gorivo;
            txtImePrezime.Text = oglasDetalji.Korisnik;
            txtKonjskihSnaga.Text = oglasDetalji.KonjskihSnaga.ToString();
            txtKubikaza.Text = oglasDetalji.Kubikaza;
            txtModel.Text = oglasDetalji.Model;
            txtNaslov.Text = oglasDetalji.Naziv;
            txtProizvodjac.Text = oglasDetalji.Proizvodjac;
            txtStanje.Text = oglasDetalji.Stanje;
            txtTelefon.Text = oglasDetalji.Telefon;
            txtTransmisija.Text = oglasDetalji.Transmisija;
            cbIstaknuto.Checked = oglasDetalji.Istaknuto ? true : false;
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            var request = new VoziloUpdateRequest
            {
                Istaknuto = cbIstaknuto.Checked
            };

            var response = await _voziloService.Update<Modeli.VoziloResponse>(_voziloId, request);
            if (response.Status)
                MessageBox.Show("Oglas istaknut!");
            else
                MessageBox.Show("Došlo je do greške");

            this.Close();
            var frm = new frmOglasi();
            var frmIndex = Application.OpenForms["frmIndex"];
            frm.MdiParent = frmIndex;
            frm.Show();
        }
    }
}
