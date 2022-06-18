using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

namespace BiliBiliAPI.GUI.Converter
{
    /// <summary>
    /// 不使用转换器
    /// </summary>
    internal static class QRConvert
    {

        public static async Task<BitmapImage> Convert(string value)
        {
            BitmapImage bmp = new BitmapImage();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return await FromBase64(ToBase64(qrCodeImage));
        }

        private static string ToBase64(Bitmap bmp)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = System.Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("转换失败");
                return "";
            }
        }


        private static async  Task<BitmapImage> FromBase64(string base64)
        {
            // read stream
            var bytes = System.Convert.FromBase64String(base64);
            var image = bytes.AsBuffer().AsStream().AsRandomAccessStream();

            // decode image
            var decoder = await BitmapDecoder.CreateAsync(image);
            image.Seek(0);

            // create bitmap
            var bitmap1 = new BitmapImage();
            await bitmap1.SetSourceAsync(image);
            return bitmap1;
        }

        public static object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException("转换错误！不该调用本方法");
        }
    }
}
