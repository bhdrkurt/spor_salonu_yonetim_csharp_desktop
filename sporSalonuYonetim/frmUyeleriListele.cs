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
    public partial class frmUyeleriListele : Form
    {
        public static GirisBilgi User { get; set; }
        sqlbaglanti gnl = new sqlbaglanti();
        SqlDataAdapter da;
        DataSet ds;
        int kayitid;
        string isim;
        int id;
        public frmUyeleriListele()
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

        private void aktifuyesayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(durum) FROM KayitTable WHERE durum=1";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        private void pasifuyesayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(durum) FROM KayitTable WHERE durum=0";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        private void toplamuyesayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(kayitID) FROM KayitTable";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
        }
        private void borcluyesayisi()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = " SELECT COUNT(DISTINCT uyeid) FROM TaksitTable";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label1.Text = durum.ToString();
           
        }

        private void uyeduzenle(int id)
        {
            string adsoyad;
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            adsoyad = dataGridView2.CurrentRow.Cells["adiSoyadi"].Value.ToString();
            string sql = "UPDATE KayitTable SET adiSoyadi='"+ adsoyad + "' WHERE kayitID=@kayitid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@kayitid", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void uyesil(int kayitid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            string sql = "DELETE FROM KayitTable where kayitID=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", kayitid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void uyepasiflistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT DISTINCT UYE.kayitID,UYE.adiSoyadi " +
                "FROM KayitTable UYE " +
                "WHERE UYE.kayitID NOT IN(4) " +
                "AND UYE.durum = 0 " +
                "GROUP BY UYE.kayitID, UYE.adiSoyadi", con);
            DataTable tablo1 = new DataTable();
            da.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
            con.Close();
        }
        void uyetoplamlistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT kayitID,adiSoyadi, kayitTarihi FROM KayitTable", con);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            con.Close();
        }
        void uyeaktiflistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT DISTINCT UYE.adiSoyadi, MAX(Abone.bitTarih) bitis_tarihi " +
                "FROM AboneKayit Abone " +
                "INNER JOIN KayitTable UYE ON Abone.uyeID = UYE.kayitID " +
                "WHERE Abone.bitTarih >= CAST(GETDATE() AS DATE) " +
                "AND UYE.kayitID NOT IN(4) " +
                "AND UYE.durum = 1 " +
                "GROUP BY UYE.kayitID, UYE.adiSoyadi", con);
            DataTable tablo3 = new DataTable();
            da.Fill(tablo3);
            dataGridView3.DataSource = tablo3;
            con.Close();
        }
        private void borcuolanlar()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT DISTINCT UYE.adiSoyadi, MAX(taksit.vadesayisi) vade_sayisi " +
                "FROM TaksitTable taksit " +
                "INNER JOIN KayitTable UYE ON taksit.uyeid = UYE.kayitID " +
                "WHERE UYE.kayitID NOT IN(4) " +
                "GROUP BY UYE.kayitID, UYE.adiSoyadi", con);
            DataTable tablo4 = new DataTable();
            da.Fill(tablo4);
            dataGridView4.DataSource = tablo4;
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

        private void frmUyeleriListele_Load(object sender, EventArgs e)
        {
            
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            lblborclu.Visible = false;
            lblpasif.Visible = false;
            lblaktif.Visible = false;
            lbltoplam.Visible = true;
            uyetoplamlistele();
            toplamuyesayisi();
        }

        private void btnAktifUyeler_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView4.Refresh();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            lblborclu.Visible = false;
            lblpasif.Visible = false;
            lblaktif.Visible = true;
            lbltoplam.Visible = false;
            uyeaktiflistele();
            aktifuyesayisi();
        }

        private void btnPasifUyeler_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView4.Refresh();
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            lblborclu.Visible = false;
            lblpasif.Visible = true;
            lblaktif.Visible = false;
            lbltoplam.Visible = false;
            uyepasiflistele();
            pasifuyesayisi();
        }

        private void btnButunUyeler_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView4.Refresh();
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            lblborclu.Visible = false;
            lblpasif.Visible = false;
            lblaktif.Visible = false;
            lbltoplam.Visible = true;
            uyetoplamlistele();
            toplamuyesayisi();
        }

        private void btnBorcluUyeler_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView4.Refresh();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            lblborclu.Visible = true;
            lblpasif.Visible = false;
            lblaktif.Visible = false;
            lbltoplam.Visible = false;
            borcuolanlar();
            borcluyesayisi();
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {

                int satir = dataGridView2.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1) 
                {
                    dataGridView2.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                 
                    id = Convert.ToInt32(dataGridView2.Rows[satir].Cells["kayitID"].Value);
                }
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyesil(kayitid);
            uyetoplamlistele();
            toplamuyesayisi();
        }

        private void seçiliSatırıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeduzenle(id);
            uyetoplamlistele();
            toplamuyesayisi();
        }
    }
}
