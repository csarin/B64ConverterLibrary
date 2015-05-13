//----------------------------------------------------------------------------------//
//
//<author> César Reneses Cárcamo </author>
//<date> 13/05/2015  </date>
//<summary> Class helper convert Base64 to Image and a Image to Base64 </summary>
//<website> http://cesarreneses.net </website>
//
//----------------------------------------------------------------------------------//

namespace Base64ImageConverter.Helpers
{
    #region Usings

    using System;
    using System.IO;
    using System.Drawing.Imaging;

    #endregion

    public static class B64ConverterLibrary
    {
        #region Public Methods

        /// <summary>
        /// Convert Image to Base64 string.
        /// </summary>
        /// <param name="img"> Image source</param>
        /// <param name="format">Jpeg, Png, Tif, etc</param>
        /// <returns>Base64 string</returns>
        public static string ImageToBase64(System.Drawing.Image img, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                byte[] imgBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imgBytes);
                return base64String;
            }
        }

        /// <summary>
        /// Convert Base64 string to Image.
        /// </summary>
        /// <param name="base64String">Base64 string</param>
        /// <returns>Object System.Drawing.Image</returns>
        public static System.Drawing.Image Base64ToImage(string base64String)
        {
                byte[] imgBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);

                ms.Write(imgBytes, 0, imgBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
        }

        #endregion
    }
}
