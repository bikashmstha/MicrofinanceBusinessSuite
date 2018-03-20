using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MicrofinanceBusinessSuite.Handlers.Common
{
    /// <summary>
    /// Summary description for PHOTOUploader
    /// </summary>
    public class PHOTOUploader : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //SystemMacAddressController objMacAddress=new SystemMacAddressController ();
            string path = context.Request.Form["submissionNo"];     //var submissionNoValue='\\Uploads\\EmployeeImg\\'   //ImagePathName

            string empId = context.Request.Form["employeeId"];
           

            string folderPath = context.Server.MapPath(path);

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            //bool isExists = Directory.Exists(HttpContext.Current.Server.MapPath("~/uploads/") + submissionNo);
            //if (!isExists)
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/uploads/") + submissionNo);

            HttpPostedFile posted = HttpContext.Current.Request.Files[0];

            string extension = System.IO.Path.GetExtension(posted.FileName);

            string guid = Guid.NewGuid().ToString()+" ";
            string fullPath = folderPath + guid + empId + extension;

            posted.SaveAs(fullPath);

            var responseText = " {\"success\":true,\"macid\":\"" + "1" + "\",\"msg\":\"" + (guid + empId + extension) + "\",\"error_code\": null}";
            context.Response.Write(responseText);
            context.Response.End();
        }
        //public void ProcessRequest(HttpContext context)
        //{
        //    //SystemMacAddressController objMacAddress=new SystemMacAddressController ();
        //    string submissionNo = context.Request.Form["submissionNo"];

        //    string folderPath = context.Server.MapPath("~/uploads/")+ submissionNo+"/";

        //    //Check whether Directory (Folder) exists.
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(folderPath);
        //    }

        //    //bool isExists = Directory.Exists(HttpContext.Current.Server.MapPath("~/uploads/") + submissionNo);
        //    //if (!isExists)
        //    //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/uploads/") + submissionNo);

        //    HttpPostedFile posted = HttpContext.Current.Request.Files[0];
        //    string GuidfileName = Guid.NewGuid() + posted.FileName;
        //    posted.SaveAs(folderPath + GuidfileName);

        //    var responseText = " {\"success\":true,\"macid\":\"" + submissionNo + "\",\"msg\":\"" + GuidfileName + "\",\"error_code\": null}";
        //    context.Response.Write(responseText);
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