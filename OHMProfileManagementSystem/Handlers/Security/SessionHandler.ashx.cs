using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegratedTaxSystem.Controllers;
using IntegratedTaxSystem.Controllers.Security;
 
using System.Web.SessionState;
using App.Utilities.Web.Handlers;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Security;

namespace MicrofinanceBusinessSuite.Handlers.Security
{
    /// <summary>
    /// Summary description for SessionHandler
    /// </summary>
    public class SessionHandler : BaseHandler
    {

        public object ValidateSession()
        {
            ExtJSResponse resp = new ExtJSResponse();

            string response = resp.GetResponse(null, 0);

            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }

        public object ClearSession()
        {
            LoginController controller = new LoginController();

            ExtJSResponse extResp = new ExtJSResponse();
            extResp = controller.Logout();

            string response = extResp.GetResponse(extResp.Obj, extResp.Total);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }

        //below methods are added by info developer
        public string getToken()
        {
            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            SessionController controller1 = new SessionController();
            User user = controller1.GetSessionUser();
            string sessionvalue = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            string token = Guid.NewGuid().ToString();

            MicrofinanceBusinessSuite.InfoDev.DataAccess.SessionManager controller = new MicrofinanceBusinessSuite.InfoDev.DataAccess.SessionManager();

            ExtJSResponse extResp = new ExtJSResponse();
            string response = "";
            SetResponseContentType(ResponseContentTypes.JSON);
            try
            {
                string Response = controller.SaveSession(token, sessionvalue, ip);
                if (Response == "true")
                {

                    extResp.Success = "true";
                    extResp.Obj = token;
                    response = extResp.GetResponse(token, 1);

                }
                else
                {

                    extResp.Message = extResp.convertMessage(Response);
                    extResp.Success = "false";
                    response = extResp.GetResponse("", 0);

                }
            }
            catch (Exception ex)
            {
                extResp.Message = extResp.convertMessage(ex.Message);
                extResp.Success = "false";
                response = extResp.GetResponse("", 0);
            }

            HttpContext.Current.Session.Abandon();

            return response;

        }



        public void LoginByToken()
        {
            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            System.Web.HttpRequest Request = HttpContext.Current.Request;
            MicrofinanceBusinessSuite.InfoDev.DataAccess.SessionManager s_manager = new MicrofinanceBusinessSuite.InfoDev.DataAccess.SessionManager();

            string token = Request["token"].ToString();
            string module = Request["module"].ToString();
            User sessionvalue;
            ExtJSResponse extResp = new ExtJSResponse();
            LoginController controller = new LoginController();

            if (System.Web.HttpContext.Current.Session["User"] != null && HttpContext.Current.Session["LoginToken"] != null)
            {
                if (HttpContext.Current.Session["LoginToken"].ToString() == token)
                {
                    if (System.Web.HttpContext.Current.Session["User"].GetType() == typeof(User))
                    {
                        sessionvalue = System.Web.HttpContext.Current.Session["User"] as User;

                    }
                    else
                    {
                        string output = s_manager.GetSession(token, ip);
                        sessionvalue = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(output, typeof(User));
                        HttpContext.Current.Session.Add("LoginToken", token);
                    }
                }
                else
                {
                    string output = s_manager.GetSession(token, ip);
                    sessionvalue = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(output, typeof(User));
                    HttpContext.Current.Session.Add("LoginToken", token);
                }

            }
            else
            {
                string output = s_manager.GetSession(token, ip);
                sessionvalue = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(output, typeof(User));
                HttpContext.Current.Session.Add("LoginToken", token);
            }

            extResp.MenuObj = controller.GetMenuData((sessionvalue as User).Menus);
            extResp.Obj = null;
            extResp.Total = 0;
            sessionvalue.LoggedIn = true;
            HttpContext.Current.Session["User"] = sessionvalue;

            extResp.Success = "true";
            extResp.Obj = sessionvalue as GenericUser;

            extResp.Total = 1;
            extResp.Message = "User Login Succcessful.";


            ((MenuData)extResp.MenuObj).expanded = true;
            foreach (Node menu in ((MenuData)extResp.MenuObj).children)
            {

                if (menu.appId == module)
                {
                    menu.expanded = true;

                }
            }


            string response = extResp.GetResponse(extResp, extResp.Total);

            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(response);

        }
    }
}