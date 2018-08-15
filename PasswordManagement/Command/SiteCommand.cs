using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManagement.Command
{
    public class SiteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> execute;

        private Predicate<object> canExecute;

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public SiteCommand(Action<object> execute)       //定义Action，CanExecute
           : this(execute, DefaultCanExecute)
        {
        }

        public SiteCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        private static bool DefaultCanExecute(object parameter)  //DefaultCanExecute方法
        {
            return true;
        }
    }
}
