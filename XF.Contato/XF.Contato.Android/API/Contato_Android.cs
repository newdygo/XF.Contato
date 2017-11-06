using Xamarin.Forms;
using XF.Contato.Droid;

[assembly: Dependency(typeof(Contato_Android))]
namespace XF.Contato.Droid
{
    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.Provider;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Xamarin.Contacts;
    using Xamarin.Media;
    using XF.Contato.API;
    using XF.Contato.Droid.Common.Extension;
    using XF.Contato.Model;

    /// <summary>
    /// Defines the Android implementation to manipulate contatos.
    /// </summary>
    public class Contato_Android : IContato
    {
        #region Variables

        /// <summary>
        /// Sets the contacts.
        /// </summary>
        private List<Contact> _Contacts;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        private List<Contact> Contacts
        {
            get
            {
                if (_Contacts == null)
                    _Contacts = GetContacts();

                return _Contacts;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the contatos of the agenda.
        /// </summary>
        /// <returns>A list of contatos</returns>
        private List<Contact> GetContacts()
        {
            try
            {
                var book = new AddressBook(Forms.Context);

                book.RequestPermission().Wait();

                return book.ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the contatos of the agenda.
        /// </summary>
        /// <returns>A list of contatos</returns>
        public IEnumerable<ContatoModel> GetContatos()
        {
            return Contacts.Select((contact, b) =>
            {
                return new ContatoModel()
                {
                    Id = contact.Id,
                    Nome = contact.DisplayName,
                    Numero = contact.Phones.FirstOrDefault()?.Number,
                    Thumbnail = contact.GetThumbnail().ToImageSource()
                };
            });
        }

        /// <summary>
        /// Sets the photo thumbnail for the contact.
        /// </summary>
        /// <param name="contato">The contato to call.</param>
        /// <param name="fileName">The file for the picture.</param>
        public void PutPhoto(ContatoModel contato)
        {
            MessagingCenter.Subscribe<IContato, string>(this, "thumb", (cont, fileName) =>
            {
                try
                {
                    contato.Thumbnail = ImageSource.FromFile(fileName);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            });
        }

        /// <summary>
        /// Gets the photo thumbnail for the contact.
        /// </summary>
        /// <returns>A filename.</returns>
        public void GetPhoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetPickPhotoUI();
            context.StartActivityForResult(intent, 1);
        }

        #endregion
    }
}