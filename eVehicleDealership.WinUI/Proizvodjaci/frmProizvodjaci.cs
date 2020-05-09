using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.Modeli;
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

namespace eVehicleDealership.WinUI.Proizvodjaci
{
    public partial class frmProizvodjaci : Form
    {
        private readonly APIService _drzaveService = new APIService("Drzave");
        private readonly APIService _proizvodjaciService = new APIService("Proizvodjaci");
        public frmProizvodjaci()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private async void frmProizvodjaci_Load(object sender, EventArgs e)
        {
            dgvProizvodjaci.AutoGenerateColumns = false;
            dgvProizvodjaci.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvProizvodjaci.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            var result = await _proizvodjaciService.Get<List<Modeli.Proizvodjac>>(null);
            dgvProizvodjaci.DataSource = result;

            await LoadDrzave();
        }

        private async Task LoadDrzave()
        {
            var result = await _drzaveService.Get<List<Modeli.Drzava>>(null);
            result = result.OrderBy(x => x.Naziv).ToList();
            result.Insert(0, new Modeli.Drzava());
            cmbDrzavaProizvodjaca.DisplayMember = "Naziv";
            cmbDrzavaProizvodjaca.ValueMember = "DrzavaId";
            cmbDrzavaProizvodjaca.DataSource = result;
        }

        private async void cmbDrzavaProizvodjaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedId = cmbDrzavaProizvodjaca.SelectedValue;

            if (int.TryParse(selectedId.ToString(), out int id))
            {
                if (id >= 1)
                {
                    await LoadProizvodjaci(id);
                }
            }
        }

        private async Task LoadProizvodjaci(int drzavaId)
        {
            var searchRequest = new ProizvodjacSearchRequest
            {
                DrzavaId = drzavaId
            };

            var result = await _proizvodjaciService.Get<List<Modeli.Proizvodjac>>(searchRequest);
            dgvProizvodjaci.DataSource = result;
        }

        ProizvodjacUpsertRequest request = new ProizvodjacUpsertRequest();
        private async void btnSacuvajProizvodjaca_Click(object sender, EventArgs e)
        {
            var validateForm = ValidateChildren();
            if ((string)pbProizvodjac.Tag != "Logo")
            {
                errorProvider.SetError(pbProizvodjac, Properties.Resources.Val_RequiredUpload);
            }
            else
            {
                errorProvider.SetError(pbProizvodjac, null);

                if (validateForm)
                {
                    var selectedId = cmbDrzavaProizvodjaca.SelectedValue;

                    if (int.TryParse(selectedId.ToString(), out int id))
                    {
                        request.DrzavaId = id;
                    }

                    request.Naziv = txtNazivProizvodjaca.Text;

                    await _proizvodjaciService.Insert<Modeli.Proizvodjac>(request);
                    MessageBox.Show("Uspješno dodan novi proizvođač vozila!");
                    await LoadProizvodjaci(request.DrzavaId);
                }
            }
        }

        private void btnUcitajLogoProizvodjaca_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                var file = File.ReadAllBytes(filename);

                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                request.Logo = imagethumbbyte;
                pbProizvodjac.Image = image;
                pbProizvodjac.Tag = "Logo";
            }
        }

        private void txtNazivProizvodjaca_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivProizvodjaca.Text))
            {
                errorProvider.SetError(txtNazivProizvodjaca, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNazivProizvodjaca, null);
            }
        }

        private void cmbDrzavaProizvodjaca_Validating(object sender, CancelEventArgs e)
        {
            var selectedValue = cmbDrzavaProizvodjaca.SelectedValue;
            if (int.TryParse(selectedValue.ToString(), out int id))
            {
                if (id < 1)
                {
                    errorProvider.SetError(cmbDrzavaProizvodjaca, Properties.Resources.Val_RequiredField);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(cmbDrzavaProizvodjaca, null);
                }
            }
        }
    }
}
