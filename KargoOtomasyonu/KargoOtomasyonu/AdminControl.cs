using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace KargoOtomasyonu
{
    public partial class AdminControl : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NVUBKFR;Initial Catalog=Kargo;Integrated Security=True");
        public string adminid; //ADmin id cektik
        public AdminControl()
        {
            InitializeComponent();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            adminbilgicek();
            
        }
        private void adminbilgicek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Admin where ID=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", adminid);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                tbka.Text = oku["Kullanici_Adi"].ToString();
                tbsifre.Text = oku["Sifre"].ToString();

            }
            tbadminıd.Text = adminid;
            baglanti.Close();
        }
        private void btnkapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bilgilerguncelle_Click(object sender, EventArgs e)
        {
            if (tbka.Text == "" || tbsifre.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Admin set Kullanici_Adi=@p1,Sifre=@p2 where ID=@p3", baglanti);
                komut.Parameters.AddWithValue("@p1", tbka.Text);
                komut.Parameters.AddWithValue("@p2", tbsifre.Text);
                komut.Parameters.AddWithValue("@p3", adminid);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme Başarılı");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
