using sporSalonuYonetim.DataAccess.Abstract;
using sporSalonuYonetim.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sporSalonuYonetim.DataAccess
{
    public class GirisBilgiDal : IGirisBilgi
    {
        private SqlConnection _connection;
        public GirisBilgiDal()
        {
            _connection = new SqlConnection(new sqlbaglanti().conString);
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }
        public List<string> GetUserRoles(GirisBilgi user)
        {
            List<string> yetkiler = new List<string>();
            using (SqlCommand cm = new SqlCommand(@"
                        SELECT 
                        ROLE_.adi [YetkiAdı]
                        FROM KullaniciYetkiler UROLE
                        INNER JOIN  Yetkiler ROLE_ ON UROLE.yetkiId = ROLE_.id
                        WHERE UROLE.kullaniciId = @userId", _connection))//sql connection nerede sabit var ? 
            {
                cm.Parameters.AddWithValue("userId", user.Id);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    yetkiler.Add(dr["YetkiAdı"].ToString());
                }
                return yetkiler;
            }
        }
    }
}
