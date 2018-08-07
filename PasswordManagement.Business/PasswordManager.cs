using log4net;
using PasswordManagement.DataAccess;
using PasswordManagement.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.Business
{
    public class PasswordManager
    {
        private readonly ILog _logger = LogManager.GetLogger(nameof(PasswordManager));

        public List<SiteModel> GetSitePassword()
        {
            var result = new List<SiteModel>();
            try
            {
                result = DalPassword.GetPasswordImformation();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return result;
        }
    }
}
