using Xamarin.Forms;

namespace XF.Contato.Model
{
    /// <summary>
    /// Defines the contato model.
    /// </summary>
    public class ContatoModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or ests the Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Numero
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        public ImageSource Thumbnail { get; set; }

        #endregion
    }
}
