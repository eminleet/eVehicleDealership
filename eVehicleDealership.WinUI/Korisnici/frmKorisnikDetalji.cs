using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVehicleDealership.WinUI.Korisnici
{
    public partial class frmKorisnikDetalji : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _ulogeService = new APIService("Uloge");
        private readonly int? _korisnikId = null;
        KorisnikInsertRequest request = new KorisnikInsertRequest();
        public frmKorisnikDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
            _korisnikId = korisnikId;
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var uloge = clbUloge.CheckedItems.Cast<Modeli.Uloga>().Select(x => x.UlogaId).ToList();

                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Email = txtEmail.Text;
                request.Telefon = txtTelefon.Text;
                request.Password = txtLozinka.Text;
                request.PasswordConfirmation = txtLozinkaPotvrda.Text;
                request.Uloge = uloge;

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagebyte = (byte[])_imageConverter.ConvertTo(pbSlikaKorisnika.Image, typeof(byte[]));
                request.Slika = imagebyte;

                try
                {
                    if (_korisnikId.HasValue)
                    {
                        await _korisniciService.Update<Modeli.Korisnik>(_korisnikId, request);
                        MessageBox.Show("Zapis u bazi uspješno izmijenjen!");
                    }
                    else
                    {
                        await _korisniciService.Insert<Modeli.Korisnik>(request);
                        MessageBox.Show("Novi zapis uspješno pohranjen u bazu!");
                    }
                    this.Close();
                    var frm = new frmKorisnici();
                    var frmIndex = Application.OpenForms["frmIndex"];
                    frm.MdiParent = frmIndex;
                    frm.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nemate pristup!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private async void frmKorisnikDetalji_Load(object sender, EventArgs e)
        {
            var uloge = await _ulogeService.Get<List<Modeli.Uloga>>(null);
            clbUloge.DataSource = uloge;
            clbUloge.DisplayMember = "Naziv";
            clbUloge.ValueMember = "UlogaId";

            if (_korisnikId.HasValue)
            {
                try
                {
                    var korisnik = await _korisniciService.GetById<Modeli.Korisnik>(_korisnikId);
                    MemoryStream ms = new MemoryStream(korisnik.Slika);
                    Image image = Image.FromStream(ms);
                    pbSlikaKorisnika.Image = image;

                    txtIme.Text = korisnik.Ime;
                    txtPrezime.Text = korisnik.Prezime;
                    txtEmail.Text = korisnik.Email;
                    txtTelefon.Text = korisnik.Telefon;

                    var request = new UlogaSearchRequest { KorisnikId = korisnik.KorisnikId };
                    var korisnikUloge = await _ulogeService.Get<List<Modeli.Uloga>>(request);
                    var ulogeInt = korisnikUloge.Select(x => x.UlogaId);
                    for (int i = 0; i < clbUloge.Items.Count; i++)
                    {
                        var item = (clbUloge.Items[i] as Modeli.Uloga).UlogaId;
                        if (ulogeInt.Contains(item))
                        {
                            clbUloge.SetItemChecked(i, true);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Nemate pristup!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Val_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"[^@]+@[^\.]+\..+");
            if (!regex.Match(txtEmail.Text).Success)
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Val_EmailRegex);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (!_korisnikId.HasValue)
            {
                if (txtLozinka.TextLength < 8)
                {
                    errorProvider.SetError(txtLozinka, Properties.Resources.Val_MinLengthPassword);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtLozinka, null);
                }
            }
        }

        private void txtLozinkaPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (!_korisnikId.HasValue)
            {
                if (txtLozinkaPotvrda.Text != txtLozinka.Text)
                {
                    errorProvider.SetError(txtLozinkaPotvrda, Properties.Resources.Val_PasswordConfirm);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtLozinkaPotvrda, null);
                }
            }
        }

        private void btnUploadSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                var file = File.ReadAllBytes(filename);

                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(200, 200, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                request.Slika = imagethumbbyte;
                pbSlikaKorisnika.Image = image;
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                Regex regex = new Regex(@"^(\+)?([ 0-9]){9,16}$");
                if (!regex.Match(txtTelefon.Text).Success)
                {
                    errorProvider.SetError(txtTelefon, Properties.Resources.Val_PhoneNumberRegex);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtTelefon, null);
                }
            }
        }
    }
}