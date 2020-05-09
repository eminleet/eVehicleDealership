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
    public partial class NajskupljaVozila : Form
    {
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private string _kategorija;
        public NajskupljaVozila()
        {
            InitializeComponent();
        }

        private async void NajskupljaVozila_Load(object sender, EventArgs e)
        {
            var result = await _kategorijeService.Get<List<Modeli.Kategorija>>(null);
            result.Insert(0, new Modeli.Kategorija());
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "Naziv";
            cmbKategorije.DataSource = result;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_170073DataSet.NajskupljaVozila' table. You can move, or remove it, as needed.
            if (!string.IsNullOrWhiteSpace(_kategorija))
                this.NajskupljaVozilaTableAdapter.Fill(this._170073DataSet.NajskupljaVozila, _kategorija);
            else
                this.NajskupljaVozilaTableAdapter.Fill(this._170073DataSet.NajskupljaVozila, null);

            this.reportViewer1.RefreshReport();
        }

        private void cmbKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = cmbKategorije.SelectedValue;
            if (selectedValue != null)
            {
                var selectedKategorija = selectedValue.ToString();

                if (!string.IsNullOrWhiteSpace(selectedKategorija))
                    _kategorija = selectedKategorija;
            }
        }
    }
}
