using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement
{
    /// <summary> 
    /// notification object base class 
    /// </summary> 
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        /// <summary> 
        /// property changed handler 
        /// </summary> 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> 
        /// raise property changed handler 
        /// </summary> 
        /// <param name="propertyName">property name to raise</param> 
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary> 
        /// raise many property changed handler 
        /// </summary> 
        /// <param name="propertyNames">properties to raise</param> 
        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException("propertyNames");
            }

            foreach (var propertyName in propertyNames)
            {
                this.RaisePropertyChanged(() => propertyName);
            }
        }

        /// <summary> 
        /// Raises the <see cref="PropertyChanged"/> event using expression. 
        /// </summary> 
        /// <typeparam name="TP">Expression</typeparam> 
        /// <param name="property">Property</param> 
        protected void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;

            if (null == propertyInfo)
            {
                throw new ArgumentException("The lambda expression ‘property‘ should point to a valid Property");
            }

            RaisePropertyChanged(propertyInfo.Name);
        }
    }
}
