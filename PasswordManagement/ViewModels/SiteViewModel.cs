using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagement.Business;
using PasswordManagement.DataAccess.Entity;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using PasswordManagement.Command;
using System.Windows.Media;

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

        public void ShowEditMode(object obj)
        {
            var EditButton = (Button) obj;
            EditButton.Visibility = Visibility.Hidden;
            var parent = VisualTreeHelper.GetParent(EditButton);
        }

        public ICommand EditButtonCommand          //定义接口
        {
            get
            {
                return new SiteCommand(ShowEditMode);
            }            
        }
    }
}
