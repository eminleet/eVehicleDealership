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

namespace eVehicleDealership.WinUI.ModeliVozila
{
    public partial class frmModeli : Form
    {
        private readonly APIService _modeliService = new APIService("Modeli");
        private readonly APIService _proizvodjaciService = new APIService("Proizvodjaci");

        public frmModeli()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private async void frmModeli_Load(object sender, EventArgs e)
        {
            dgvModeli.AutoGenerateColumns = false;
            dgvModeli.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvModeli.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            var result = await _modeliService.Get<List<Modeli.Model>>(null);
            dgvModeli.DataSource = result;

            await LoadProizvodjace();
        }
        private async Task LoadProizvodjace()
        {
            var result = await _proizvodjaciService.Get<List<Modeli.Proizvodjac>>(null);
            result.Insert(0, new Modeli.Proizvodjac());
            cmbProizvodjaci.DisplayMember = "Naziv";
            cmbProizvodjaci.ValueMember = "ProizvodjacId";
            cmbProizvodjaci.DataSource = result;
        }

        private async void cmbProizvodjaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedId = cmbProizvodjaci.SelectedValue;

            if (int.TryParse(selectedId.ToString(), out int id))
            {
                if (id >= 1)
                {
                    await LoadModeli(id);
                }
            }
        }

        private async Task LoadModeli(int proizvodjacId)
        {
            var searchRequest = new ModelSearchRequest
            {
                ProizvodjacId = proizvodjacId
            };

            var result = await _modeliService.Get<List<Modeli.Model>>(searchRequest);
            dgvModeli.DataSource = result;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var selectedId = cmbProizvodjaci.SelectedValue;

                var request = new ModelInsertRequest();

                if (int.TryParse(selectedId.ToString(), out int id))
                {
                    request.ProizvodjacId = id;
                }

                request.Naziv = txtNazivModela.Text;

                await _modeliService.Insert<Modeli.Model>(request);
                MessageBox.Show("Uspješno dodan novi model vozila!");
                txtNazivModela.Text = "";
                await LoadModeli(request.ProizvodjacId);
            }
        }

        private void cmbProizvodjaci_Validating(object sender, CancelEventArgs e)
        {
            var selectedValue = cmbProizvodjaci.SelectedValue;
            if (int.TryParse(selectedValue.ToString(), out int id))
            {
                if (id < 1)
                {
                    errorProvider.SetError(cmbProizvodjaci, Properties.Resources.Val_RequiredField);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(cmbProizvodjaci, null);
                }
            }
        }

        private void txtNazivModela_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivModela.Text))
            {
                errorProvider.SetError(txtNazivModela, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNazivModela, null);
            }
        }
    }
}
