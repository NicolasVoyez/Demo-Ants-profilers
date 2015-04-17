using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TestLeakingApp
{
    public class UltraBasicCommand : ICommand
    {
        public Action CommandAction { get; set; }
        public UltraBasicCommand(Action commandAction)
        {
            CommandAction = commandAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (CommandAction != null)
                CommandAction();
        }
    }
}
