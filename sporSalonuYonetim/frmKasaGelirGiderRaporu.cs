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
    public partial class frmKasaGelirGiderRaporu : Form
    {
        sqlbaglanti gnl = new sqlbaglanti();
        DataTable tablo = new DataTable();
        DataTable tablo1 = new DataTable();
        SqlCommand cmd;
        SqlDataAdapter da;
        public static GirisBilgi User { get; set; }
        public frmKasaGelirGiderRaporu()
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
        void kasatumulistele()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            da = new SqlDataAdapter("SELECT islemtarihi,kasaAciklama,islemtarihi,kasaTutar,secim FROM KasaGelirGider", con);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
        }
        void aciklamagetir()
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open(); cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT KasaGelirGider.kasaAciklama FROM KasaGelirGider";
            cmd.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd);
            da3.Fill(dt3);

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

        private void frmKasaGelirGiderRaporu_Load(object sender, EventArgs e)
        {
            kasatumulistele();
            dateTimePicker1.Value = DateTime.Now;
            dtBaslangicTarihi.Value = DateTime.Now;
            dtBitisTarihi.Value = DateTime.Now;


        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            tablo.Clear();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT islemtarihi,kasaAciklama,islemtarihi,kasaTutar,secim FROM KasaGelirGider " +
                "WHERE islemtarihi=@gun", con);
                adtr.SelectCommand.Parameters.AddWithValue("@gun", Convert.ToDateTime(dateTimePicker1.Text));
            
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(kasaTutar) FROM KasaGelirGider WHERE islemtarihi=@gun", con);
                cmd.Parameters.AddWithValue("@gun", Convert.ToDateTime(dateTimePicker1.Text));
                label6.Text = cmd.ExecuteScalar() + " TL";
                con.Close();
            
           
        }

        private void btnListele1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            tablo.Clear();
            con.Open();
            if (comboBox1.Text == "Ay Seçiniz..." || comboBox2.Text == "Yıl Seçiniz...")
            {
                label12.Visible = true;
                label12.ForeColor = Color.Red;
                label12.Text = "Lütfen Ay ve Tarih Seçiniz";
            }
            else { 
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT islemtarihi,kasaAciklama,islemtarihi,kasaTutar,secim FROM KasaGelirGider WHERE MONTH(islemtarihi)=@ay AND YEAR(islemtarihi)=@yil", con);
            adtr.SelectCommand.Parameters.AddWithValue("@ay", comboBox1.SelectedIndex + 1);
            adtr.SelectCommand.Parameters.AddWithValue("@yil", comboBox2.Text);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(kasaTutar) FROM KasaGelirGider WHERE MONTH(islemtarihi)=@ay AND YEAR(islemtarihi)=@yil", con);
            cmd.Parameters.AddWithValue("@ay", comboBox1.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@yil", comboBox2.Text);
            label6.Text = cmd.ExecuteScalar() + " TL";
            con.Close();
            }
        }

        private void btnListele2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            tablo.Clear();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT islemtarihi,kasaAciklama,islemtarihi,kasaTutar,secim FROM KasaGelirGider WHERE islemtarihi BETWEEN @tar1 AND @tar2", con);
            adtr.SelectCommand.Parameters.AddWithValue("@tar1", Convert.ToDateTime(dtBaslangicTarihi.Text));
            adtr.SelectCommand.Parameters.AddWithValue("@tar2", Convert.ToDateTime(dtBitisTarihi.Text));
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(kasaTutar) FROM KasaGelirGider WHERE islemtarihi BETWEEN @tar1 AND @tar2 ", con);
            cmd.Parameters.AddWithValue("@tar2", Convert.ToDateTime(dtBitisTarihi.Text));
            cmd.Parameters.AddWithValue("@tar1", Convert.ToDateTime(dtBaslangicTarihi.Text));
            label6.Text = cmd.ExecuteScalar() + " TL";
            con.Close();
       
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            tablo.Clear();
            da = new SqlDataAdapter("SELECT islemtarihi,kasaAciklama,islemtarihi,kasaTutar,secim FROM KasaGelirGider WHERE kasaAciklama LIKE '%" + textBox1.Text + "%'", con);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;//aslında bu datayı mı aktarıyotrsun hocam excel e aynen hocam datagriddeki verileri tamm hocam 1 saniye tammdır 
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(kasaTutar) FROM KasaGelirGider WHERE kasaAciklama LIKE '%" + textBox1.Text + "%'", con);
            label6.Text = cmd.ExecuteScalar() + " TL";
            con.Close();
            aciklamagetir();
        }
    }
}
    
