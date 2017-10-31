namespace XF.Contato.API
{
    using System.Collections.Generic;
    using XF.Contato.Model;

    /// <summary>
    /// Defines the interface to manipulate contatos.
    /// </summary>
    public interface IContato
    {
        #region Properties

        /// <summary>
        /// Gets the contatos of the agenda.
        /// </summary>
        /// <returns>A list of contatos.</returns>
        IEnumerable<ContatoModel> GetContatos();

        /// <summary>
        /// Sets the photo thumbnail for the contact.
        /// </summary>
        /// <param name="contato">The contato to call.</param>
        /// <param name="fileName">The file for the picture.</param>
        void PutPhoto(ContatoModel contato);

        /// <summary>
        /// Gets the photo thumbnail for the contact.
        /// </summary>
        void GetPhoto();

        #endregion
    }
}
