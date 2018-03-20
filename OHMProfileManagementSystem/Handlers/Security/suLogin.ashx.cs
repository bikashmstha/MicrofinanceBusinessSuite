using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using IntegratedTaxSystem.Controllers.Security;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Security;

namespace MicrofinanceBusinessSuite.Handlers.Security
{
    /// <summary>
    /// Summary description for tpLogin
    /// </summary>
    public class suLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string username = context.Request.Form["txtSYSName"].ToString();
            string password = context.Request.Form["txtSYSPassword"].ToString();
            // string submissionNo = context.Request.Form["txtTpSubmissionNo"].ToString();
            LogInOutController objLogin = new LogInOutController();
            User user = new User();



            user.UserID = username;
            user.Password = password;
            user = objLogin.Login(user) as User;
            bool success = user.LoggedIn;

            if (success)
            {
                // objLogin.
                System.Web.HttpContext.Current.Session["User"] = user;

            }
            ExtJSResponse resp = new ExtJSResponse();
            resp.Success = success.ToString();
            resp.Message = success ? "User Login Succcessful" : "User Login Failed";

            string response = resp.GetResponse(success ? user.Menus : null, success ? user.Menus.Count : 0);
            context.Response.Write(response);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}