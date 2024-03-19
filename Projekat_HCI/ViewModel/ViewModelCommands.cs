using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekat_HCI.ViewModel
{
    public class ViewModelCommands : ICommand
    {
        //Fields

        private readonly Action<object>? _executeAction;
        //used encapsulate a method that is to pass a method as a parameter

        private readonly Predicate<object>? _canExecuteAction;
        //used to see if the action can be executed

        //Constructor
        public ViewModelCommands(Action<object>? executeAction, Predicate<object>? canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Constructor to execute action because not all commands need to be validated
        public ViewModelCommands(Action<object>? executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        //Subscrieb or unsubscribe the Requery suggested event as needed
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //RequerySuggested events occure when CommandMannager detects if the command execution condition has changed


        //if the canExecuteAction field is null we return true since delegation predicate has not been established otherwise
        //we return the value of the delegate or the method that is going to be defined and delegated in the viewModel
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true: _canExecuteAction(parameter);
        }
        //We just execute the action, same way this will execute method which will be delegated in viewModel
        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
