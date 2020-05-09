using eVehicleDealership.Modeli;
using Flurl.Http;
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
    public partial class frmLogin : Form
    {
        private readonly APIService _apiService = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new AuthenticateModel
                {
                    Email = txtEmail.Text,
                    Password = txtLozinka.Text
                };
                var url = $"{Properties.Settings.Default.APIUrl}/Korisnici/Login";
                var response = await url.PostJsonAsync(request).ReceiveJson<Modeli.Korisnik>();
                var test = response;
                APIService.Token = test.Token;

                await _apiService.Get<dynamic>(null);

                this.Hide();
                var frm = new frmIndex();
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Login podaci nisu ispravni!", "Autentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
