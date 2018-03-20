using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace MicrofinanceBusinessSuite.Handlers.Common
{
    /// <summary>
    /// Summary description for PHOTOCutter
    /// </summary>
    public class PHOTOCutter : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {   

            string path = context.Request.Form["submissionNo"];     //var submissionNoValue='\\Uploads\\EmployeeImg\\'   //ImagePathName

            string empId = context.Request.Form["employeeId"];
            string Requestedimg = context.Request.Form["img"].ToString();
            string imgName = context.Request.Form["imgName"];

            string folderPath = context.Server.MapPath(path);

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            string extension = System.IO.Path.GetExtension(Requestedimg);
            //
            string guid = Guid.NewGuid().ToString() + " ";
            string fullPath = folderPath + guid + empId + extension;
            //string fullPath = folderPath + empId + extension;

            int x = (int)Math.Round(Convert.ToDecimal(context.Request.Form["X"].ToString()));
            int y = (int)Math.Round(Convert.ToDecimal(context.Request.Form["Y"].ToString()));
            int w = (int)Math.Round(Convert.ToDecimal(context.Request.Form["W"].ToString()));
            int h = (int)Math.Round(Convert.ToDecimal(context.Request.Form["H"].ToString()));

            System.Drawing.Image image = Bitmap.FromFile(folderPath + imgName);
            w = w == 0 ? 100 : w;
            h = h == 0 ? 100 : h;
            Bitmap bmp = new Bitmap(w, h, image.PixelFormat);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(image, new Rectangle(0, 0, w, h),
            new Rectangle(x, y, w, h),
            GraphicsUnit.Pixel);

            

            


            //string OutPutFileName = Guid.NewGuid().ToString() + Requestedimg;
            bmp.Save(fullPath, image.RawFormat);


            context.Response.Write("{success:true,\"macid\":\"" + "1" + "\",imgFullName:\"" + (guid + empId + extension) + "\",imgName:\"" + (empId + extension) + "\"}");
           // context.Response.Write("{success:true,\"macid\":\"" + "1" + "\",msg:\"" + (empId + extension) + "\"}");
            context.Response.End();
        }

        //public void ProcessRequest(HttpContext context)
        //{

        //    //SystemMacAddressController objMacAddress = new SystemMacAddressController();
        //    string submissionNo = context.Request.Form["submissionNo"];
        //    string folderPath = context.Server.MapPath("~/uploads/") + submissionNo + "/";

        //    //Check whether Directory (Folder) exists.
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(folderPath);
        //    }

        //    int x = (int)Math.Round(Convert.ToDecimal(context.Request.Form["X"].ToString()));
        //    int y = (int)Math.Round(Convert.ToDecimal(context.Request.Form["Y"].ToString()));
        //    int w = (int)Math.Round(Convert.ToDecimal(context.Request.Form["W"].ToString()));
        //    int h = (int)Math.Round(Convert.ToDecimal(context.Request.Form["H"].ToString()));
        //    string Requestedimg = context.Request.Form["img"].ToString();

        //    System.Drawing.Image image = Bitmap.FromFile(folderPath + Requestedimg);
        //    w = w == 0 ? 100 : w;
        //    h = h == 0 ? 100 : h;
        //    Bitmap bmp = new Bitmap(w, h, image.PixelFormat);
        //    Graphics g = Graphics.FromImage(bmp);
        //    g.DrawImage(image, new Rectangle(0, 0, w, h),
        //    new Rectangle(x, y, w, h),
        //    GraphicsUnit.Pixel);




        //    string OutPutFileName = Guid.NewGuid().ToString() + Requestedimg;
        //    bmp.Save(folderPath + OutPutFileName, image.RawFormat);


        //    context.Response.Write("{success:true,\"macid\":\"" + submissionNo + "\",msg:\"" + OutPutFileName + "\"}");
        //    context.Response.End();
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}