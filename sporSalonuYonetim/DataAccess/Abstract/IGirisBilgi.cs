using sporSalonuYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sporSalonuYonetim.DataAccess.Abstract
{
    interface IGirisBilgi
    {

        List<string> GetUserRoles(GirisBilgi user);
    }
}
