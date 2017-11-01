namespace XF.Contato.Droid.Common.Extension
{
    using Android.Graphics;
    using System;
    using System.IO;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the extension methods to image.
    /// </summary>
    public static class ImageExtension
    {
        #region Methods

        /// <summary>
        /// Converts a bitmap image to a image source.
        /// </summary>
        /// <param name="image">The bitmap to be converted.</param>
        /// <returns>A ImageSource.</returns>
        public static ImageSource ToImageSource(this Bitmap image)
        {
            //return ImageSource.FromFile(@"C:/Temp/diego_perfil.png");
            //return ImageSource.FromUri(new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"));

            //return new Image() { Source = ImageSource.FromFile(@"C:\Temp\diego_perfil.jpg") };

            //if (image == null)
            //    return ImageSource.FromUri(new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"));

            var stream = new MemoryStream();

            image.Compress(Bitmap.CompressFormat.Png, 100, stream);

            var ff = stream.Length;

            return ImageSource.FromStream(() => stream);
        }

        #endregion
    }
}