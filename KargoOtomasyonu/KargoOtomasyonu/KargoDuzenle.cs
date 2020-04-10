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
    public partial class KargoDuzenle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NVUBKFR;Initial Catalog=Kargo;Integrated Security=True");
        public KargoDuzenle()
        {
            InitializeComponent();
        }
        private void kargobilgicek()
        {
            listduzenle.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand(@"SELECT
                                                        m.ID as 'Müşteri ID',  
                                                        kb.ID as 'Kargo ID',	
                                                        m.Ad as'Gönderici Adı',
                                                        m.Soyad as 'Gönderici Soyadı',
                                                        m.TC as 'Gönderici TC',
                                                        m.Telefon as 'Gönderici Telefon',
                                                        kb.Barkod as 'Kargo Barkod',
                                                        kb.Alici_Ad as 'Alıcı Adı',
                                                        kb.Alici_Soyad as 'Alıcı Soyadı',
                                                        kb.Alici_Tel as 'Alıcı Telefonu',
                                                        kb.Alici_Adres as 'Alıcı Adresi',
                                                        kb.Gonderim_Tarih as 'Gönderim Tarihi',
                                                        kb.Durum as 'Kargo Durumu',
                                                        kb.Icerik as 'Kargo İçeriği',
                                                        kb.Hassaslik as 'Kargo Hassaslığı'		  
                                                        FROM 
                                                        Musteri m,KargoBilgi kb
                                                        WHERE 
                                                        m.ID = kb.Musteri_ID", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["Müşteri ID"].ToString();
                Item.SubItems.Add(oku["Kargo ID"].ToString());
                Item.SubItems.Add(oku["Gönderici Adı"].ToString());
                Item.SubItems.Add(oku["Gönderici Soyadı"].ToString());
                Item.SubItems.Add(oku["Gönderici TC"].ToString());
                Item.SubItems.Add(oku["Gönderici Telefon"].ToString());
                Item.SubItems.Add(oku["Kargo Barkod"].ToString());
                Item.SubItems.Add(oku["Alıcı Adı"].ToString());
                Item.SubItems.Add(oku["Alıcı Soyadı"].ToString());
                Item.SubItems.Add(oku["Alıcı Telefonu"].ToString());
                Item.SubItems.Add(oku["Alıcı Adresi"].ToString());
                Item.SubItems.Add(oku["Gönderim Tarihi"].ToString());
                Item.SubItems.Add(oku["Kargo Durumu"].ToString());
                Item.SubItems.Add(oku["Kargo İçeriği"].ToString());
                Item.SubItems.Add(oku["Kargo Hassaslığı"].ToString());
                listduzenle.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void gondericicek()
        {
            listviewgonderici.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri",baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Ad"].ToString());
                Item.SubItems.Add(oku["Soyad"].ToString());
                Item.SubItems.Add(oku["TC"].ToString());
                Item.SubItems.Add(oku["Telefon"].ToString());    
                listviewgonderici.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void temizle()
        {
            tbgondericiid.Text = "";
            tbkargoid2.Text = "";
            tbgondericiad2.Text = "";
            tbgondericisoyad2.Text = "";
            tbgondericitel2.Text = "";
            tbgondericitc2.Text = "";
        }

        private void btnkargodegistir_Click(object sender, EventArgs e)
        {
            if (tbkargoid.Text == "")
            {
                MessageBox.Show("Lütfen Listeden Seçim Yapınız");
            }
            else
            {
                if (gbgonderici.Visible == false)
                {
                    gbgonderici.Visible = true;
                    tbkargoid2.Text = tbkargoid.Text;
                }
                else if (gbgonderici.Visible == true)
                {
                    gbgonderici.Visible = false;
                    tbkargoid2.Text="";
                }
            }
  

        }

        private void KargoDuzenle_Load(object sender, EventArgs e)
        {
            kargobilgicek();
            gondericicek();
        }

        private void listduzenle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listduzenle_Click(object sender, EventArgs e)
        {
            tbkargoid.Text= listduzenle.SelectedItems[0].SubItems[1].Text;
            tbbarkod.Text= listduzenle.SelectedItems[0].SubItems[6].Text;
           tbaliciad.Text = listduzenle.SelectedItems[0].SubItems[7].Text;
            tbalicisoyad.Text= listduzenle.SelectedItems[0].SubItems[8].Text;
            tbalicitel.Text= listduzenle.SelectedItems[0].SubItems[9].Text;
            tbaliciadres.Text= listduzenle.SelectedItems[0].SubItems[10].Text;
           cbdurum.Text = listduzenle.SelectedItems[0].SubItems[12].Text;
           tbkargoicerik.Text = listduzenle.SelectedItems[0].SubItems[13].Text;
           cbhassas.Text = listduzenle.SelectedItems[0].SubItems[14].Text;
           gbgonderici.Visible = false;
           
        }

        private void listviewgonderici_Click(object sender, EventArgs e)
        {
            tbgondericiid.Text = listviewgonderici.SelectedItems[0].SubItems[0].Text;     
            tbgondericiad2.Text = listviewgonderici.SelectedItems[0].SubItems[1].Text;
            tbgondericisoyad2.Text = listviewgonderici.SelectedItems[0].SubItems[2].Text;
            tbgondericitc2.Text = listviewgonderici.SelectedItems[0].SubItems[3].Text;
            tbgondericitel2.Text = listviewgonderici.SelectedItems[0].SubItems[4].Text;
        }

        private void btngondericiekle_Click(object sender, EventArgs e)
        {
            if (tbgondericiid.Text == "")
            {
                MessageBox.Show("Lütfen Listeden Seçim Yapınız");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update KargoBilgi set Musteri_ID=@p1 where ID=@p2",baglanti);
                komut.Parameters.AddWithValue("@p1", tbgondericiid.Text);
                komut.Parameters.AddWithValue("@p2", tbkargoid2.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();              
                temizle();
                kargobilgicek();
                gbgonderici.Visible = false;
                
            }
        }

        private void listviewgonderici_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
