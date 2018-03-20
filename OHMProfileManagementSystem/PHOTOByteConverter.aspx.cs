using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MicrofinanceBusinessSuite
{
    public partial class PHOTOByteConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            byte[] imgBin = new byte[Context.Request.Files[0].ContentLength];
            HttpPostedFile img = Context.Request.Files[0];
            img.InputStream.Read(imgBin, 0, (int)Context.Request.Files[0].ContentLength);

            string rawdata = imgBin.Length.ToString();
            string type = Context.Request.Files[0].ContentType;
            string size = Context.Request.Files[0].ContentLength.ToString();

            string imgid = Guid.NewGuid().ToString();
            HttpContext.Current.Session[imgid] = imgBin;

            //HttpContext.Current.Server.MapPath("PHOTO");

            Response.Write("{\"success\":true,\"msg\":\""+imgid+"\"}");
            Response.End();
        }
    }
}