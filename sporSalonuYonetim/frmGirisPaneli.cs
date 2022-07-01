using sporSalonuYonetim.DataAccess;
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
    public partial class frmGirisPaneli : Form
    {
        GirisBilgiDal _girisBilgiDal;
        public frmGirisPaneli()
        {
            InitializeComponent();
            _girisBilgiDal = new GirisBilgiDal();
        }
        sqlbaglanti gnl = new sqlbaglanti();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand komut = new SqlCommand(@"SELECT TOP 1000 [kullaniciAdi] ,[sifre] ,[id]
                                FROM [SalonYonetim].[dbo].[GirisBilgi] WHERE kullaniciAdi=@kullaniciAdi AND sifre=@sifre", con);

            con.Open();
            komut.Parameters.AddWithValue("kullaniciAdi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("sifre", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                GirisBilgi user = new GirisBilgi();
                user.Id = (int)dr["id"];
                user.UserName = dr["kullaniciAdi"].ToString();
                user.Roles = _girisBilgiDal.GetUserRoles(user);

                this.Hide();
                frmAnasayfa.User = user; //user static değişken olarak tanımlandı
                frmAnasayfa frm = new frmAnasayfa();
                frm.Show();
            }
            else
            {
                label4.Text = "Hatalı Kullanıcı adı veya Parola. Lütfen Kontrol Ediniz";
            }
            con.Close();
        }
    }
}
