namespace XF.Contato.Model.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Xamarin.Forms;
    using XF.Contato.API;

    /// <summary>
    /// Defines the contato model repository.
    /// </summary>
    public class ContatoModelRepository
    {
        #region Variables

        /// <summary>
        /// Sets the collection of contatos.
        /// </summary>
        private static List<ContatoModel> _Contatos;

        /// <summary>
        /// Sets the contato model repository instance singleton.
        /// </summary>
        private static readonly ContatoModelRepository instance = new ContatoModelRepository();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance of repository.
        /// </summary>
        public static ContatoModelRepository Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the contatos from agenda.
        /// </summary>
        /// <returns></returns>
        public static List<ContatoModel> GetContatos()
        {
            if (_Contatos != null)
                return _Contatos;

            _Contatos = DependencyService.Get<IContato>().GetContatos().ToList();

            return _Contatos;
        }

        #endregion
    }
}
