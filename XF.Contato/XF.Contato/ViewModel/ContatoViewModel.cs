namespace XF.Contato.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;
    using XF.Contato.API;
    using XF.Contato.Model;
    using XF.Contato.Model.Repository;
    using XF.Contato.ViewModel.Commands;

    /// <summary>
    /// Defines the contato view model.
    /// </summary>
    public class ContatoViewModel : INotifyPropertyChanged
    {
        #region Variables

        /// <summary>
        /// Sets the selected contato.
        /// </summary>
        private ContatoModel _SelectedContato;

        #endregion

        #region Properties

        /// <summary>
        /// Gests or sets the selected contato
        /// </summary>
        public ContatoModel SelectedContato
        {
            get { return _SelectedContato; }
            set
            {
                _SelectedContato = value as ContatoModel;
                EventPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the collection of contatos.
        /// </summary>
        public ObservableCollection<ContatoModel> Contatos { get; set; }

        /// <summary>
        /// Gets the call command.
        /// </summary>
        public CallCommand CallCommand { get; }
        
        /// <summary>
        /// Gets the contact command.
        /// </summary>
        public ContactPutThumbCommand ContactPutThumbCommand { get; }

        #endregion

        #region Construtors

        /// <summary>
        /// Initializes the contato view model.
        /// </summary>
        public ContatoViewModel()
        {
            Contatos = new ObservableCollection<ContatoModel>(ContatoModelRepository.GetContatos());

            CallCommand = new CallCommand(this);
            ContactPutThumbCommand = new ContactPutThumbCommand(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the call to the contato.
        /// </summary>
        /// <param name="contato">The contato to call.</param>
        public void Call(ContatoModel contato)
        {
            DependencyService.Get<ICall>().Call(contato);
        }

        /// <summary>
        /// Initializes the call to the contato.
        /// </summary>
        public void GetPhoto()
        {
            DependencyService.Get<IContato>().GetPhoto();
        }

        /// <summary>
        /// Initializes the call to the contato.
        /// </summary>
        /// <param name="contato">The contato to call.</param>
        public void PutPhoto(ContatoModel contato)
        {
            DependencyService.Get<IContato>().PutPhoto(contato);
            DependencyService.Get<IContato>().GetPhoto();
        }

        /// <summary>
        /// Fires when a property is changed.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Events

        /// <summary>
        /// The event to fire when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #endregion
    }
}
