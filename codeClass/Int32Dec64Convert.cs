using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    /// <summary>
    /// 实现10进制数与64进制字符串之间的转换
    /// </summary>
    class Int32Dec64Convert
    {
        /// <summary>
        /// 将bitmap编制为Base64编码
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static string EncodeBase64StringFromBitmap(Bitmap bitmap)
        {
            if (bitmap == null) return null;
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            byte[] b = ms.GetBuffer();
            return Convert.ToBase64String(b);
        }
        /// <summary>
        /// 将Base64编码解码为位图
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Bitmap DecodeBase64BitmapFromString(string str)
        {
            byte[] b = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(b);
            return new Bitmap(ms);
        }
        /// <summary>
        /// 统一图片
        /// </summary>
        /// <param name="size"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap ConverToSquareBitmap(int size, Image image)
        {
            Bitmap bitmap = new Bitmap(size, size);
            int width;
            int height;
            int x;
            int y;
            if (image.Width > image.Height)
            {
                width = size;
                height = (int)(size * (double)((double)image.Height / image.Width));
                x = 0;
                y = (size - height) / 2;
            }
            else
            {
                height = size;
                width = (int)(size * (double)((double)image.Width / image.Height));
                y = 0;
                x = (size - width) / 2;
            }
            Bitmap bitmap2;
            if (image.Width > size || image.Height > size) bitmap2 = new Bitmap(image, width, height);
            else
            {
                x = (size - image.Width) / 2;
                y = (size - image.Height) / 2;
                bitmap2 = new Bitmap(image);
            }
            Graphics gp = Graphics.FromImage(bitmap);
            gp.DrawImage(bitmap2, new Point(x, y));
            return bitmap;
        }
        /// <summary>
        /// 将字符串按特定秘钥转成base64编码
        /// </summary>
        /// <param name="serial"></param>
        public static string encryptSerialToBase64Code(string serial, string key)
        {
            string temp_str = "";
            if (serial.Length > 0x100 - 2) throw new Exception("serial too long");
            byte[] b = new byte[0x100];
            b[0] = Convert.ToByte((2 + key[0 % key.Length]) % 0x100);
            b[1] = Convert.ToByte((serial.Length + key[1 % key.Length]) % 0x100);
            for (int i = 2; i < b.Length; i++)
            {
                b[i] = Convert.ToByte((serial[((i - 2) + ((i - 2) / (serial.Length)) * key[i % key.Length]) % serial.Length] + key[i % key.Length]) % 0x100);
            }
            temp_str = Convert.ToBase64String(b);
            return temp_str;
        }
        /// <summary>
        /// 解密Base64字符串
        /// </summary>
        /// <param name="base64Code"></param>
        /// <param name="key"></param>
        public static string discryptBase64CodeToSerial(string base64Code, string key)
        {
            byte[] b = Convert.FromBase64String(base64Code);
            /* 利用秘钥修饰源字符串 */
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = Convert.ToByte((b[i] - key[i % key.Length]) % 0x100);
            }
            string temp_str = Encoding.Default.GetString(b);
            int index = b[0];
            int length = b[1];
            string serial = temp_str.Substring(index, length);
            return serial;
        }
    }
}
