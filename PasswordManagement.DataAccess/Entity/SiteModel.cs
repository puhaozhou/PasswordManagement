using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.DataAccess.Entity
{
    public class SiteModel
    {
        public int Id { get; set; }
        public string SiteName { get; set; }

        public string SitePasword { get; set; }
    }
}
