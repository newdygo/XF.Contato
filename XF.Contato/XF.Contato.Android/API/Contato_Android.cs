using Xamarin.Forms;
using XF.Contato.Droid;

[assembly: Dependency(typeof(Contato_Android))]
namespace XF.Contato.Droid
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Contacts;
    using XF.Contato.API;
    using XF.Contato.Model;

    /// <summary>
    /// Defines the Android implementation to manipulate contatos.
    /// </summary>
    public class Contato_Android : IContato
    {
        #region Methods

        /// <summary>
        /// Gets the contatos of the agenda.
        /// </summary>
        /// <returns>A list of contatos</returns>
        public IEnumerable<ContatoModel> GetContatos()
        {
            try
            {
                var list = new List<ContatoModel>();
                var book = new AddressBook(Forms.Context);

                book.RequestPermission().ContinueWith(t =>
                {

                    if (!t.IsFaulted)
                    {
                        if (t.Result)
                        {
                            foreach (Contact contact in book)
                            {
                                list.Add(new ContatoModel() { Nome = contact.DisplayName, Numero = contact.Phones.FirstOrDefault()?.Number });
                            }
                        }
                    }

                }).Wait();
                
                return list;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}