using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soru1Sinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button b;
        LinkedList ll = new LinkedList();

        private void Tiklandi(object sender,EventArgs e)
        {
            //Koltuk butonlarına tıklandığında koltuk numaraları textboxlara çekildi.
            b = (Button)sender;
            if(b.BackColor==Color.GreenYellow)
            {
                txtKoltukNo.Text = b.Text;
            }
            if(b.BackColor==Color.Red)
            {
                txtIptalKoltukNo.Text = b.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
           for(int i=60;i>=1;i--)
           {
               m.Ad = null;
               m.Soyad = null;
               m.KoltukNo = -1;
               ll.InsertFirst(m);
               //Her müşteri için musteri listesine başlangıçta null ve -1 değerleri atandı.
           }

        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.Ad = txtAd.Text;
            m.Soyad = txtSoyad.Text;
            m.KoltukNo =Convert.ToInt32(txtKoltukNo.Text);
            ll.InsertPos(m);//Müşteri bilgilerine göre müşteri listeye eklenmek için gönderildi.
            b.BackColor = Color.Red;//Eklendikten sonra koltuğun dolu olduğunu göstermek için koltuk butonu kırmızı yapıldı.
            lblizleyiciSayisi.Text = ll.Size.ToString();//O anki salondaki müşteri sayısı hesaplandı.
            MessageBox.Show("BİLET ALMA İŞLEMİ TAMAMLANDI");
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtKoltukNo.Text = "";
            
            
        }

        private void btnBiletİptal_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.KoltukNo = Convert.ToInt32(txtIptalKoltukNo.Text);
            ll.DeletePos(m);//Müşteri bilgilerine göre müşteri listeden silinmek için gönderildi.
            b.BackColor = Color.GreenYellow;//Silidikten sonra koltuğun boş olduğunu göstermek için koltuk butonu yeşil yapıldı.
            if(ll.Size>=0)
            lblizleyiciSayisi.Text = ll.Size.ToString();//O anki salondaki müşteri sayısı hesaplandı.
            MessageBox.Show("BİLET İPTAL ETME İŞLEMİ TAMAMLANDI");
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtKoltukNo.Text = "";

        }

        private void btnKoltukBul_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            Node n = new Node();
            m.Ad = txtKoltukBulAd.Text;
            m.Soyad = txtKoltukBulSoyad.Text;
            n=ll.GetElement(m);//Müşterinin bilgileri koltuk numarasını bulmak için gönderildi.
            if(n==null)
            {
                MessageBox.Show("BÖYLE BİR MÜŞTERİ YOK!");
            }
            else
            MessageBox.Show("Koltuk Numarası:" + n.Data.KoltukNo);
            txtKoltukBulAd.Text = "";
            txtKoltukBulSoyad.Text = "";
            
        }

  
    }
}
