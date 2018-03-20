using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Common;
using MicrofinanceBusinessSuite.Controllers.Common;
using MicrofinanceBusinessSuite.Utility;
using System.IO;

namespace MicrofinanceBusinessSuite.Handlers.Common
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileHandler : BaseHandler
    {
        public object Upload()
        {


            ExtJSResponse resp = new ExtJSResponse();
            OutMessage omsg = new OutMessage();
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                string folderPath = context.Server.MapPath("~/uploads/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                //for (int i = 0; i < files.Count; i++)
                //{
                HttpPostedFile file = files[0];//files[i];
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg" };
                string ext = System.IO.Path.GetExtension(file.FileName);
                bool hasFile = !string.IsNullOrEmpty(file.FileName.Trim());
                if (!hasFile)
                {
                    resp.Success = "false";
                    resp.Message = "No File Selected. Please upload a File with extension " +
                           string.Join(",", validFileTypes);

                    return resp.GetResponse(null, null);
                }

                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile)
                {
                    resp.Success = "false";
                    resp.Message = "Invalid File. Please upload a File with extension " +
                           string.Join(",", validFileTypes);

                    return resp.GetResponse(null, null);
                }
                string fname;
                string fullname;
                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                    fname = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fname);
                }
                fullname = System.IO.Path.Combine(folderPath, fname);
                file.SaveAs(fullname);
                // }
                resp.Success = "true";
                resp.Message = fname;
            }

            return resp.GetResponse(null, null);


        }
    }
}