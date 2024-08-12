using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiraKutucukUygulamasi
{
    public partial class KullaniciGiris : Form
    {
        TextBox txtSifre = new TextBox();
        TextBox txtKullaniciAdi = new TextBox();
        public KullaniciGiris()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += GirisFormu_Load;
        }
        public void GirisFormu_Load(object sender, EventArgs e)
        {
            // Formun genel özellikleri
            this.BackColor = Color.Honeydew;
            this.Text = "Kullanıcı Girişi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Formun yeniden boyutlandırılmasını engelle
            this.Size = new Size(1216, 789); // Form boyutunu ayarla

            // Labelları ve kutucuları içeren panel
            Panel panel = new Panel();
            panel.Size = new Size(400, 200);
            panel.BackColor = Color.Transparent;
            panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2+100); // Formun ortasına konumlandır

            // Kullanıcı adı etiketi
            Label lblKullaniciAdi = new Label();
            lblKullaniciAdi.Text = "Kullanıcı Adı";
            lblKullaniciAdi.ForeColor = Color.Black;
            lblKullaniciAdi.Font = new Font("Arial", 14, FontStyle.Bold);
            lblKullaniciAdi.Size = new Size(100, 30);
            lblKullaniciAdi.Location = new Point(65, 20);

            // Kullanıcı adı textbox
            
            txtKullaniciAdi.Size = new Size(150, 25);
            txtKullaniciAdi.Location = new Point(lblKullaniciAdi.Right + 10, lblKullaniciAdi.Top + 2);

            // Şifre etiketi
            Label lblSifre = new Label();
            lblSifre.Text = "Şifre";
            lblSifre.ForeColor = Color.Black;
            lblSifre.Font = new Font("Arial", 14, FontStyle.Bold);
            lblSifre.Size = new Size(100, 30);
            lblSifre.Location = new Point(65, lblKullaniciAdi.Bottom + 20);

            // Şifre textbox
            
            txtSifre.Size = new Size(150, 25);
            txtSifre.Location = new Point(lblSifre.Right + 10, lblSifre.Top + 2);
            txtSifre.PasswordChar = '*';

            // Giriş butonu
            Button btnGiris = new Button();
            btnGiris.Text = "Giriş";
            btnGiris.ForeColor = Color.White;
            btnGiris.BackColor = Color.FromArgb(34, 167, 240);
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.Font = new Font("Arial", 14, FontStyle.Bold);
            btnGiris.Size = new Size(100, 40);
            btnGiris.Location = new Point(150, txtSifre.Bottom + 40);
            btnGiris.Click += BtnGiris_Click;

            // Panela kontrolleri ekle
            panel.Controls.Add(lblKullaniciAdi);
            panel.Controls.Add(txtKullaniciAdi);
            panel.Controls.Add(lblSifre);
            panel.Controls.Add(txtSifre);
            panel.Controls.Add(btnGiris);

            // Forma paneli ekle
            this.Controls.Add(panel);
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "bilgisayar" && txtSifre.Text == "12345")
            {
                
                // Kullanıcı adı ve şifre doğru ise form1'e geç
                Form1 form1 = new Form1();
                this.Hide(); // Giriş formunu gizle
                form1.ShowDialog(); // Form1'i göster
                this.Close(); // Giriş formunu kapat
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Clear(); // Kullanıcı adı kutusunu temizle
                txtSifre.Clear(); // Şifre kutusunu temizle
                
            }
        }
    }
}
