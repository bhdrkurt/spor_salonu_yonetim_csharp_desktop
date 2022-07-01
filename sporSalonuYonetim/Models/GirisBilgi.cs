using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sporSalonuYonetim.Models
{
    public class GirisBilgi
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Passwor { get; set; }
        public List<string> Roles { get; set; }
    }
}
