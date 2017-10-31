namespace XF.Contato.ViewModel.Commands
{
    using System;
    using System.Windows.Input;
    using XF.Contato.Model;

    /// <summary>
    /// Defines the command to make a call.
    /// </summary>
    public class ContactPutThumbCommand : ICommand
    {
        #region Variables

        /// <summary>
        /// Sets the contato view model.
        /// </summary>
        private ContatoViewModel contatoVM;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the call command class.
        /// </summary>
        /// <param name="paramVM">The contato view model.</param>
        public ContactPutThumbCommand(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        public void CallCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            contatoVM.PutPhoto(parameter as ContatoModel);
        }

        #region Events

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        #endregion
    }
}
