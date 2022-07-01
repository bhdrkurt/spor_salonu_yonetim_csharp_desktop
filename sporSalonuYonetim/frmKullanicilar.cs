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
using static sporSalonuYonetim.Models.Yetkiler;

namespace sporSalonuYonetim
{
    public partial class frmKullanicilar : Form
    {
        public static GirisBilgi User { get; set; }
        public frmKullanicilar()
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


        sqlbaglanti gnl = new sqlbaglanti();
        SqlDataAdapter da;
        Yetkiler yetki = new Yetkiler();


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
        void kullanicilarigetir()
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            da = new SqlDataAdapter("SELECT id,kullaniciAdi,sifre FROM GirisBilgi", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
           
            
            if (txtKullaniciAdi.Text != "" && txtKullaniciSifre.Text != "")
            {
                SqlConnection con = new SqlConnection(gnl.conString);
                con.Open();
                string sorgu = "INSERT INTO GirisBilgi(kullaniciAdi,sifre) VALUES (@p1,@p2) SELECT SCOPE_IDENTITY()";
               
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@p2", txtKullaniciSifre.Text);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                string sorgu1 = "INSERT INTO KullaniciYetkiler(yetkiId,kullaniciId) VALUES (@p1,@p2)";
                SqlCommand cmd1 = new SqlCommand(sorgu1, con);
                if (radioButton1.Checked == true)
                {
                    cmd1.Parameters.AddWithValue("@p1", label12.Text);
                    cmd1.Parameters.AddWithValue("@p2", id);
                    cmd1.ExecuteNonQuery();
                }
                else if (radioButton4.Checked == true)
                {
                    cmd1.Parameters.AddWithValue("@p1", label12.Text);
                    cmd1.Parameters.AddWithValue("@p2", id);
                    cmd1.ExecuteNonQuery();
                }
                else if (radioButton5.Checked == true)
                {
                    cmd1.Parameters.AddWithValue("@p1", label12.Text);
                    cmd1.Parameters.AddWithValue("@p2", id);
                    cmd1.ExecuteNonQuery();
                }
                label4.Visible = true;
                label4.ForeColor = Color.Green;
                label4.Text = "Kayıt Tamamlandı.";
                txtKullaniciAdi.Text = "";
                txtKullaniciSifre.Text = "";
                con.Close();
                kullanicilarigetir();
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Boşlukları doldurunuz";
            }
        }

        private void frmKullanicilar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'salonYonetimDataSet1.GirisBilgi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
           // this.girisBilgiTableAdapter.Fill(this.salonYonetimDataSet1.GirisBilgi);
            kullanicilarigetir();
            dataGridView1.ClearSelection();
            txtKullaniciSifre.Text = "";
            txtKullaniciAdi.Text = "";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtKullaniciSifre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            con.Open();
            string sorgu = "UPDATE GirisBilgi SET kullaniciAdi=@p1,sifre=@p2 WHERE id='"+label6.Text+"'";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@p2", txtKullaniciSifre.Text);
            cmd.ExecuteNonQuery();
            string sorgu1 = "UPDATE KullaniciYetkiler SET yetkiId=@p1,kullaniciId=@p2 WHERE kullaniciId='" + label6.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sorgu1, con);
            if (radioButton1.Checked == true)
            {
                cmd1.Parameters.AddWithValue("@p1", label12.Text);
                cmd1.Parameters.AddWithValue("@p2", label6.Text);
                cmd1.ExecuteNonQuery();
            }
            else if (radioButton4.Checked == true)
            {
                cmd1.Parameters.AddWithValue("@p1", label12.Text);
                cmd1.Parameters.AddWithValue("@p2", label6.Text);
                cmd1.ExecuteNonQuery();
            }
            else if (radioButton5.Checked == true)
            {
                cmd1.Parameters.AddWithValue("@p1", label12.Text);
                cmd1.Parameters.AddWithValue("@p2", label6.Text);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
            label4.Visible = true;
            label4.ForeColor = Color.Green;
            label4.Text = "Düzenleme Tamamlandı.";
            txtKullaniciAdi.Text = "";
            txtKullaniciSifre.Text = "";
            kullanicilarigetir();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "1";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "2";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "3";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            string sorgu = "DELETE FROM KullaniciYetkiler WHERE kullaniciId=@islemid";
            string sorgu1 = "DELETE FROM GirisBilgi WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            SqlCommand cmd1 = new SqlCommand(sorgu1, con);
            cmd.Parameters.AddWithValue("@islemid", Convert.ToInt32(label6.Text));
            cmd1.Parameters.AddWithValue("@id", Convert.ToInt32(label6.Text));

            con.Open();

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
            label4.Visible = true;
            label4.ForeColor = Color.Green;
            label4.Text = "Silme İşlemi Tamamlandı.";
            txtKullaniciAdi.Text = "";
            txtKullaniciSifre.Text = "";
            kullanicilarigetir();
        }
    }
}
