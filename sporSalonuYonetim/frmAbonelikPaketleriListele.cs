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
    public partial class frmAbonelikPaketleriListele : Form
    {
        int paketid, ozelpaketid;
        sqlbaglanti gnl = new sqlbaglanti();
        SqlDataAdapter da;
        public static GirisBilgi User { get; set; }
        public frmAbonelikPaketleriListele()
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
        private void ozellistelesayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(ozelPaketID) FROM OzelPaketler";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        private void normallistelesayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(paketID) FROM Paketler";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
            private void ozellistele()
        {
            if (rdbOzelPaket.Checked == true)
            {
                SqlConnection con = new SqlConnection(gnl.conString);
                con.Open();
                da = new SqlDataAdapter("SELECT ozelPaketID,ozelPaketAdi,ozelPaketSure,seans,ozelPaketEgitmen,ozelPaketFiyat FROM OzelPaketler", con);
                DataTable tablo1 = new DataTable();
                da.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                con.Close();
            }
        }
        private void normallistele()
        {
            if (rdbNormalPaket.Checked == true) { 
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT paketID,paketAdi,sure,fiyat FROM Paketler", con);
            DataTable tablo1 = new DataTable();
            da.Fill(tablo1);
            dataGridView4.DataSource = tablo1;
            con.Close();
            }
        }
        private void normalpaketsil(int paketid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            string sql = "DELETE FROM Paketler where paketID=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", paketid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void ozelpaketsil(int ozelpaketid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            string sql = "DELETE FROM OzelPaketler where ozelPaketID=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", ozelpaketid);
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

        private void frmAbonelikPaketleriListele_Load(object sender, EventArgs e)
        {
            lblpaket.Visible = false;
            lblnormal.Visible = false;
            dataGridView4.Visible = false;
            dataGridView1.Visible = false;
        }

        private void rdbOzelPaket_CheckedChanged(object sender, EventArgs e)
        {
            lblpaket.Visible = true;
            lblnormal.Visible = false;
            dataGridView1.Visible = true;
            dataGridView4.Visible = false;
            ozellistele();
            ozellistelesayisi();
        }

        private void rdbNormalPaket_CheckedChanged(object sender, EventArgs e)
        {
            lblpaket.Visible = false;
            lblnormal.Visible = true;
            dataGridView1.Visible = false;
            dataGridView4.Visible = true;
            normallistele();
            normallistelesayisi();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {

                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView1.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    ozelpaketid = Convert.ToInt32(dataGridView1.Rows[satir].Cells["ozelPaketID"].Value);
                }
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            ozelpaketsil(ozelpaketid);
            ozellistele();
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            normalpaketsil(paketid);
            normallistele();
        }

        private void dataGridView4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {

                int satir = dataGridView4.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView4.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    paketid = Convert.ToInt32(dataGridView4.Rows[satir].Cells["paketID"].Value);
                }
            }
            
        }
    }
}
