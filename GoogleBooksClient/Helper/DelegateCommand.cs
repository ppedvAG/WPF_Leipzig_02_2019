using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoogleBooksClient.Helper
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                //RequerySuggested wird regelmäßig von einem Hintergrund-Thread aufgerufen (Millisekunden)
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        Action<object> _executeLogic;
        Func<object, bool> _canExecuteLogic;

        public DelegateCommand(Action<object> executeLogic, Func<object, bool> canExecuteLogic = null)
        {
            _executeLogic = executeLogic;
            _canExecuteLogic = canExecuteLogic;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecuteLogic != null)
            {
                return _canExecuteLogic(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _executeLogic?.Invoke(parameter);
        }
    }
}
