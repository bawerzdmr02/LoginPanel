using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace LoginApp
{
    public partial class FrmKayitOl : Form
    {
        public FrmKayitOl()
        {
            InitializeComponent();
        }

        private void FrmKayitOl_Load(object sender, EventArgs e)
        {

        }


        SqlConnection cnn = new SqlConnection("Server = bawerpc\\SQLEXPRESS;Database = UserData;Trusted_Connection=True");


        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            
            if (MtxtSifre.Text == MtxtSifre2.Text){

                string sifre = MtxtSifre.Text;
                string hashedSifre = HashSifre(sifre);

                cnn.Open();
                string query = "INSERT INTO Users (TCKimlik, Sifre) VALUES (@tc, @sifre)";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tc", MtxtTC.Text);
                cmd.Parameters.AddWithValue("@sifre", hashedSifre);
                cmd.ExecuteNonQuery();
                cnn.Close();

                MessageBox.Show("Kayit Olusturulmustur :)");

                if(ChechHatirla.Checked == Enabled)
                {
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.tc = MtxtTC.Text;
                    form1.Show();
                }
                else
                {
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }

            }
            else{
                MessageBox.Show("Tc kimlik numaranız veya şifreniz hatalidir.\n Lütfen tekrar deneyiniz.");
            }

            

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
