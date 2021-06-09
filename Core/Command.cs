using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PropertiesValidation
{
    public class Command: ICommand
    {
        readonly Action<object> _actionParam;
        readonly Action _action;
        bool _canExecute;

        public Command(Action action, bool canExecute = true)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action<object> actionParam, bool canExecute = true)
        {
            _actionParam = actionParam;
            _canExecute = canExecute;
        }

        public bool IsCanExecute
        {
            get => _canExecute;
            set
            {
                if (_canExecute == value) return;
                _canExecute = value;
                CanExecuteChanged?.Invoke(this, new CanExecuteChangedEventArgs(value));
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsCanExecute;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            IsCanExecute = false;
            if (_actionParam != null)
                _actionParam?.Invoke(parameter);
            else
                _action?.Invoke();
            IsCanExecute = true;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class CanExecuteChangedEventArgs : EventArgs
    {
        public bool CanExecute { get; }

        public CanExecuteChangedEventArgs(bool canExecute)
        {
            CanExecute = canExecute;
        }
    }
}
