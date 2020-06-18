/*
 * -----------------------------------------------------------------------------
 *	 
 *   Filename		:   RelayCommand.cs
 *   Date			:   2020-06-18 12:22:59
 *   All rights reserved
 * 
 * -----------------------------------------------------------------------------
 * @author     Patrick Robin <support@rietrob.de>
 * @Version      1.0.0
 */

using System;
using System.Windows.Input;

namespace RelayCommandLibrary
{
    public class RelayCommand : ICommand
    {
        
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute,null)
        {
            
        }
        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        #endregion

        #region Eventhandler

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

    }
}