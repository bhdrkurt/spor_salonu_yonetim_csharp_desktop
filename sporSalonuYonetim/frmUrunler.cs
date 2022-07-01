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
    public partial class frmUrunler : Form
    {
        public static GirisBilgi User { get; set; }
        public frmUrunler()
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
        SqlCommand cmd;
        sqlbaglanti gnl = new sqlbaglanti();

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

        private void kategorigetir(){
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Kategoriler.kategoriAdi FROM Kategoriler ORDER BY Kategoriler.kategoriAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
          
           
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbKategoriAdi.Items.Add(dr["kategoriAdi"].ToString());
            }
            con.Close();
            }

        private void frmUrunler_Load_1(object sender, EventArgs e)
        {
            kategorigetir();
        }

        private void btnPaketKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            bool kayitkontrol = false;
            con.Open();
            SqlCommand selectsorgu = new SqlCommand("SELECT Urunler.urunAdi FROM Urunler WHERE urunAdi='" + txtUrunAdi.Text + "'", con);
            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            con.Close();
            if (kayitkontrol == false)
            {

                if (cmbKategoriAdi.Text == "")
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Red;
                    label11.Text = "Lütfen Kategori İsmi giriniz.";
                }
                else if (txtUrunAdi.Text == "")
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Red;
                    label11.Text = "Lütfen Ürün Adını giriniz.";
                }
                else if (txtAlisFiyati.Text == "")
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Red;
                    label11.Text = "Lütfen Alış Fiyatını giriniz.";
                }
                else if (txtSatisFiyati.Text == "")
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Red;
                    label11.Text = "Lütfen Satış Fiyatını giriniz.";
                }
                else if (txtMaxOran.Text == "")
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Red;
                    label11.Text = "Lütfen Maximize Oranı giriniz.";
                }

                if (txtUrunAdi.Text != "" && txtAlisFiyati.Text !="" && txtSatisFiyati.Text != "" && txtMaxOran.Text !="")
                {
                    try
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("INSERT INTO Urunler(urunAdi,alisFiyati,satisFiyati,maximizeOran,icerik,barkod) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", con);
                        komut.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
                        komut.Parameters.AddWithValue("@p2", txtAlisFiyati.Text);
                        komut.Parameters.AddWithValue("@p3", txtSatisFiyati.Text);
                        komut.Parameters.AddWithValue("@p4", txtMaxOran.Text);
                        komut.Parameters.AddWithValue("@p5", txtIcerik.Text);
                        komut.Parameters.AddWithValue("@p6", txtBarkod.Text);
                        komut.ExecuteNonQuery();
                        con.Close();
                        label11.Visible = true;
                        label11.ForeColor = Color.Green;
                        label11.Text = "Kayıt Tamamlanmıştır.";
                        cmbKategoriAdi.Text = "";
                        txtUrunAdi.Text = "";
                        txtAlisFiyati.Text = "";
                        txtSatisFiyati.Text = "";
                        txtMaxOran.Text = "";
                        txtIcerik.Text = "";
                        txtBarkod.Text = "";
                        label12.Text = "";
                    }
                    catch (Exception)
                    {
                        label11.Visible = true;
                        label11.ForeColor = Color.Orange;
                        label11.Text = "kayıt yapalamadı";
                        con.Close();
                    }
                }
                else
                {
                    label12.Visible = true;
                    label12.ForeColor = Color.Orange;
                    label12.Text = "Yazı Rengi Kırmızı Olan Yere Dikkat Ediniz.";
                }
            }
        }

        private void txtAlisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
