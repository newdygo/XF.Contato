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

        #endregion
    }
}
