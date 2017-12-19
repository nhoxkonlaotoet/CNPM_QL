using System.Drawing;
using System.IO;

namespace CNPM
{

    public class MyConvert
    {
        public MyConvert(){}
        public static byte[] ImageToByteArray(Image imageIn)
        {
            //MemoryStream ms = new MemoryStream();
            //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //return ms.ToArray();
            return (byte[])new ImageConverter().ConvertTo(imageIn, typeof(byte[]));
        }
        public static Image ByteArrayToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}

