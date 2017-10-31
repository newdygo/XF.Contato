namespace XF.Contato.API
{
    using XF.Contato.Model;

    /// <summary>
    /// Defines the interface to manipulate contatos.
    /// </summary>
    public interface ICall
    {
        #region Methods

        /// <summary>
        /// Realizes a call for a contato.
        /// </summary>
        /// <param name="contato">The contato to call.</param>
        void Call(ContatoModel contato);

        #endregion
    }
}
