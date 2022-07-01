using sporSalonuYonetim.Models;
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

namespace sporSalonuYonetim
{
    public partial class frmYeniKayitEkle : Form
    {
        public static GirisBilgi User { get; set; }
        public frmYeniKayitEkle()
        {
            InitializeComponent();
            if (frmAnasayfa.User.Roles.Contains("admin"))
            {
                menuStrip1.Visible = true;
            }
            else if (frmAnasayfa.User.Roles.Contains("resepsiyon"))
            {
                hızlıErişimToolStripMenuItem.Visible = true;
                üyeİşlemleriToolStripMenuItem.Visible = true;
                tanımlamalarToolStripMenuItem.Visible = true;
                listelemeToolStripMenuItem.Visible = true;
                toptancıİşlemleriToolStripMenuItem.Visible = false;
                kasaToolStripMenuItem.Visible = false;
                raporlarToolStripMenuItem.Visible = false;
                ayarlarToolStripMenuItem.Visible = false;
                yardımToolStripMenuItem.Visible = true;
                anasayfaToolStripMenuItem.Visible = true;
            }

            else if (frmAnasayfa.User.Roles.Contains("vitaminbar"))
            {
                hızlıErişimToolStripMenuItem.Visible = false;
                üyeİşlemleriToolStripMenuItem.Visible = false;
                tanımlamalarToolStripMenuItem.Visible = false;
                listelemeToolStripMenuItem.Visible = false;
                toptancıİşlemleriToolStripMenuItem.Visible = false;
                kasaToolStripMenuItem.Visible = false;
                raporlarToolStripMenuItem.Visible = false;
                ayarlarToolStripMenuItem.Visible = false;
                yardımToolStripMenuItem.Visible = false;
                anasayfaToolStripMenuItem.Visible = false;
            }
        }
        sqlbaglanti gnl = new sqlbaglanti();

        //sql kodlarını yazarken en sonda bgl.baglanti() yapıcaz ki sql baglantısını açsın



        #region menu
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAnasayfa frm = new frmAnasayfa();
            frm.Show();
        }

        private void yeniKayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmYeniKayitEkle frm = new frmYeniKayitEkle();
            frm.Show();
        }

        private void ürünSatışEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUrunSatisEkrani frm = new frmUrunSatisEkrani();
            frm.Show();
        }

        private void üyeGirişÇıkışEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUyeGirisCikisEkrani frm = new frmUyeGirisCikisEkrani();
            frm.Show();
        }

        private void yeniKayıtEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmYeniKayitEkle frm = new frmYeniKayitEkle();
            frm.Show();
        }

        private void aboneKayıtıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUyeSil frm = new frmUyeSil();
            frm.Show();
        }

        private void aboneKayıtıEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAboneKayitEkle frm = new frmAboneKayitEkle();
            frm.Show();
        }

        private void aktifPasifÜyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAktifPasifUyeler frm = new frmAktifPasifUyeler();
            frm.Show();
        }

        private void abonelikPaketleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbonelikPaketleri frm = new frmAbonelikPaketleri();
            frm.Show();
        }

        private void bankalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBankalar frm = new frmBankalar();
            frm.Show();
        }

        private void akıllıGeçişKartıTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKartTanimlama frm = new frmKartTanimlama();
            frm.Show();
        }

        private void ürünKategorileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUrunKategorileri frm = new frmUrunKategorileri();
            frm.Show();
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUrunler frm = new frmUrunler();
            frm.Show();
        }

        private void stokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStok frm = new frmStok();
            frm.Show();
        }

        private void ürünSatışEkranıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUrunSatisEkrani frm = new frmUrunSatisEkrani();
            frm.Show();
        }

        private void üyeleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUyeleriListele frm = new frmUyeleriListele();
            frm.Show();
        }

        private void abonelikPaketleriniListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbonelikPaketleriListele frm = new frmAbonelikPaketleriListele();
            frm.Show();
        }

        private void ürünleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUrunleriListele frm = new frmUrunleriListele();
            frm.Show();
        }

        private void toptancılarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmToptancilariListele frm = new frmToptancilariListele();
            frm.Show();
        }
        private void genelYönetimGiderleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGenelYonetimGiderListele frm = new frmGenelYonetimGiderListele();
            frm.Show();

        }

        private void kasaGelirGiderListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKasaGelirGiderListele frm = new frmKasaGelirGiderListele();
            frm.Show();
        }

        private void toptancıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmToptanciEkle frm = new frmToptanciEkle();
            frm.Show();
        }

        private void toptancıSilDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmToptanciSilDuzenle frm = new frmToptanciSilDuzenle();
            frm.Show();
        }

        private void işlemYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmToptancislemYap frm = new frmToptancislemYap();
            frm.Show();
        }

        private void genelKasaRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGenelKasaRaporu frm = new frmGenelKasaRaporu();
            frm.Show();
        }

        private void üyeAbonelikRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUyeRaporu frm = new frmUyeRaporu();
            frm.Show();
        }

        private void ürünSatışRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUrunSatisRaporu frm = new frmUrunSatisRaporu();
            frm.Show();
        }

        private void toptancıRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmToptanciRaporu frm = new frmToptanciRaporu();
            frm.Show();
        }

        private void genelYönetimGiderRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGenelYonetimGiderRaporu frm = new frmGenelYonetimGiderRaporu();
            frm.Show();
        }

        private void kasaGelirGiderRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKasaGelirGiderRaporu frm = new frmKasaGelirGiderRaporu();
            frm.Show();
        }

        private void kullanıcılaristemciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullanicilar frm = new frmKullanicilar();
            frm.Show();
        }

        private void firmaBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFirmaBilgileri frm = new frmFirmaBilgileri();
            frm.Show();
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPersonelEkle frm = new frmPersonelEkle();
            frm.Show();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmYardim frm = new frmYardim();
            frm.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGirisPaneli frm = new frmGirisPaneli();
            frm.Show();
        }

        private void kasaGelirGiderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKasaGelirGiderIslem frm = new frmKasaGelirGiderIslem();
            frm.Show();
        }

        private void genelYönetimGideriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGenelYonetimGiderEkle frm = new frmGenelYonetimGiderEkle();
            frm.Show();
        }
        #endregion
        private void btnAboneKaydiOlustur_Click(object sender, EventArgs e)
        {
            #region tckimliknosorgulaması
            SqlConnection con = new SqlConnection(gnl.conString);
            bool kayitkontrol = false;
            con.Open();
            SqlCommand selectsorgu = new SqlCommand("SELECT KayitTable.tcKimlikNo FROM KayitTable WHERE tcKimlikNo='" + txtTcKimlikNo.Text + "'", con);
            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            con.Close();
            #endregion
            #region tckimlik aynısı yoksa
            if (kayitkontrol == false)
            {

                if (txtAdSoyad.Text == "")
                {
                    label5.ForeColor = Color.Red;
                    label5.Visible = true;
                    label5.Text = "Lütfen isim ve soyisim giriniz.";
                }
                else if (txtTcKimlikNo.Text == "")
                {
                    label5.ForeColor = Color.Red;
                    label5.Visible = true;
                    label5.Text = "Lütfen TC Kimlik Numarasını Boş bıraktınız.";
                }
                else if (txtTcKimlikNo.TextLength != 11)
                {
                    label5.ForeColor = Color.Red;
                    label5.Visible = true;
                    label5.Text = "Lütfen TC Kimlik Numarası11 haneli değil.";
                }
                else if (txtCepTelefonu.Text == "")
                {
                    label5.ForeColor = Color.Red;
                    label5.Visible = true;
                    label5.Text = "Lütfen Telefon  Numarasını Boş bıraktınız.";
                }
                else if (txtCepTelefonu.TextLength != 11)
                {
                    label5.ForeColor = Color.Red;
                    label5.Visible = true;
                    label5.Text = "Lütfen Telefon  Numarasını Eksik Girdiniz.";
                }
                else if (label6.Text == "")
                {
                    label5.ForeColor = Color.Red;
                    label5.Visible = true;
                    label5.Text = "Lütfen Cinsiyet Seçiniz.";
                }
                #endregion

                #region veritabanına yazdırıldığı yer
                if (txtAdSoyad.Text != "" && txtTcKimlikNo.Text != "" && txtTcKimlikNo.TextLength == 11 && txtCepTelefonu.Text != "" && txtCepTelefonu.TextLength == 11 && label6.Text != "")
                {
                        con.Open();
                        SqlCommand komut = new SqlCommand("INSERT INTO KayitTable(adiSoyadi,tcKimlikNo,cepTelefon,cinsiyet,adres,acilDurumYakin,acilDurumYakinTel,kayitTarihi) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", con);
                        komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                        komut.Parameters.AddWithValue("@p2", txtTcKimlikNo.Text);
                        komut.Parameters.AddWithValue("@p3", txtCepTelefonu.Text);
                        komut.Parameters.AddWithValue("@p4", label6.Text);
                        komut.Parameters.AddWithValue("@p5", txtAdres.Text);
                        komut.Parameters.AddWithValue("@p6", txtAcilDurumYakini.Text);
                        komut.Parameters.AddWithValue("@p7", txtAcilDurumTelefon.Text);
                        komut.Parameters.AddWithValue("@p8", Convert.ToDateTime(dateTimePicker1.Text));
                        komut.ExecuteNonQuery();
                        con.Close();
                        label5.ForeColor = Color.Green;
                        label5.Visible = true;
                        label7.Visible = false;
                        label5.Text="Kayıt Tamamlanmıştır.";
                        txtAdSoyad.Text = "";
                        txtCepTelefonu.Text = "";
                        txtTcKimlikNo.Text = "";
                        txtAdres.Text = "";
                        txtAcilDurumYakini.Text = "";
                        txtAcilDurumTelefon.Text = "";
                        rdbBay.Checked = false;
                        rdbBayan.Checked = false;
                        label7.Visible = false;
                }
                else
                {
                    label7.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label7.Text="Yazı Rengi Kırmızı Olan Yere Dikkat Ediniz.";
                    label5.Text = "kayıt yapalamadı";
                    con.Close();

                }
                
                
            }
            else
            {
                label5.Text = "Lütfen boş alanları doldurunuz.";
            }
        }
        #endregion
        private void rdbBay_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            label6.Text = "True";
        }

        private void rdbBayan_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            label6.Text = "False";
        }

        private void txtAcilDurumTelefon_TextChanged(object sender, EventArgs e)
        {
           // btnAboneKaydiOlustur.Enabled = true;
        }

        private void txtTcKimlikNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCepTelefonu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAcilDurumTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmYeniKayitEkle_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
        }
    }
}
