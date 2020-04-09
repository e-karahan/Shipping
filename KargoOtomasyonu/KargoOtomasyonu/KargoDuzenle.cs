using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargoOtomasyonu
{
    public partial class KargoDuzenle : Form
    {
        public KargoDuzenle()
        {
            InitializeComponent();
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
                }
                else if (gbgonderici.Visible == true)
                {
                    gbgonderici.Visible = false;
                }
            }
            /*
             SELECT	  m.ID as 'Müşteri ID',
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
                 FROM Musteri m, 
                      KargoBilgi kb
                      WHERE m.ID = kb.Musteri_ID
      
             */

        }
    }
}
