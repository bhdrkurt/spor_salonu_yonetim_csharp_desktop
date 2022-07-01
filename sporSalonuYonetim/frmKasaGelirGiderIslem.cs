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
    public partial class frmKasaGelirGiderIslem : Form
    {
        public static GirisBilgi User { get; set; }
        public frmKasaGelirGiderIslem()
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
        SqlCommand cmd;
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

        private void gygidergetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT GenelYonetimGideri.aciklama FROM GenelYonetimGideri ORDER BY GenelYonetimGideri.aciklama ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbGenelYonetimGideri.Items.Add(dr["aciklama"].ToString());
            }
            con.Close();
        }
        private void btnKasaGelirTamamla_Click(object sender, EventArgs e)
        {
            sqlbaglanti gnl = new sqlbaglanti();
            SqlConnection con = new SqlConnection(gnl.conString);
            if (cmbGenelYonetimGideri.Text != "" && txtTutar.Text !="")
            {
                try
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO GenelYonetimGideri(aciklama,tutar) VALUES (@p1,@p2)", con);
                    komut.Parameters.AddWithValue("@p1", cmbGenelYonetimGideri.Text);
                    komut.Parameters.AddWithValue("@p2", txtTutar.Text);
                    komut.ExecuteNonQuery();
                    con.Close();
                    label7.ForeColor = Color.Green;
                    label7.Text = "Kayıt Yapıldı";
                }
                catch (Exception)
                {

                    label7.Text = "kayıt yapalamadı";
                    con.Close();
                }
            }
            else
            {
                label7.Text = "kayıt yapalamadı-";
            }
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                label1.Visible = true;
                panel1.Visible = true;
                label2.Visible = false;
                panel2.Visible = false;
            }
            else
            {
                label2.Visible = true;
                panel2.Visible = true;
                label1.Visible = false;
                panel1.Visible = false;
            }
        }

        private void rdbKasaGelir_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void rdbYonetimGider_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "False";
        }

        private void btnIslemiTamamla_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);

            

            if (txtKasaGelirAciklama.Text == "")
            {
                label6.Visible = true;
                label6.ForeColor = Color.Red;
                label6.Text = "Lütfen Açıklama giriniz.";
            }
            else if (txtKasaGelirTutar.Text == "")
            {
                label6.Visible = true;
                label6.ForeColor = Color.Red;
                label6.Text = "Lütfen Tutarı giriniz.";
            }
            else if (label12.Text == "")
            {
                label6.Visible = true;
                label6.ForeColor = Color.Red;
                label6.Text = "Lütfen İşlem Tipini Seçiniz.";
            }
            
            if (txtKasaGelirAciklama.Text != "" && txtKasaGelirTutar.Text != "" && label12.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO KasaGelirGider(kasaAciklama,kasaTutar,secim,islemtarihi) VALUES (@p1,@p2,@p3,@p4)", con);
                    komut.Parameters.AddWithValue("@p1", txtKasaGelirAciklama.Text);
                    komut.Parameters.AddWithValue("@p2", txtKasaGelirTutar.Text);
                    komut.Parameters.AddWithValue("@p3", label12.Text);
                    komut.Parameters.AddWithValue("@p3",Convert.ToDateTime(dateTimePicker1.Text));
                    komut.ExecuteNonQuery();
                    con.Close();

                    
                    label6.ForeColor = Color.Green;
                    label6.Text = "Kayıt Tamamlanmıştır.";
                    txtKasaGelirAciklama.Text = "";
                    txtKasaGelirTutar.Text = "";
                    label12.Text = "";
                    rdbGelir.Checked = false;
                    rdbGider.Checked = false;
                    label13.Visible = false;
                }
                catch (Exception)
                {
                   
                    label6.Text = "kayıt yapalamadı";
                    con.Close();
                }
            }
            else
            {
                label13.Visible = true;
                label13.ForeColor = Color.Orange;
                label13.Text = "Yazı Rengi Kırmızı Olan Yere Dikkat Ediniz.";
            }
        }
        

        private void rdbGelir_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "True";
        }

        private void rdbGider_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "False";
        }

        private void frmKasaGelirGiderIslem_Load(object sender, EventArgs e)
        {
            gygidergetir();
        }
    }
}

