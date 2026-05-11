using System;
using System.Diagnostics;
using System.Windows.Input;

namespace RhinoWPFMVVVMIntro.ViewModels.Utility
{
    /// <summary>
    /// ICommand implementation that delegates execute and can-execute behavior.
    /// </summary>
    public sealed class RelayCommand : ICommand
    {
        readonly Action<object?> _execute;
        readonly Predicate<object?>? _canExecute;

        /// <summary>
        /// Initializes a command with execute behavior.
        /// </summary>
        public RelayCommand(Action<object?> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a command with execute and can-execute behavior.
        /// </summary>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute)
        {
            _execute = execute
                ?? throw new ArgumentException(nameof(execute));

            _canExecute = canExecute;
        }

        /// <summary>
        /// Returns whether the command can execute.
        /// </summary>
        [DebuggerStepThrough]
        public bool CanExecute(object? parameter)
            => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// Occurs when command execution availability changes.
        /// </summary>
        public event EventHandler? CanExecuteChanged
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

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute(object? parameter)
            => _execute(parameter);
    }
}
