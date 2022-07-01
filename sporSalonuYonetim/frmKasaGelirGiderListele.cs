﻿using sporSalonuYonetim.Models;
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
    public partial class frmKasaGelirGiderListele : Form
    {
        int giderisil;
        int kasagelirgiderid;
        sqlbaglanti gnl = new sqlbaglanti();
        SqlDataAdapter da;
        public static GirisBilgi User { get; set; }
        public frmKasaGelirGiderListele()
        {
            InitializeComponent();
            #region yetkiler
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
            #endregion
        }
        #region giderler
      
        private void gidersayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(kasaGelirGiderID) FROM KasaGelirGider WHERE secim='False'";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        void kasagiderlistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT kasaGelirGiderID,kasaAciklama,kasaTutar FROM KasaGelirGider WHERE secim='False'", con);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            con.Close();
        }
        #endregion
        #region gelirler
        private void gelirsayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(kasaGelirGiderID) FROM KasaGelirGider WHERE secim='True'";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        void kasagelirlistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT kasaGelirGiderID,kasaAciklama,kasaTutar FROM KasaGelirGider WHERE secim='True'", con);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            con.Close();
        }
#endregion
        private void kasasayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(kasaGelirGiderID) FROM KasaGelirGider";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        void kasalistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT kasaGelirGiderID,kasaAciklama,kasaTutar FROM KasaGelirGider", con);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            con.Close();
        }
        private void gidersil(int giderisil)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            string sql = "DELETE FROM KasaGelirGider where kasaGelirGiderID=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", giderisil);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void giderguncelle(int kasagelirgiderid)
        {
            string aciklama;
            decimal tutar;
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            aciklama = dataGridView1.CurrentRow.Cells["kasaAciklama"].Value.ToString();
            tutar = (decimal)dataGridView1.CurrentRow.Cells["kasaTutar"].Value;
            string sql = "UPDATE KasaGelirGider SET kasaAciklama='" + aciklama + "',kasaTutar='"+ tutar + "' where kasaGelirGiderID=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", kasagelirgiderid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
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

        private void frmKasaGelirGiderListele_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            lblgelir.Visible = false;
            lblgider.Visible = false;
            kasalistele();
            kasasayisi();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblgelir.Visible = false;
            lblgider.Visible = false;
            kasalistele();
            kasasayisi();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblgelir.Visible = true; 
            lblgider.Visible = false;
            kasagelirlistele();
            gelirsayisi();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lblgider.Visible = true;
            lblgelir.Visible = false;
            kasagiderlistele();
            gidersayisi();
        }

        private void seçiliSatırıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gidersil(giderisil);
            kasalistele();
        }

        private void seçiliSatırıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giderguncelle(kasagelirgiderid);
            kasalistele();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {

                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz

                    giderisil = Convert.ToInt32(dataGridView1.Rows[satir].Cells["kasaGelirGiderID"].Value);
                    kasagelirgiderid = Convert.ToInt32(dataGridView1.Rows[satir].Cells["kasaGelirGiderID"].Value);
                }
            }
        }
    }
}
