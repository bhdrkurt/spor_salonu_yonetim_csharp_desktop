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
    public partial class frmToptancislemYap : Form
    {
        public static GirisBilgi User { get; set; }
        sqlbaglanti gnl = new sqlbaglanti();
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        DataSet ds;
        public frmToptancislemYap()
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
        private void griddoldur()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT alisverisID,kayitTarihi,toptanciAdi,urunAdi,alisFiyati,adet,toplamFiyat FROM ToptanciAlisveris", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ToptanciAlisveris");
            dataGridView1.DataSource = ds.Tables["ToptanciAlisveris"];
            con.Close();
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            label13.Text = toplam.ToString() + " TL";

        }
        /* private void griddoldur2()
         {
             SqlConnection con = new SqlConnection(gnl.conString);
             da = new SqlDataAdapter("SELECT toptanciRaporID,raporKayitTarihi,raporToptanciAdi,raporUrunAdi,raporAlisFiyati,raporAdet,raporToplamFiyat FROM ToptanciAlisverisRapor", con);
             ds = new DataSet();
             con.Open();
             da.Fill(ds, "ToptanciAlisverisRapor");
             dataGridView2.DataSource = ds.Tables["ToptanciAlisverisRapor"];
             con.Close();
         }*/

        private void toptancigetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Toptanci.toptanciAdi FROM Toptanci ORDER BY Toptanci.toptanciAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbToptanciSec.Items.Add(dr["toptanciAdi"].ToString());
            }
            con.Close();

        }
        private void urungetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Urunler.urunAdi FROM Urunler ORDER BY Urunler.urunAdi ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cmbUrunSec.Items.Add(dr["urunAdi"].ToString());
            }
            con.Close();

        }
        private void btnSepeteGonder_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            if (cmbToptanciSec.Text == "")
            {
                label6.Visible = true;
                label6.ForeColor = Color.Red;
                label6.Text = "Lütfen bir toptancı seçiniz";
            }
            else if (cmbUrunSec.Text == "")
            {
                label6.Visible = true;
                label6.ForeColor = Color.Red;
                label6.Text = "Lütfen bir ürün seçiniz";
            }
            else if (cmbToptanciSec.Text != "" || cmbUrunSec.Text != "")
            {

                /* string sorgu2 = "INSERT INTO ToptanciAlisveris(alisverisID,kayitTarihi,toptanciAdi,urunAdi,alisFiyati,adet,toplamFiyat) VALUES(@p1,@p2,@p3,@p4,@p5,@p6)";
                 cmd1 = new SqlCommand(sorgu2, con);*/

                SqlCommand komut = new SqlCommand("INSERT INTO ToptanciAlisveris(kayitTarihi,toptanciAdi,urunAdi,alisFiyati,adet,toplamFiyat) VALUES(@p1,@p2,@p3,@p4,@p5,@p6)", con);
                komut.Parameters.AddWithValue("@p1", Convert.ToDateTime(dateTimePicker1.Text));
                komut.Parameters.AddWithValue("@p2", cmbToptanciSec.Text);
                komut.Parameters.AddWithValue("@p3", cmbUrunSec.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToDecimal(txtAlisFiyati.Text));
                komut.Parameters.AddWithValue("@p5", Convert.ToInt32(txtAdet.Text));
                komut.Parameters.AddWithValue("@p6", Convert.ToDecimal(txtToplamFiyat.Text));
                komut.ExecuteNonQuery();
                con.Close();

                // con.Open();
                /* */
                label6.Visible = true;
                label6.ForeColor = Color.Green;
                label6.Text = "Ürün Sepete Eklenmiştir. Yeni ürünler seçebilirsiniz!!";
                cmbToptanciSec.Text = "";
                cmbUrunSec.Text = "";
                txtAdet.Text = "1";
                txtAlisFiyati.Text = "";
                txtToplamFiyat.Text = "";


                /**/
            }
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            label13.Text = toplam.ToString() + " TL";

            griddoldur();
        }



        private void frmToptancislemYap_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'salonYonetimDataSet20.ToptanciAlisveris' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.toptanciAlisverisTableAdapter2.Fill(this.salonYonetimDataSet20.ToptanciAlisveris);
            // TODO: Bu kod satırı 'salonYonetimDataSet19.ToptanciAlisveris' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.toptanciAlisverisTableAdapter1.Fill(this.salonYonetimDataSet19.ToptanciAlisveris);
            SqlConnection con = new SqlConnection(gnl.conString);
            // TODO: Bu kod satırı 'salonYonetimDataSet18.ToptanciAlisveris' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.toptanciAlisverisTableAdapter.Fill(this.salonYonetimDataSet18.ToptanciAlisveris);
            //griddoldur2();
            toptancigetir();
            urungetir();
            griddoldur();
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            label13.Text = toplam.ToString() + " TL";
        }

        private void cmbUrunSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd1 = new SqlCommand("SELECT * FROM Urunler where urunAdi ='" + cmbUrunSec.Text + "'", con);

            cmd1.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();


            while (dr.Read())
            {
                string alisfiyat = (string)dr["alisFiyati"].ToString();
                txtAlisFiyati.Text = alisfiyat;


            }

            con.Close();
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {

            try
            {
                txtToplamFiyat.Text = (double.Parse(txtAdet.Text) * double.Parse(txtAlisFiyati.Text)).ToString();
            }
            catch (Exception)
            {

            }

        }

        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "DELETE FROM ToptanciAlisveris WHERE alisverisID=@islemid";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@islemid", Convert.ToInt32(label14.Text));
            /* string sorgu1 = "DELETE FROM ToptanciAlisverisRapor WHERE toptanciRaporID=@islemid";
             cmd1 = new SqlCommand(sorgu1, con);
             cmd1.Parameters.AddWithValue("@islemid", Convert.ToInt32(label14.Text));*/
            con.Open();

            cmd.ExecuteNonQuery();
            //cmd1.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void label13_TextChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(gnl.conString);
                con.Open();
                SqlCommand komut2 = new SqlCommand(@"
            INSERT INTO ToptanciAlisverisRapor(raporKayitTarihi,raporToptanciAdi,raporUrunAdi,raporAlisFiyati,raporAdet,raporToplamFiyat)
            VALUES(@p7,@p8,@p9,@p10,@p11,@p12)", con);

                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    komut2.Parameters.AddWithValue("@p7", (DateTime)dataGridView1.Rows[i].Cells[1].Value);
                    komut2.Parameters.AddWithValue("@p8", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    komut2.Parameters.AddWithValue("@p9", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    komut2.Parameters.AddWithValue("@p10", (decimal)dataGridView1.Rows[i].Cells[4].Value);
                    komut2.Parameters.AddWithValue("@p11", (int)dataGridView1.Rows[i].Cells[5].Value);
                    komut2.Parameters.AddWithValue("@p12", (decimal)dataGridView1.Rows[i].Cells[6].Value);
                    komut2.ExecuteNonQuery();
                    komut2.Parameters.Clear();
                }
                con.Close();

                con.Open();
                string sorgu = "TRUNCATE TABLE ToptanciAlisveris";//TRUNCATE TABLE ToptanciAlisveris
                cmd = new SqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
                label16.Visible = true;
                label16.ForeColor = Color.Green;
                label16.Text="İşlem Tamamlandı. Ödeme Yapıldı. Raporlardan Kontrol Edebilirsiniz !!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
