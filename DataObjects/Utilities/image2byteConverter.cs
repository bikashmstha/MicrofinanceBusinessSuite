using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Web;
using System.IO;

namespace DataObjects.Utilities
{
   public class image2byteConverter
    {
       public static byte[] image2byte(string docfilepath)
       {
           Image img = Image.FromFile(docfilepath);
           ImageConverter converter = new ImageConverter();
           return (byte[])converter.ConvertTo(img, typeof(byte[]));
       }
       public static string Byte2Photo(byte[] byteArray,string docfilepath)
       {
           using (MemoryStream ms = new MemoryStream(byteArray))
           {
               bool isExists = Directory.Exists(docfilepath);
               if (!isExists)
                   Directory.CreateDirectory(docfilepath);

               Bitmap img = (Bitmap)Image.FromStream(ms);
               string imageName = Guid.NewGuid() + ".jpg";
               img.Save(docfilepath + "\\" + imageName);
               return imageName;
           }
       }
    }
}
