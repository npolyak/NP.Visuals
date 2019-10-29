using System;
using System.Windows.Input;

namespace NP.Visuals.Utils
{
    /// <summary>
    /// Provides a simple ICommand implementation.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private Action _action;
        private bool _canExecute = true;

        public DelegateCommand(Action action)
        {
            this._action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute;
        }

        public void Execute(object parameter)
        {
            this._action();
        }

        internal void SetCanExecute(bool canExecute)
        {
            this._canExecute = canExecute;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
