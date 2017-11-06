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
            var imgFile = new byte[image.Width * image.Height * 4];
            var stream = new MemoryStream(imgFile);

            image.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Flush();

            return ImageSource.FromStream(() => new MemoryStream(imgFile));
        }

        #endregion
    }
}