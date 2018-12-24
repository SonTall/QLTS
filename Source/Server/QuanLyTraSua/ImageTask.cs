using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace QuanLyTraSua
{
    public static class ImageTask
    {
        public static string Write(byte[] arr)
        {
            //var filename = $@"Images\{DateTime.Now.Ticks}.";
            var filename = $@"{DateTime.Now.Ticks}.";
            using (var im = System.Drawing.Image.FromStream(new MemoryStream(arr)))
            {
                ImageFormat frmt;
                if (ImageFormat.Png.Equals(im.RawFormat))
                {
                    filename += "png";
                    frmt = ImageFormat.Png;
                }
                else
                {
                    filename += "jpg";
                    frmt = ImageFormat.Jpeg;
                }
                string path = HttpContext.Current.Server.MapPath("~/Images/") + filename;
                im.Save(path, frmt);
            }

            //return $@"http:\\{Request.RequestUri.Host}\{filename}";
            return filename;
        }

        public static string GetImage(string filename)
        {
            string sPic;
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/Images/") + filename;
                System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] bPic = stream.ToArray();
                sPic = System.Text.Encoding.Default.GetString(bPic);
            }
            catch (Exception)
            {

                sPic = "";
            }
            return sPic;
        }
    }
}