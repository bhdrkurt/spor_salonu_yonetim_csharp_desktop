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
    public partial class frmAnasayfa : Form
    {
        public static GirisBilgi User { get; set; }
        sqlbaglanti gnl = new sqlbaglanti();
        SqlDataAdapter da;
        DataSet ds;
        public frmAnasayfa()
        {
            InitializeComponent();
            

            #region yetkiler
            if (User.Roles.Contains("admin"))
            {
                menuStrip1.Visible = true;
            }
            else if (User.Roles.Contains("resepsiyon"))
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
           
            else if (User.Roles.Contains("vitaminbar"))
            {
                hızlıErişimToolStripMenuItem.Visible=false;
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
            frmAboneKayitEkle frm = new frmAboneKayitEkle();
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
        private void personelEkleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmPersonelEkle frm = new frmPersonelEkle();
            frm.Show();
        }

        private void branşTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBranslar frm = new frmBranslar();
            frm.Show();
        }
        #endregion

        #region Uye aktif pasif Set yapıldığı yer
        private void uyedurumlari()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "UPDATE KayitTable SET durum = 0 FROM KayitTable " +
                "INNER JOIN AboneKayit Abone ON KayitTable.kayitID = Abone.uyeID " +
                "WHERE Abone.bitTarih < CAST(GETDATE() AS DATE)";
            string sql2 = "UPDATE KayitTable SET durum = 1 FROM KayitTable " +
                "INNER JOIN AboneKayit Abone ON KayitTable.kayitID = Abone.uyeID " +
                "WHERE Abone.bitTarih >= CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        private void ozeluyedurumlari()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "UPDATE KayitTable SET durum = 0 FROM KayitTable " +
                "INNER JOIN ozelAboneKayit Abone ON KayitTable.kayitID = Abone.ozelAboneID " +
                "WHERE Abone.bitTarih < CAST(GETDATE() AS DATE)";
            string sql2 = "UPDATE KayitTable SET durum = 1 FROM KayitTable " +
                "INNER JOIN ozelAboneKayit Abone ON KayitTable.kayitID = Abone.ozelAboneID " +
                "WHERE Abone.bitTarih >= CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region aktif pasif uye kısayolları
        private void aktifuye() {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(durum) FROM KayitTable WHERE durum=1";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label4.Text = durum.ToString();
        }
        private void pasifuye()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(durum) FROM KayitTable WHERE durum=0";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label5.Text = durum.ToString();
        }
        private void toplamuye()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "SELECT COUNT(durum) FROM KayitTable";
            int durum;
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            durum = (int)komut.ExecuteScalar();
            con.Close();
            label7.Text = durum.ToString();
        }
        #endregion
        #region üyelik bitişlerinin kontrol et
        private void uyelikbitiskontrol()
        {
            
                SqlConnection con = new SqlConnection(gnl.conString);
                string sql = "UPDATE AboneKayit SET uyelikdurum = 1 FROM AboneKayit " +
                    "WHERE bitTarih >= CAST(GETDATE() AS DATE)";
                string sql2 = "UPDATE AboneKayit SET uyelikdurum = 0 FROM AboneKayit " +
                     "WHERE bitTarih < CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
            
        }

        #endregion

        private void songirilenkayitlar()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT TOP 5 adiSoyadi,tcKimlikNo,cepTelefon,kayitTarihi " +
                "FROM KayitTable ORDER BY kayitID DESC", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "KayitTable");
            dataGridView1.DataSource = ds.Tables["KayitTable"];
            con.Close();
           
        }
        private void besgunkalanuyeler()
         {
             SqlConnection con = new SqlConnection(gnl.conString);
             da = new SqlDataAdapter("SELECT DISTINCT UYE.adiSoyadi, MAX(Abone.bitTarih) bitis_tarihi " +
                 "FROM AboneKayit Abone " +
                 "INNER JOIN KayitTable UYE ON Abone.uyeID = UYE.kayitID " +
                 "WHERE DATEADD(DAY, -5, Abone.bitTarih) <= GETDATE() " +
                 "AND UYE.kayitID NOT IN(4)" +
                 "AND Uye.durum = 1" +
                 "AND Abone.uyelikdurum = 1" +
                 "GROUP BY UYE.kayitID, UYE.adiSoyadi", con);
             ds = new DataSet();
             con.Open();
             da.Fill(ds, "AboneKayit");
             dataGridView2.DataSource = ds.Tables["AboneKayit"];
             con.Close();
         }
        private void borcugecikenvebugunolanlar()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT DISTINCT UYE.adiSoyadi, MAX(taksit.vadetarih) vade_tarihi " +
                "FROM TaksitTable taksit " +
                "INNER JOIN KayitTable UYE ON taksit.uyeid = UYE.kayitID " +
                "WHERE taksit.vadetarih <= CAST(GETDATE() AS DATE) " +
                "AND UYE.kayitID NOT IN(4) " +
                "AND taksit.vadedurum = 0 " +
                "GROUP BY UYE.kayitID, UYE.adiSoyadi", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "TaksitTable");
            dataGridView3.DataSource = ds.Tables["TaksitTable"];
            con.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            label2.Text = DateTime.Now.ToLongTimeString();
        }
        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            label11.Text=DateTime.Now.ToLongDateString();
            label9.Text = DateTime.Now.Month.ToString();
            label10.Text= DateTime.Now.Year.ToString();
            aktifuye();
            pasifuye();
            toplamuye();
            ozeluyedurumlari();
            besgunkalanuyeler();
            borcugecikenvebugunolanlar();
            uyedurumlari();
            uyelikbitiskontrol();
            songirilenkayitlar();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
