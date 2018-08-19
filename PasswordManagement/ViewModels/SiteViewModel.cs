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
using PasswordManagement.App_Code;

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
            var BtUpdate = (Button) obj;
            BtUpdate.Visibility = Visibility.Hidden;
            //var parent = VisualTreeHelper.GetParent(EditButton);
            //var elementName = parent.GetType()?.Name;
            //if (!string.IsNullOrWhiteSpace(elementName))
            //{
            //    while (!elementName.Equals("DataGridTemplateColumn"))
            //    {

            //    }
            //}
            //var parent = EditButton.GetParentObject<DataGridTextColumn>();
        }

        public ICommand UpdateCommand  => new SiteCommand(ShowEditMode);
    }
}
