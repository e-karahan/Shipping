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
        int gondericiid;
        public AdminControl()
        {
            InitializeComponent();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            adminbilgicek();
            gondericicek();
            gondericicek2();
            teslimalinan();
            teslimedilen();
            dagitimacikan();
            
        }
        private void tbtemizle()
        {
            tbgondericiad2.Text = "";
            tbgondericisoyad2.Text = "";
            tbgondericitc2.Text = "";
            tbgondericitel2.Text = "";
        }
        private void tbtemizle2()
        {
            tbbarkod.Text = "";
            tbgondericiid.Text = "";
            tbgondericiad.Text = "";
            tbgondericisoyad.Text = "";
            tbgondericitc.Text = "";
            tbgondericitel.Text = "";
            tbaliciad.Text = "";
            tbalicisoyad.Text = "";
            tbalicitel.Text = "";
            tbaliciadres.Text = "";
            tbkargoicerik.Text = "";

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
        private void gondericicek2()
        {
            listviewgonderici2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Ad"].ToString());
                Item.SubItems.Add(oku["Soyad"].ToString());
                Item.SubItems.Add(oku["TC"].ToString());
                Item.SubItems.Add(oku["Telefon"].ToString());
                listviewgonderici2.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void gondericisil()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Musteri where ID=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", gondericiid);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        private void gondericiduzenle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Musteri set Ad=@p1,Soyad=@p2,TC=@p3,Telefon=@p4 where ID=@p5",baglanti);
            komut.Parameters.AddWithValue("@p1",tbgondericiad2.Text);
            komut.Parameters.AddWithValue("@p2",tbgondericisoyad2.Text);
            komut.Parameters.AddWithValue("@p3",tbgondericitc2.Text);
            komut.Parameters.AddWithValue("@p4",tbgondericitel2.Text);
            komut.Parameters.AddWithValue("@p5",gondericiid);
            komut.ExecuteNonQuery();
            baglanti.Close();

            
           
        }
        private void gondericiekle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Musteri(Ad,Soyad,TC,Telefon) values(@p1,@p2,@p3,@p4)",baglanti);
            komut.Parameters.AddWithValue("@p1",tbgondericiad2.Text);
            komut.Parameters.AddWithValue("@p2",tbgondericisoyad2.Text);
            komut.Parameters.AddWithValue("@p3",tbgondericitc2.Text);
            komut.Parameters.AddWithValue("@p4",tbgondericitel2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
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
        private void kargoekle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(@"insert into KargoBilgi(Barkod,Musteri_ID,Alici_Ad,Alici_Soyad,Alici_Tel,Alici_Adres,Durum,Icerik,Hassaslik) 
                                                                                                    values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",baglanti);
            komut.Parameters.AddWithValue("@p1",tbbarkod.Text);
            komut.Parameters.AddWithValue("@p2",tbgondericiid.Text);
            komut.Parameters.AddWithValue("@p3",tbaliciad.Text);
            komut.Parameters.AddWithValue("@p4",tbalicisoyad.Text);
            komut.Parameters.AddWithValue("@p5",tbalicitel.Text);
            komut.Parameters.AddWithValue("@p6",tbaliciadres.Text);
            komut.Parameters.AddWithValue("@p7",cbdurum.Text);
            komut.Parameters.AddWithValue("@p8",tbkargoicerik.Text);
            komut.Parameters.AddWithValue("@p9",cbhassas.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();        
        }
        private void gondericiadcek()
        {
            listviewgonderici.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri where Ad like '%"+tbara.Text+"%'",baglanti);
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
        private void gondericiadcek2()
        {
            listviewgonderici2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri where Ad like '%" + tbara2.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Ad"].ToString());
                Item.SubItems.Add(oku["Soyad"].ToString());
                Item.SubItems.Add(oku["TC"].ToString());
                Item.SubItems.Add(oku["Telefon"].ToString());
                listviewgonderici2.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void gondericitccek2()
        {
            listviewgonderici2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri where TC like '%" + tbara2.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Ad"].ToString());
                Item.SubItems.Add(oku["Soyad"].ToString());
                Item.SubItems.Add(oku["TC"].ToString());
                Item.SubItems.Add(oku["Telefon"].ToString());
                listviewgonderici2.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void teslimedilen()
        {
            listteslim.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KargoBilgi where Durum='Teslim Edildi'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Barkod"].ToString());
                Item.SubItems.Add(oku["Alici_Ad"].ToString());
                Item.SubItems.Add(oku["Alici_Adres"].ToString());
                Item.SubItems.Add(oku["Icerik"].ToString());
                listteslim.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void dagitimacikan()
        {
            listdagitim.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KargoBilgi where Durum='Dağıtıma Çıktı'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Barkod"].ToString());
                Item.SubItems.Add(oku["Alici_Ad"].ToString());
                Item.SubItems.Add(oku["Alici_Adres"].ToString());
                Item.SubItems.Add(oku["Icerik"].ToString());
                listdagitim.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void teslimalinan()
        {
            listalinan.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KargoBilgi where Durum='Teslim Alındı'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Barkod"].ToString());
                Item.SubItems.Add(oku["Alici_Ad"].ToString());
                Item.SubItems.Add(oku["Alici_Adres"].ToString());
                Item.SubItems.Add(oku["Icerik"].ToString());
                listalinan.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void gondericitccek()
        {
            listviewgonderici.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri where TC like '%" + tbara.Text + "%'", baglanti);
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
        private void teslimalinanara()
        {
            listalinan.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KargoBilgi where Barkod like '%" + tbalinanara.Text + "%' and Durum='Teslim Alındı'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Barkod"].ToString());
                Item.SubItems.Add(oku["Alici_Ad"].ToString());
                Item.SubItems.Add(oku["Alici_Adres"].ToString());
                Item.SubItems.Add(oku["Icerik"].ToString());
                listalinan.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void dagitamacikanara()
        {
            listdagitim.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KargoBilgi where Barkod like '%" + tbdagitimara.Text + "%' and Durum='Dağıtıma Çıktı'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Barkod"].ToString());
                Item.SubItems.Add(oku["Alici_Ad"].ToString());
                Item.SubItems.Add(oku["Alici_Adres"].ToString());
                Item.SubItems.Add(oku["Icerik"].ToString());
                listdagitim.Items.Add(Item);
            }
            baglanti.Close();
        }
        private void teslimedilenara()
        {
            listteslim.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KargoBilgi where Barkod like '%" + tbteslimara.Text + "%' and Durum='Teslim Edildi'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = oku["ID"].ToString();
                Item.SubItems.Add(oku["Barkod"].ToString());
                Item.SubItems.Add(oku["Alici_Ad"].ToString());
                Item.SubItems.Add(oku["Alici_Adres"].ToString());
                Item.SubItems.Add(oku["Icerik"].ToString());
                listteslim.Items.Add(Item);
            }
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

        private void btngondericiekle_Click(object sender, EventArgs e)
        {
            if (tbgondericiad2.Text == "" || tbgondericisoyad2.Text == "" || tbgondericitel2.Text == "" || tbgondericitc2.Text == "")
            {
                MessageBox.Show("Bilgileri Boş bırakmayınız");
            }
            else
            {
                gondericiekle();
                MessageBox.Show("Gönderici Ekleme Başarılı");
                gondericicek();
                tbtemizle();
            }
        }

        private void btngondericiduzenle_Click(object sender, EventArgs e)
        {
            if (tbgondericiad2.Text == "" || tbgondericisoyad2.Text == "" || tbgondericitel2.Text == "" || tbgondericitc2.Text == "")
            {
                MessageBox.Show("Bilgileri Boş bırakmayınız");
            }
            else
            {
                gondericiduzenle();
                MessageBox.Show("Gönderici Duzenleme Başarılı");
                gondericicek();
                tbtemizle();
            }
        }

        private void listviewgonderici_Click(object sender, EventArgs e)
        {
            gondericiid = int.Parse(listviewgonderici.SelectedItems[0].SubItems[0].Text);
            tbgondericiad2.Text=listviewgonderici.SelectedItems[0].SubItems[1].Text;
            tbgondericisoyad2.Text = listviewgonderici.SelectedItems[0].SubItems[2].Text;
            tbgondericitc2.Text = listviewgonderici.SelectedItems[0].SubItems[3].Text;
            tbgondericitel2.Text = listviewgonderici.SelectedItems[0].SubItems[4].Text;
        }

        private void btngondericisil_Click(object sender, EventArgs e)
        {
            if (tbgondericiad2.Text == "" || tbgondericisoyad2.Text == "" || tbgondericitel2.Text == "" || tbgondericitc2.Text == "")
            {
                MessageBox.Show("Bilgileri Boş bırakmayınız");
            }
            else
            {
                gondericisil();
                MessageBox.Show("Gönderici Silme Başarılı");
                gondericicek();
                tbtemizle();
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void listviewgonderici2_Click(object sender, EventArgs e)
        {
            tbgondericiid.Text = listviewgonderici2.SelectedItems[0].SubItems[0].Text;
            tbgondericiad.Text = listviewgonderici2.SelectedItems[0].SubItems[1].Text;
            tbgondericisoyad.Text = listviewgonderici2.SelectedItems[0].SubItems[2].Text;
            tbgondericitc.Text = listviewgonderici2.SelectedItems[0].SubItems[3].Text;
            tbgondericitel.Text = listviewgonderici2.SelectedItems[0].SubItems[4].Text;
        }

        private void btnkargoekle_Click(object sender, EventArgs e)
        {
            
            kargoekle();
            tbtemizle2();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void btnkargoduzenle_Click(object sender, EventArgs e)
        {

        }

        private void tbara_TextChanged(object sender, EventArgs e)
        {
            if (rbad.Checked)
            {
                gondericiadcek();
            }
            else if(rbtc.Checked)
            {
                gondericitccek();
            }
        }

        private void tbara2_TextChanged(object sender, EventArgs e)
        {
            if (rbad2.Checked)
            {
                gondericiadcek2();
            }
            else if (rbtc2.Checked)
            {
                gondericitccek2();
            }
        }

        private void kargoduzenle_Click(object sender, EventArgs e)
        {
           
                KargoDuzenle duzenle = new KargoDuzenle();
                duzenle.Show();


        }

        private void listalinan_Click(object sender, EventArgs e)
        {
            
            lblkargoid.Text = listalinan.SelectedItems[0].SubItems[0].Text;
        }

        private void listdagitim_Click(object sender, EventArgs e)
        {
            lblkargoid2.Text = listdagitim.SelectedItems[0].SubItems[0].Text;
        }

        private void listteslim_Click(object sender, EventArgs e)
        {
            lblkargoid3.Text = listteslim.SelectedItems[0].SubItems[0].Text;
        }

        private void tbalinanara_TextChanged(object sender, EventArgs e)
        {
            teslimalinanara();
        }

        private void tbdagitimara_TextChanged(object sender, EventArgs e)
        {
            dagitamacikanara();
        }

        private void tbteslimara_TextChanged(object sender, EventArgs e)
        {
            teslimedilenara();
        }

        private void btndagitim_Click(object sender, EventArgs e)
        {
            if (lblkargoid.Text == "00")
            {
                MessageBox.Show("Lütfen Listeden Seçim Yapınız");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update KargoBilgi set Durum='Dağıtıma Çıktı' where ID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", lblkargoid.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                teslimedilen();
                teslimalinan();
                dagitimacikan();
            }
           
            

        }

        private void btnteslim_Click(object sender, EventArgs e)
        {
            if (lblkargoid2.Text == "00")
            {
                MessageBox.Show("Lütfen Listeden Seçim Yapınız");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update KargoBilgi set Durum='Teslim Edildi' where ID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", lblkargoid2.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                teslimedilen();
                teslimalinan();
                dagitimacikan();
            }
           
        }

        private void listalinan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
