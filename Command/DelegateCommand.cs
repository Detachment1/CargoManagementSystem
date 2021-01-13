using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CargoManagementSystem.Command
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc==null)
            {
                return true;
            }
            else
            {
                return this.CanExecuteFunc(parameter);
            }
            
        }

        public void Execute(object parameter)
        {
            this.ExecuteAction(parameter);
        }

        public Action<Object> ExecuteAction { get; set; }
        public Func<Object, bool> CanExecuteFunc { get; set; }
    }
}
