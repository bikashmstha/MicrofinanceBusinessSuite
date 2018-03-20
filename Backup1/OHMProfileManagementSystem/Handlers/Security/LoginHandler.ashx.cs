using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegratedTaxSystem.Controllers.Security;
 
using System.Web.SessionState;
using App.Utilities.Web.Handlers;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Security;



namespace MicrofinanceBusinessSuite.Handlers.Security
{
    /// <summary>
    /// Summary description for LoginHandler
    /// </summary>
    public class LoginHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            LoginController controller = new LoginController();

            string userID = "";
            string password = "";

            string macAdd1 = context.Request.UserHostAddress;

            string ipaddress;
            ipaddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = context.Request.ServerVariables["REMOTE_ADDR"];

            if (context.Request.Form.ToString().Contains("userID") && (!string.IsNullOrEmpty(context.Request.Form["userID"].ToString())))
            {
                userID = context.Request.Form["userID"].ToString();
            }

            if (context.Request.Form.ToString().Contains("password") && (!string.IsNullOrEmpty(context.Request.Form["password"].ToString())))
            {
                password = context.Request.Form["password"].ToString();
            }

            User user = new User();
            user.UserID = userID;
            user.Password = password;
            
            ExtJSResponse extResp = new ExtJSResponse();
            extResp = controller.Login(user);

            string response = extResp.GetResponse(extResp, extResp.Total);

            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(response);
        }

        //public object LogOut()
        //{
        //    LoginController controller = new LoginController();
        //   // User user = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(loginUser, typeof(User));

        //    ExtJSResponse extResp = new ExtJSResponse();
        //    extResp = controller.Logout();

        //    string response = extResp.GetResponse(extResp.Obj, extResp.Total);
        //    SetResponseContentType(ResponseContentTypes.JSON);
        //    return response;
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