using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


namespace LoginApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MtxtTC.Text = tc;
        }

        public string tc;

        SqlConnection cnn = new SqlConnection("Server = bawerpc\\SQLEXPRESS;Database = UserData;Trusted_Connection=True");

        int hak = 3;

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            string girilenSifre = MtxtSifre.Text;
            string hashedSifre = HashSifre(girilenSifre);

            cnn.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE TCKimlik = @tc AND Sifre = @sifre";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tc", MtxtTC.Text);
            cmd.Parameters.AddWithValue("@sifre", hashedSifre);

            int sonuc = (int)cmd.ExecuteScalar();
            if (sonuc > 0)
            {
                MessageBox.Show("Giriş Başarılı");
                Application.Exit();
            }
            else
            {
                hak -= 1;
                LblHak.Text = "Giriş Hakkınız : " + hak;
                if (hak == 0)
                {
                    MessageBox.Show("3 kez hatalı giriş yaptınız uygulama kapanıyor...");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Şifre hatalı lütfen tekrar deneyiniz.");
                }

            }
            cnn.Close();
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmKayitOl frmKayitOl = new FrmKayitOl();
            frmKayitOl.Show();
        }

        public string HashSifre(string sifre)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(sifre);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }


    }
}
