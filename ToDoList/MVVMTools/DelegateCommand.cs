using System;
using System.Windows.Input;

namespace MVVMTools
{
    public class DelegateCommand<T> : ICommand
    {

        private Action<T?> targetExecuteMethod;
        private Func<T?, bool>? targetCanExecuteMethod;

        public DelegateCommand(Action<T?> executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }

        public DelegateCommand(Action<T?> executeMethod, Func<T?, bool> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => targetCanExecuteMethod?.Invoke((T?)parameter) ?? targetExecuteMethod != null;

        public event EventHandler? CanExecuteChanged = delegate { };

        public void Execute(object? parameter) => targetExecuteMethod?.Invoke((T?)parameter);

    }

    public class DelegateCommand : ICommand
    {

        private Action targetExecuteMethod;
        private Func<bool>? targetCanExecuteMethod;

        public DelegateCommand(Action executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => targetCanExecuteMethod?.Invoke() ?? targetExecuteMethod != null;

        public event EventHandler? CanExecuteChanged = delegate { };

        public void Execute(object? parameter) => targetExecuteMethod?.Invoke();
    }
}
