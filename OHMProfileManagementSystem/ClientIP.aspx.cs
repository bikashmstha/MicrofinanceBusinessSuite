using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Web.SessionState;
namespace MicrofinanceBusinessSuite
{
    public partial class ClientIP : System.Web.UI.Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var ip = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
              && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
             ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
             : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    if (ip.Contains(","))
                        ip.Split(',').First().Trim();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}