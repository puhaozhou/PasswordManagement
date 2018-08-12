using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagement.Business;
using PasswordManagement.DataAccess.Entity;

namespace PasswordManagement.ViewModels
{
    public class SiteViewModel : NotificationObject
    {
        private List<SiteModel> site_bind;
        public List<SiteModel> Site_Bind
        {
            get
            {
                return site_bind;
            }
            set
            {
                site_bind = value;
                this.RaisePropertyChanged("Site_Bind"); 
            }
        }

        public List<SiteModel> GetSitePassword()
        {
            var manager = new PasswordManager();
            var result = manager.GetSitePassword();
            return result;
        }

        public SiteViewModel()
        {
            Site_Bind = GetSitePassword();
        }
    }
}
