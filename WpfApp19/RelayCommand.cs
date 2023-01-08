using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp19
{
    class RelayCommand : ICommand
    {
        private readonly Action<Object> execute;
        private readonly Func<object, bool> canexecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<Object> Execute, Func<object, bool> CanExecute) 
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute)); 
                                                                                   
            canexecute = CanExecute;
        }
        public bool CanExecute(object parameter) => canexecute?.Invoke(parameter) ?? true;
        public void Execute(object parameter) => execute(parameter);

    }
}