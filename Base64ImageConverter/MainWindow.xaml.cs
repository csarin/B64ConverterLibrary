//----------------------------------------------------------------------------------//
//
//<author> César Reneses Cárcamo </author>
//<date> 13/05/2015  </date>
//<summary> Class helper convert Base64 to Image and a Image to Base64 </summary>
//<website> http://cesarreneses.net </website>
//
//----------------------------------------------------------------------------------//

namespace Base64ImageConverter
{
    #region Usings

    using Base64ImageConverter.Helpers;
    using Microsoft.Win32;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows;

    #endregion

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txbSourcePath.Text = openFileDialog.FileName;
        }

        private void btnConvertToBase64_Click(object sender, RoutedEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(txbSourcePath.Text);

            txtBase64.Text = B64ConverterLibrary.ImageToBase64(img, ImageFormat.Jpeg);
        }

        private void btnConvertToImage_Click(object sender, RoutedEventArgs e)
        {
            var image = B64ConverterLibrary.Base64ToImage(txtBase64.Text);

            var bitmap = new System.Windows.Media.Imaging.BitmapImage();
            bitmap.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            bitmap.StreamSource = memoryStream;
            bitmap.EndInit();

            ImgConverted.Source = bitmap;
        }
    }
}
