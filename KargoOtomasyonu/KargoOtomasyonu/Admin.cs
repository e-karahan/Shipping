using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace KargoOtomasyonu
{
    public partial class Admin : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NVUBKFR;Initial Catalog=Kargo;Integrated Security=True");
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Admin where Kullanici_Adi=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",tbka.Text);
            komut.Parameters.AddWithValue("@p2",tbsf.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                AdminControl admin = new AdminControl();
                admin.adminid = oku["ID"].ToString();
                this.Hide();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Bilgiler Yanlış tekrar deneyin");
            }
            baglanti.Close();
        }
    }
}
