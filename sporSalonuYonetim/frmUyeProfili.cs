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

    public partial class frmUyeProfili : Form
    {
        public static GirisBilgi User { get; set; }
        public frmUyeProfili()
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
        public string adi, tckimlikno, telefon, acilyakin, acilyakintel, id;
        public DateTime tarih;
        
        sqlbaglanti gnl = new sqlbaglanti();
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter da;
        DataSet ds;
        DataTable tablo = new DataTable();
        DataTable tablo1 = new DataTable();


        private void vadehesaplama()
        {
            int vadetutar, secilenvade, sonuc;
            vadetutar = Convert.ToInt32(txtEcuzdanTutar.Text);
            secilenvade = Convert.ToInt32(comboBox3.Text);
            sonuc = vadetutar / secilenvade;
            label95.Text = Convert.ToString(sonuc);
        }
        #region datagridleri kayıt yapınca otomatik yenileme
        private void griddoldur()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT aboneID,basTarih, bitTarih, paketAdi, fiyat, odemeSekli, uyeAdSoyad,kayitTarih FROM dbo.AboneKayit  WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "AboneKayit");
            dataGridView1.DataSource = ds.Tables["AboneKayit"];
            con.Close();
        }
        private void griddoldur2()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT ozelAboneID,basTarih,bitTarih,ozelPaketAdi,fiyat,odemeSekli,ozelUyeAdSoyad,seans,egitmenAdi,ozelKayitTarih FROM dbo.ozelAboneKayit  WHERE ozelUyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ozelAboneKayit");
            dataGridView2.DataSource = ds.Tables["ozelAboneKayit"];
            con.Close();
        }
        private void griddoldur3()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT yagKayitTarih,yagKg,yagVctYag,yagBMI,yagMuscle,yagSivi,yagMetobalizmaYasi,yagideKg,yagBoy,yagicYaglanma,yagRMK,yagAdiSoyadi FROM yagOlcum  WHERE yagAdiSoyadi LIKE '%" + lblAd.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "yagOlcum");
            yagDataGrid.DataSource = ds.Tables["yagOlcum"];
            con.Close();
        }
        private void griddoldur4()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT vucutAgirligi,vucutBoy,vucutGogus,vucutBel,vucutKalca,vucutSolUstBacak,vucutSolBaldir,vucutSolKol,vucutOmuz,vucutGogusAlti," +
                    "vucutKarin,vucutBasen,vucutSagUstBacak,vucutSagBaldir,vucutSagKol,vucutTarih,vucutAdSoyad FROM VucutOlcumleri  WHERE vucutAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "VucutOlcumleri");
            dataGridView4.DataSource = ds.Tables["VucutOlcumleri"];
            con.Close();
        }
        private void griddoldur5()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT basTarih, bitTarih, paketAdi, fiyat, odemeSekli, uyeAdSoyad,kayitTarih FROM dbo.AboneKayit  WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "AboneKayit");
            dtAbonelikRaporu.DataSource = ds.Tables["AboneKayit"];
            con.Close();
        }
        
        private void griddoldur7()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT kayittarihi,vadeid,uyeAdSoyad,vadetarih,vadetutar,vadesayisi,vadedurum " +
                "FROM TaksitTable  WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "TaksitTable");
            dataGridView3.DataSource = ds.Tables["TaksitTable"];
            con.Close();
        }
        private void griddoldur8()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT aboneID,basTarih, bitTarih, paketAdi, fiyat, odemeSekli, uyeAdSoyad,kayitTarih FROM dbo.AboneKayit  " +
                "WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'" +
                " AND odemeSekli='Vadeli'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "AboneKayit");
            dataGridView5.DataSource = ds.Tables["AboneKayit"];
            con.Close();
        }

        #endregion
        #region datagridde kayıt silme normal abonelik ve özel abonelik
        private void kayitsil(int aboneID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "DELETE FROM AboneKayit WHERE aboneID=@aboneID";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@aboneID", aboneID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void taksitguncelletrue(int vadeid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "UPDATE TaksitTable SET vadedurum=1 FROM TaksitTable WHERE vadeid=@vadeid AND vadedurum=0";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@vadeid", vadeid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void taksitguncellefalse(int vadeid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql2 = "UPDATE TaksitTable SET vadedurum=0 FROM TaksitTable WHERE vadeid=@vadeid AND vadedurum=1";
            cmd2 = new SqlCommand(sql2, con);
            cmd2.Parameters.AddWithValue("@vadeid", vadeid);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        private void kayitsil2(int ozelAboneID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "DELETE FROM ozelAboneKayit WHERE ozelAboneID=@ozelAboneID";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ozelAboneID", ozelAboneID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        private void ecuzdanlabel()
        {
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
        #region solmenü
        private void btnKartIslemleri_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
            dataGridView5.Visible = false;
            panel19.Visible = false;
            dataGridView3.Visible = false;
            yagDataGrid.Visible = false;
            panel2.Visible = false;
            panel6.Visible = true;
            panel8.Visible = false;
            panel11.Visible = false;
            panel10.Visible = false;
            panel14.Visible = false;
            panel16.Visible = false;
            panel20.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        private void btnAbonelikGirisi_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
            panel19.Visible = false;
            dataGridView5.Visible = false;
            dataGridView3.Visible = false;
            yagDataGrid.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = true;
            panel11.Visible = true;
            panel10.Visible = false;
            panel14.Visible = false;
            panel16.Visible = false;
            panel20.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        private void btnPTTanimlama_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
            panel19.Visible = false;
            dataGridView5.Visible = false;
            dataGridView3.Visible = false;
            yagDataGrid.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel10.Visible = true;
            panel14.Visible = true;
            panel16.Visible = false;
            panel20.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        private void btnecuzdan_Click(object sender, EventArgs e)
        {
            panel19.Visible = true;
            panel17.Visible = true;
            dataGridView3.Visible = true;
            dataGridView5.Visible = true;
            yagDataGrid.Visible = false;
            panel16.Visible = true;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel14.Visible = false;
            panel10.Visible = false;
            panel20.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        private void btnVucutOlcumleri_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
            panel19.Visible = false;
            dataGridView5.Visible = false;
            dataGridView3.Visible = false;
            yagDataGrid.Visible = false;
            panel16.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel14.Visible = false;
            panel10.Visible = false;
            panel20.Visible = true;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = true;
            panel23.Visible = true;
        }
        private void btnYagOlcumleri_Click_1(object sender, EventArgs e)
        {
            panel17.Visible = false;
            panel19.Visible = false;
            dataGridView5.Visible = false;
            dataGridView3.Visible = false;
            yagDataGrid.Visible = true;
            panel16.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel14.Visible = false;
            panel10.Visible = false;
            panel20.Visible = false;
            panel25.Visible = true;
            panel26.Visible = true;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        private void btnAbonelikRaporu_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;
            panel19.Visible = false;
            panel17.Visible = false;
            yagDataGrid.Visible = false;
            dataGridView5.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel14.Visible = false;
            panel10.Visible = false;
            panel16.Visible = false;
            panel20.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = true;
            panel29.Visible = true;
            dtAbonelikRaporu.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        private void btnUyeDuzenle_Click(object sender, EventArgs e)
        {
            yagDataGrid.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;
            panel19.Visible = false;
            panel17.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel14.Visible = false;
            panel10.Visible = false;
            panel16.Visible = false;
            panel20.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            panel23.Visible = false;
        }
        #endregion
        #region combobox doldurma

        //private void ecuzdanlabel()
        //{
        //    //label veri çekme
        //    SqlConnection con = new SqlConnection(gnl.conString);
        //    con.Open();
        //    cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = ("SELECT AboneKayit.ecuzdan FROM AboneKayit WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'");
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    con.Close();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        label121.Text = (dr["ecuzdan"].ToString());
        //    }
        //    con.Close();
        //}
        private void borcgetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PersonelKayit.personelAdi FROM PersonelKayit ORDER BY PersonelKayit.personelAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbEgitmenSec.Items.Add(dr["personelAdi"].ToString());
            }
            con.Close();

        }

        private void egitmengetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PersonelKayit.personelAdi FROM PersonelKayit ORDER BY PersonelKayit.personelAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbEgitmenSec.Items.Add(dr["personelAdi"].ToString());
            }
            con.Close();

        }
        private void isimgetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT AboneKayit.uyeAdSoyad FROM AboneKayit";
            cmd.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd);
            da3.Fill(dt3);
            con.Close();

        }
        private void paketgetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Paketler.paketAdi FROM Paketler ORDER BY Paketler.paketAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbPaketAdi.Items.Add(dr["paketAdi"].ToString());
            }
            con.Close();
        }
        private void ozelpaketgetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Paketler.paketAdi FROM Paketler ORDER BY Paketler.paketAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["paketAdi"].ToString());
            }
            con.Close();
        }
        #endregion
        #region normal peket kayıt
        private void btnAboneKayitOlstur_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (cmbPaketAdi.Text == "")
            {
                label102.Visible = true;
                label102.ForeColor = Color.Red;
                label102.Text = "Lütfen Paket Seçiniz";
            }
            else if (cmbOdemeSekli.Text == "")
            {
                label102.Visible = true;
                label102.ForeColor = Color.Red;
                label102.Text = "Lütfen Ödeme Şeklini Seçiniz";
            }
            else if (cmbPaketAdi.Text != "" && cmbOdemeSekli.Text != "")
            {
                con.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO AboneKayit(basTarih,bitTarih,paketAdi,fiyat,odemeSekli,uyeAdSoyad,kayitTarih,uyeID) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p9)", con);

                if (cmbOdemeSekli.Text == "Nakit" || cmbOdemeSekli.Text == "Banka")
                {
                    komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtBasTarih.Text));
                    komut.Parameters.AddWithValue("@p2", Convert.ToDateTime(dtBitTarih.Text));
                    komut.Parameters.AddWithValue("@p3", cmbPaketAdi.Text);
                    komut.Parameters.AddWithValue("@p4", Convert.ToDouble(txtAbonelikFiyat.Text));
                    komut.Parameters.AddWithValue("@p5", cmbOdemeSekli.Text);
                    komut.Parameters.AddWithValue("@p6", lblAd.Text);
                    komut.Parameters.AddWithValue("@p7", Convert.ToDateTime(dateTimePicker2.Text));
                    komut.Parameters.AddWithValue("@p9", label91.Text);
                    komut.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtBasTarih.Text));
                    komut.Parameters.AddWithValue("@p2", Convert.ToDateTime(dtBitTarih.Text));
                    komut.Parameters.AddWithValue("@p3", cmbPaketAdi.Text);
                    komut.Parameters.AddWithValue("@p4", Convert.ToDouble(txtAbonelikFiyat.Text));
                    komut.Parameters.AddWithValue("@p5", cmbOdemeSekli.Text);
                    komut.Parameters.AddWithValue("@p6", lblAd.Text);
                    komut.Parameters.AddWithValue("@p7", Convert.ToDateTime(dateTimePicker2.Text));
                    komut.Parameters.AddWithValue("@p9", label91.Text);
                    komut.ExecuteNonQuery();
                    con.Close();
                }
                label102.Visible = true;
                label102.ForeColor = Color.Green;
                label102.Text = "Kayıt Tamamlanmıştır.";
                textBox2.Text = "";
            }
            else
            {
                label102.Visible = true;
                label102.ForeColor = Color.Red;
                label102.Text = "Kayıt Yapılamadı";
            }
            // label102.Text = "";
            griddoldur();
            griddoldur5();
            ecuzdanlabel();
        }
        #endregion
        private void cmbPaketAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand("SELECT * FROM Paketler where paketAdi ='" + cmbPaketAdi.Text + "'", con);

            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            #region günler
            while (dr.Read())
            {
                string fiyat = (string)dr["fiyat"].ToString();
                string gun = (string)dr["sure"].ToString();
                txtAbonelikFiyat.Text = fiyat;
                label120.Text = gun;
                textBox2.Text = gun;
                if (textBox2.Text == "1")
                {
                    textBox2.Text = "31";
                }
                else if (textBox2.Text == "2")
                {
                    textBox2.Text = "60";
                }
                else if (textBox2.Text == "3")
                {
                    textBox2.Text = "91";
                }
                else if (textBox2.Text == "4")
                {
                    textBox2.Text = "121";
                }
                else if (textBox2.Text == "5")
                {
                    textBox2.Text = "152";
                }
                else if (textBox2.Text == "6")
                {
                    textBox2.Text = "180";
                }
                else if (textBox2.Text == "7")
                {
                    textBox2.Text = "211";
                }
                else if (textBox2.Text == "8")
                {
                    textBox2.Text = "241";
                }
                else if (textBox2.Text == "9")
                {
                    textBox2.Text = "272";
                }
                else if (textBox2.Text == "10")
                {
                    textBox2.Text = "300";
                }
                else if (textBox2.Text == "11")
                {
                    textBox2.Text = "334";
                }
                else if (textBox2.Text == "12")
                {
                    textBox2.Text = "365";
                }
                #endregion
            }

            con.Close();
        }
        private void lblAd_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            tablo.Clear();
            da = new SqlDataAdapter("SELECT * FROM AboneKayit WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
            griddoldur();
            tablo.Clear();
            da = new SqlDataAdapter("SELECT * FROM ozelAboneKayit WHERE ozelUyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            con.Close();
            griddoldur2();
            tablo.Clear();
            da = new SqlDataAdapter("SELECT * FROM yagOlcum WHERE yagAdiSoyadi LIKE '%" + lblAd.Text + "%'", con);
            da.Fill(tablo);
            yagDataGrid.DataSource = tablo;
            con.Close();
            griddoldur3();
            tablo.Clear();
            da = new SqlDataAdapter("SELECT * FROM VucutOlcumleri WHERE vucutAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            con.Close();
            griddoldur4();
            tablo.Clear();
            da = new SqlDataAdapter("SELECT * FROM AboneKayit WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            da.Fill(tablo);
            dtAbonelikRaporu.DataSource = tablo;
            con.Close();
            griddoldur5();
            tablo.Clear();
            da = new SqlDataAdapter("SELECT kayittarihi,vadeid,uyeAdSoyad,vadetarih,vadetutar,vadesayisi,vadedurum  FROM TaksitTable WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%'", con);
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            con.Close();
            griddoldur7();
            tablo1.Clear();
            da = new SqlDataAdapter("SELECT aboneID,basTarih, bitTarih, paketAdi, fiyat, odemeSekli, uyeAdSoyad,kayitTarih FROM AboneKayit" +
                " WHERE uyeAdSoyad LIKE '%" + lblAd.Text + "%' AND odemeSekli='Vadeli'", con);
            da.Fill(tablo);
            dataGridView5.DataSource = tablo1;
            con.Close();
            griddoldur8();

        }
        #region mouse tıklandığında datagridden silme işlemi

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                if (e.Button == MouseButtons.Left && dataGridView1.Columns[e.ColumnIndex].Name == "islem")
                {
                    int aboneID = Convert.ToInt32(drow.Cells[0].Value);
                    kayitsil(aboneID);
                }
                griddoldur();
                griddoldur5();
            }
        }
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView2.SelectedRows)  //Seçili Satırları Silme
            {
                if (e.Button == MouseButtons.Left && dataGridView2.Columns[e.ColumnIndex].Name == "islemler1")
                {
                    int ozelAboneID = Convert.ToInt32(drow.Cells[0].Value);
                    kayitsil2(ozelAboneID);
                }
                griddoldur2();
            }
        }
        #endregion
        #region özel paket kayıt
        private void btnKaydet1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (comboBox2.Text == "")
            {
                label117.Visible = true;
                label117.ForeColor = Color.Red;
                label117.Text = "Lütfen Paket Seçiniz";
            }
            else if (comboBox1.Text == "")
            {
                label117.Visible = true;
                label117.ForeColor = Color.Red;
                label117.Text = "Lütfen Ödeme Şeklini Seçiniz";
            }
            else if (cmbEgitmenSec.Text == "")
            {
                label117.Visible = true;
                label117.ForeColor = Color.Red;
                label117.Text = "Lütfen Eğitmen Seçiniz";
            }
            else if (comboBox2.Text != "" && comboBox1.Text != "" && cmbEgitmenSec.Text != "")
            {
                con.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO AboneKayit(basTarih,bitTarih,paketAdi,fiyat,odemeSekli,uyeAdSoyad,kayitTarih,uyeID,egitmenadi) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p8,@p9,@p10)", con);
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dateTimePicker4.Text));
                komut.Parameters.AddWithValue("@p2", Convert.ToDateTime(dateTimePicker3.Text));
                komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToDecimal(textBox6.Text));
                komut.Parameters.AddWithValue("@p5", comboBox1.Text);
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p8", Convert.ToDateTime(dateTimePicker1.Text));
                komut.Parameters.AddWithValue("@p9", label91.Text);
                komut.Parameters.AddWithValue("@p10", cmbEgitmenSec.Text);
                komut.ExecuteNonQuery();
                con.Close();
                label117.Visible = true;
                label117.ForeColor = Color.Green;
                label117.Text = "Kayıt Tamamlanmıştır.";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker4.Value = DateTime.Now;
                comboBox2.SelectedIndex = 1;
                cmbEgitmenSec.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = 1;
            }
            else
            {
                label117.Visible = true;
                label117.ForeColor = Color.Red;
                label117.Text = "Kayıt Yapılamadı";
            }

            griddoldur2();
        }
        #endregion
        #region combobox2 özel paket adını seçince gün fiyat vs. gelmesi
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand("SELECT * FROM Paketler where paketAdi ='" + comboBox2.Text + "'", con);

            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            #region günler
            while (dr.Read())
            {
                string ozelfiyat = (string)dr["fiyat"].ToString();
                string ozelgun = (string)dr["sure"].ToString();
                textBox6.Text = ozelfiyat;
                textBox7.Text = ozelgun;
                label116.Text = ozelgun;
                if (textBox7.Text == "1")
                {
                    textBox7.Text = "31";
                }
                else if (textBox7.Text == "2")
                {
                    textBox7.Text = "60";
                }
                else if (textBox7.Text == "3")
                {
                    textBox7.Text = "91";
                }
                else if (textBox7.Text == "4")
                {
                    textBox7.Text = "121";
                }
                else if (textBox7.Text == "5")
                {
                    textBox7.Text = "152";
                }
                else if (textBox7.Text == "6")
                {
                    textBox7.Text = "180";
                }
                else if (textBox7.Text == "7")
                {
                    textBox7.Text = "211";
                }
                else if (textBox7.Text == "8")
                {
                    textBox7.Text = "241";
                }
                else if (textBox7.Text == "9")
                {
                    textBox7.Text = "272";
                }
                else if (textBox7.Text == "10")
                {
                    textBox7.Text = "300";
                }
                else if (textBox7.Text == "11")
                {
                    textBox7.Text = "334";
                }
                else if (textBox7.Text == "12")
                {
                    textBox7.Text = "365";
                }
                #endregion
            }

            con.Close();
        }
        #endregion
        private void label116_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label116.Text) == 0)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(0);
            }
            else if (Convert.ToInt32(label116.Text) == 1)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(30);
            }
            else if (Convert.ToInt32(label116.Text) == 2)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(60);
            }
            else if (Convert.ToInt32(label116.Text) == 3)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(90);
            }
            else if (Convert.ToInt32(label116.Text) == 4)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(120);
            }
            else if (Convert.ToInt32(label116.Text) == 5)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(150);
            }
            else if (Convert.ToInt32(label116.Text) == 6)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(180);
            }
            else if (Convert.ToInt32(label116.Text) == 7)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(210);
            }
            else if (Convert.ToInt32(label116.Text) == 8)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(240);
            }
            else if (Convert.ToInt32(label116.Text) == 9)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(270);
            }
            else if (Convert.ToInt32(label116.Text) == 10)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(300);
            }
            else if (Convert.ToInt32(label116.Text) == 11)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(330);
            }
            else if (Convert.ToInt32(label116.Text) == 12)
            {
                dateTimePicker3.Value = dateTimePicker4.Value.AddDays(360);
            }
        }
        private void label114_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            tablo.Clear();
            da = new SqlDataAdapter("SELECT * FROM ozelAboneKayit WHERE ozelUyeAdSoyad LIKE '%" + label114.Text + "%'", con);
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            con.Close();
        }
        #region abonelik tarihini başlama tarihine göre ayarlama
        private void label120_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label120.Text) == 0)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(0);
            }
            else if (Convert.ToInt32(label120.Text) == 1)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(30);
            }
            else if (Convert.ToInt32(label120.Text) == 2)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(60);
            }
            else if (Convert.ToInt32(label120.Text) == 3)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(90);
            }
            else if (Convert.ToInt32(label120.Text) == 4)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(120);
            }
            else if (Convert.ToInt32(label120.Text) == 5)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(150);
            }
            else if (Convert.ToInt32(label120.Text) == 6)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(180);
            }
            else if (Convert.ToInt32(label120.Text) == 7)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(210);
            }
            else if (Convert.ToInt32(label120.Text) == 8)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(240);
            }
            else if (Convert.ToInt32(label120.Text) == 9)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(270);
            }
            else if (Convert.ToInt32(label120.Text) == 10)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(300);
            }
            else if (Convert.ToInt32(label120.Text) == 11)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(330);
            }
            else if (Convert.ToInt32(label120.Text) == 12)
            {
                dtBitTarih.Value = dtBasTarih.Value.AddDays(360);
            }
        }
        #endregion

        #region ecuzdan kayıt click
        private void btnEcuzdanKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TaksitTable(kayittarihi,vadesayisi,vadetutar,vadetarih,uyeAdSoyad,aboneid,uyeid)" +
                " VALUES(@p1,@p2,@p3,@p4,@p6,@p7,@p8)", con);
            SqlCommand komut2 = new SqlCommand("INSERT INTO TaksitTable(kayittarihi,vadesayisi,vadetutar,vadetarih,uyeAdSoyad,aboneid,uyeid)" +
            " VALUES(@p1,@p2,@p3,@p4,@p6,@p7,@p8)", con);
            SqlCommand komut3 = new SqlCommand("INSERT INTO TaksitTable(kayittarihi,vadesayisi,vadetutar,vadetarih,uyeAdSoyad,aboneid,uyeid)" +
            " VALUES(@p1,@p2,@p3,@p4,@p6,@p7,@p8)", con);
            SqlCommand komut4 = new SqlCommand("INSERT INTO TaksitTable(kayittarihi,vadesayisi,vadetutar,vadetarih,uyeAdSoyad,aboneid,uyeid)" +
          " VALUES(@p1,@p2,@p3,@p4,@p6,@p7,@p8)", con);
            SqlCommand komut5 = new SqlCommand("INSERT INTO TaksitTable(kayittarihi,vadesayisi,vadetutar,vadetarih,uyeAdSoyad,aboneid,uyeid)" +
         " VALUES(@p1,@p2,@p3,@p4,@p6,@p7,@p8)", con);
            SqlCommand komut6 = new SqlCommand("INSERT INTO TaksitTable(kayittarihi,vadesayisi,vadetutar,vadetarih,uyeAdSoyad,aboneid,uyeid)" +
         " VALUES(@p1,@p2,@p3,@p4,,@p6,@p7,@p8)", con);
            if (comboBox3.Text == "1")
            {

                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker5.Text));
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", label96.Text);
                komut.Parameters.AddWithValue("@p8", label91.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox3.Text == "2")
            {
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker5.Text));
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", label96.Text);
                komut.Parameters.AddWithValue("@p8", label91.Text);
                komut.ExecuteNonQuery();
                komut2.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut2.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut2.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker8.Text));
                komut2.Parameters.AddWithValue("@p6", lblAd.Text);
                komut2.Parameters.AddWithValue("@p7", label96.Text);
                komut2.Parameters.AddWithValue("@p8", label91.Text);
                komut2.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox3.Text == "3")
            {
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker5.Text));
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", label96.Text);
                komut.Parameters.AddWithValue("@p8", label91.Text);
                komut.ExecuteNonQuery();
                komut2.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut2.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut2.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker8.Text));
                komut2.Parameters.AddWithValue("@p6", lblAd.Text);
                komut2.Parameters.AddWithValue("@p7", label96.Text);
                komut2.Parameters.AddWithValue("@p8", label91.Text);
                komut2.ExecuteNonQuery();
                komut3.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut3.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut3.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut3.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker10.Text));
                komut3.Parameters.AddWithValue("@p6", lblAd.Text);
                komut3.Parameters.AddWithValue("@p7", label96.Text);
                komut3.Parameters.AddWithValue("@p8", label91.Text);
                komut3.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox3.Text == "4")
            {
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker5.Text));
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", label96.Text);
                komut.Parameters.AddWithValue("@p8", label91.Text);
                komut.ExecuteNonQuery();
                komut2.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut2.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut2.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker8.Text));
                komut2.Parameters.AddWithValue("@p6", lblAd.Text);
                komut2.Parameters.AddWithValue("@p7", label96.Text);
                komut2.Parameters.AddWithValue("@p8", label91.Text);
                komut2.ExecuteNonQuery();
                komut3.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut3.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut3.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut3.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker10.Text));
                komut3.Parameters.AddWithValue("@p6", lblAd.Text);
                komut3.Parameters.AddWithValue("@p7", label96.Text);
                komut3.Parameters.AddWithValue("@p8", label91.Text);
                komut3.ExecuteNonQuery();
                komut4.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut4.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut4.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut4.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker9.Text));
                komut4.Parameters.AddWithValue("@p6", lblAd.Text);
                komut4.Parameters.AddWithValue("@p7", label96.Text);
                komut4.Parameters.AddWithValue("@p8", label91.Text);
                komut4.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox3.Text == "5")
            {
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker5.Text));
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", label96.Text);
                komut.Parameters.AddWithValue("@p8", label91.Text);
                komut.ExecuteNonQuery();
                komut2.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut2.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut2.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker8.Text));
                komut2.Parameters.AddWithValue("@p6", lblAd.Text);
                komut2.Parameters.AddWithValue("@p7", label96.Text);
                komut2.Parameters.AddWithValue("@p8", label91.Text);
                komut2.ExecuteNonQuery();
                komut3.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut3.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut3.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut3.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker10.Text));
                komut3.Parameters.AddWithValue("@p6", lblAd.Text);
                komut3.Parameters.AddWithValue("@p7", label96.Text);
                komut3.Parameters.AddWithValue("@p8", label91.Text);
                komut3.ExecuteNonQuery();
                komut4.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut4.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut4.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut4.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker9.Text));
                komut4.Parameters.AddWithValue("@p6", lblAd.Text);
                komut4.Parameters.AddWithValue("@p7", label96.Text);
                komut4.Parameters.AddWithValue("@p8", label91.Text);
                komut4.ExecuteNonQuery();
                komut5.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut5.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut5.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut5.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker12.Text));
                komut5.Parameters.AddWithValue("@p6", lblAd.Text);
                komut5.Parameters.AddWithValue("@p7", label96.Text);
                komut5.Parameters.AddWithValue("@p8", label91.Text);
                komut5.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox3.Text == "5")
            {
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker5.Text));
                komut.Parameters.AddWithValue("@p6", lblAd.Text);
                komut.Parameters.AddWithValue("@p7", label96.Text);
                komut.Parameters.AddWithValue("@p8", label91.Text);
                komut.ExecuteNonQuery();
                komut2.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut2.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut2.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut2.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker8.Text));
                komut2.Parameters.AddWithValue("@p6", lblAd.Text);
                komut2.Parameters.AddWithValue("@p7", label96.Text);
                komut2.Parameters.AddWithValue("@p8", label91.Text);
                komut2.ExecuteNonQuery();
                komut3.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut3.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut3.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut3.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker10.Text));
                komut3.Parameters.AddWithValue("@p6", lblAd.Text);
                komut3.Parameters.AddWithValue("@p7", label96.Text);
                komut3.Parameters.AddWithValue("@p8", label91.Text);
                komut3.ExecuteNonQuery();
                komut4.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut4.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut4.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut4.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker9.Text));
                komut4.Parameters.AddWithValue("@p6", lblAd.Text);
                komut4.Parameters.AddWithValue("@p7", label96.Text);
                komut4.Parameters.AddWithValue("@p8", label91.Text);
                komut4.ExecuteNonQuery();
                komut5.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut5.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut5.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut5.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker12.Text));
                komut5.Parameters.AddWithValue("@p6", lblAd.Text);
                komut5.Parameters.AddWithValue("@p7", label96.Text);
                komut5.Parameters.AddWithValue("@p8", label91.Text);
                komut5.ExecuteNonQuery();
                komut6.Parameters.AddWithValue("@p1", Convert.ToDateTime(dtEcuzdanKayitTarihi.Text));
                komut6.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut6.Parameters.AddWithValue("@p3", Convert.ToDecimal(label95.Text));
                komut6.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker11.Text));
                komut6.Parameters.AddWithValue("@p6", lblAd.Text);
                komut6.Parameters.AddWithValue("@p7", label96.Text);
                komut6.Parameters.AddWithValue("@p8", label91.Text);
                komut6.ExecuteNonQuery();
                con.Close();
            }
            griddoldur7();

        }
        #endregion
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label89.Visible = true;
            dateTimePicker5.Visible = true;
        }
        private void rdbNakitDusur_CheckedChanged(object sender, EventArgs e)
        {
            label89.Visible = false;
            dateTimePicker5.Visible = false;
        }

        private void dataGridView5_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label96.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            txtEcuzdanTutar.Text = dataGridView5.CurrentRow.Cells[4].Value.ToString();
        }
        #region taksit combobox seçimi
        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "1")
            {
                label89.Visible = true;
                dateTimePicker5.Visible = true;
                label85.Visible = false;
                label90.Visible = false;
                label93.Visible = false;
                label94.Visible = false;
                label87.Visible = false;
                dateTimePicker10.Visible = false;
                dateTimePicker8.Visible = false;
                dateTimePicker9.Visible = false;
                dateTimePicker11.Visible = false;
                dateTimePicker12.Visible = false;
                vadehesaplama();
            }
            else if (comboBox3.Text == "2")
            {
                label85.Visible = true;
                label89.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker8.Visible = true;
                label90.Visible = false;
                label93.Visible = false;
                label94.Visible = false;
                label87.Visible = false;
                dateTimePicker10.Visible = false;
                dateTimePicker9.Visible = false;
                dateTimePicker11.Visible = false;
                dateTimePicker12.Visible = false;
                vadehesaplama();
            }
            else if (comboBox3.Text == "3")
            {
                label85.Visible = true;
                label89.Visible = true;
                label90.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker10.Visible = true;
                label93.Visible = false;
                label94.Visible = false;
                label87.Visible = false;
                dateTimePicker9.Visible = false;
                dateTimePicker11.Visible = false;
                dateTimePicker12.Visible = false;
                vadehesaplama();
            }
            else if (comboBox3.Text == "4")
            {
                label85.Visible = true;
                label87.Visible = true;
                label89.Visible = true;
                label90.Visible = true;
                label93.Visible = false;
                label94.Visible = false;
                dateTimePicker5.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                dateTimePicker10.Visible = true;
                dateTimePicker11.Visible = false;
                dateTimePicker12.Visible = false;
                vadehesaplama();
            }
            else if (comboBox3.Text == "5")
            {
                label85.Visible = true;
                label87.Visible = true;
                label89.Visible = true;
                label90.Visible = true;
                label94.Visible = true;
                label93.Visible = false;
                dateTimePicker5.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                dateTimePicker10.Visible = true;
                dateTimePicker12.Visible = true;
                dateTimePicker11.Visible = false;
                vadehesaplama();
            }
            else if (comboBox3.Text == "6")
            {
                label85.Visible = true;
                label87.Visible = true;
                label89.Visible = true;
                label90.Visible = true;
                label93.Visible = true;
                label94.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                dateTimePicker10.Visible = true;
                dateTimePicker11.Visible = true;
                dateTimePicker12.Visible = true;
                vadehesaplama();
            }
        }
        #endregion
        private void txtEcuzdanTutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left && dataGridView3.Columns[e.ColumnIndex].Name == "odeme")
                {
                    if (Convert.ToBoolean(dataGridView3.Rows[e.RowIndex].Cells[6].EditedFormattedValue))
                    {
                        int vadeid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value);
                        taksitguncelletrue(vadeid);
                    }
                    else
                    {
                        int vadeid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value);
                        taksitguncellefalse(vadeid);
                    }
                }
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                if (Convert.ToBoolean(dataGridView3.Rows[e.RowIndex].Cells[6].EditedFormattedValue))
                {
                    int vadeid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value);
                    taksitguncelletrue(vadeid);
                }
                else
                {
                    int vadeid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value);
                    taksitguncellefalse(vadeid);
                }
                    
            }
        }

        private void rdbNakitEkle_CheckedChanged(object sender, EventArgs e)
        {
            label89.Visible = false;
            dateTimePicker5.Visible = false;
        }
        private void label121_TextChanged(object sender, EventArgs e)
        {
            ecuzdanlabel();
        }
        #region yağölçüsü
        private void btnYagOlcumKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (dateTimePicker6.Text != "")
            {
                con.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO yagOlcum(yagKayitTarih,yagKg,yagVctYag,yagBMI,yagMuscle,yagSivi,yagMetobalizmaYasi,yagideKg,yagBoy,yagicYaglanma,yagRMK,yagAdiSoyadi) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", con);
                komut.Parameters.AddWithValue("@p1", dateTimePicker6.Text);
                komut.Parameters.AddWithValue("@p2", txtVucutAgirligi.Text);
                komut.Parameters.AddWithValue("@p3", txtVucutYag.Text);
                komut.Parameters.AddWithValue("@p4", txtBMI.Text);
                komut.Parameters.AddWithValue("@p5", txtMuscle.Text);
                komut.Parameters.AddWithValue("@p6", txtSiviAgirlik.Text);
                komut.Parameters.AddWithValue("@p7", txtMetobalizmaYas.Text);
                komut.Parameters.AddWithValue("@p8", txtKGideal.Text);
                komut.Parameters.AddWithValue("@p9", txtBoyYagOlcum.Text);
                komut.Parameters.AddWithValue("@p10", txtIcYaglanma.Text);
                komut.Parameters.AddWithValue("@p11", txtRMKCAL.Text);
                komut.Parameters.AddWithValue("@p12", lblAd.Text);
                komut.ExecuteNonQuery();
                con.Close();
                label126.Visible = true;
                label126.ForeColor = Color.Green;
                label126.Text = "Kayıt Tamamlanmıştır.";
                txtVucutAgirligi.Text = "";
                txtVucutYag.Text = "";
                txtBMI.Text = "";
                txtMuscle.Text = "";
                txtSiviAgirlik.Text = "";
                txtMetobalizmaYas.Text = "";
                txtKGideal.Text = "";
                txtBoyYagOlcum.Text = "";
                txtIcYaglanma.Text = "";
                txtRMKCAL.Text = "";
            }
            else
            {
                label126.Visible = true;
                label126.ForeColor = Color.Red;
                label126.Text = "Kayıt Tamamlanamadı.";
            }
            griddoldur3();
        }
        #endregion
        #region vucut olçüsü
        private void btnVucutOlcuKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (dateTimePicker7.Text != "")
            {
                con.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO VucutOlcumleri(vucutAgirligi,vucutBoy,vucutGogus,vucutBel,vucutKalca,vucutSolUstBacak,vucutSolBaldir,vucutSolKol,vucutOmuz,vucutGogusAlti," +
                    "vucutKarin,vucutBasen,vucutSagUstBacak,vucutSagBaldir,vucutSagKol,vucutTarih,vucutAdSoyad) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", con);
                komut.Parameters.AddWithValue("@p1", txtVucutAgirlgi.Text);
                komut.Parameters.AddWithValue("@p2", txtBoy.Text);
                komut.Parameters.AddWithValue("@p3", txtGogus.Text);
                komut.Parameters.AddWithValue("@p4", txtBel.Text);
                komut.Parameters.AddWithValue("@p5", txtKalca.Text);
                komut.Parameters.AddWithValue("@p6", txtSolUstBacak.Text);
                komut.Parameters.AddWithValue("@p7", txtSolBaldir.Text);
                komut.Parameters.AddWithValue("@p8", txtSolKol.Text);
                komut.Parameters.AddWithValue("@p9", txtOmuz.Text);
                komut.Parameters.AddWithValue("@p10", txtGogusAlti.Text);
                komut.Parameters.AddWithValue("@p11", txtKarin.Text);
                komut.Parameters.AddWithValue("@p12", txtBasen.Text);
                komut.Parameters.AddWithValue("@p13", txtUstBacak.Text);
                komut.Parameters.AddWithValue("@p14", txtSagBaldir.Text);
                komut.Parameters.AddWithValue("@p15", txtSagKol.Text);
                komut.Parameters.AddWithValue("@p16", dateTimePicker7.Text);
                komut.Parameters.AddWithValue("@p17", lblAd.Text);
                komut.ExecuteNonQuery();
                con.Close();
                label127.Visible = true;
                label127.ForeColor = Color.Green;
                label127.Text = "Kayıt Tamamlanmıştır.";
                txtVucutAgirlgi.Text = "";
                txtBoy.Text = "";
                txtGogus.Text = "";
                txtBel.Text = "";
                txtKalca.Text = "";
                txtSolUstBacak.Text = "";
                txtSolBaldir.Text = "";
                txtSolKol.Text = "";
                txtOmuz.Text = "";
                txtGogusAlti.Text = "";
                txtKarin.Text = "";
                txtBasen.Text = "";
                txtUstBacak.Text = "";
                txtSagBaldir.Text = "";
                txtSagKol.Text = "";
            }
            else
            {
                label127.Visible = true;
                label127.ForeColor = Color.Red;
                label127.Text = "Kayıt Tamamlanamadı.";
            }
            griddoldur4();
        }
        #endregion
        private void frmUyeProfili_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'salonYonetimDataSet22.TaksitTable' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.taksitTableTableAdapter.Fill(this.salonYonetimDataSet22.TaksitTable);
            // TODO: Bu kod satırı 'salonYonetimDataSet15.Ecuzdan' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ecuzdanTableAdapter.Fill(this.salonYonetimDataSet15.Ecuzdan);
            // TODO: Bu kod satırı 'salonYonetimDataSet14.VucutOlcumleri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.vucutOlcumleriTableAdapter1.Fill(this.salonYonetimDataSet14.VucutOlcumleri);
            // TODO: Bu kod satırı 'salonYonetimDataSet13.VucutOlcumleri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.vucutOlcumleriTableAdapter.Fill(this.salonYonetimDataSet13.VucutOlcumleri);
            // TODO: Bu kod satırı 'salonYonetimDataSet12.yagOlcum' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.yagOlcumTableAdapter.Fill(this.salonYonetimDataSet12.yagOlcum);
            // TODO: Bu kod satırı 'salonYonetimDataSet11.AboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
         //   this.aboneKayitTableAdapter4.Fill(this.salonYonetimDataSet11.AboneKayit);
            // TODO: Bu kod satırı 'salonYonetimDataSet7.AboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aboneKayitTableAdapter3.Fill(this.salonYonetimDataSet7.AboneKayit);
            // TODO: Bu kod satırı 'salonYonetimDataSet6.AboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aboneKayitTableAdapter2.Fill(this.salonYonetimDataSet6.AboneKayit);
            // TODO: Bu kod satırı 'salonYonetimDataSet5.ozelAboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ozelAboneKayitTableAdapter1.Fill(this.salonYonetimDataSet5.ozelAboneKayit);
            // TODO: Bu kod satırı 'salonYonetimDataSet4.ozelAboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ozelAboneKayitTableAdapter.Fill(this.salonYonetimDataSet4.ozelAboneKayit);
            // TODO: Bu kod satırı 'salonYonetimDataSet3.AboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aboneKayitTableAdapter1.Fill(this.salonYonetimDataSet3.AboneKayit);
            // TODO: Bu kod satırı 'salonYonetimDataSet2.AboneKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aboneKayitTableAdapter.Fill(this.salonYonetimDataSet2.AboneKayit);
            cmbOdemeSekli.SelectedIndex = 0;
            griddoldur();
            griddoldur2();
            griddoldur3();
            griddoldur4();
            griddoldur5();
            griddoldur7();
            griddoldur8();
            paketgetir();
            ozelpaketgetir();
            egitmengetir();
            isimgetir();
            lblAd.Text = adi;
            label15.Text = adi;
            lblTc.Text = tckimlikno;
            label128.Text = adi;
            label29.Text = adi;
            label30.Text = adi;
            label39.Text = adi;
            label76.Text = adi;
            label78.Text = adi;
            label81.Text = adi;
            label114.Text = adi;
            label91.Text = id;
            ecuzdanlabel();
            label16.Text = telefon;
            label17.Text = acilyakin;
            label18.Text = acilyakintel;
            panel10.Visible = false;
            panel11.Visible = false;
            panel17.Visible = false;
            panel25.Visible = false;
            panel23.Visible = false;
            panel12.Visible = false;
            panel29.Visible = false;
            panel19.Visible = false;
            dataGridView3.Visible = false;
            dtAbonelikRaporu.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            yagDataGrid.Visible = false;
            comboBox3.SelectedIndex = 0;
        }
    }
}
