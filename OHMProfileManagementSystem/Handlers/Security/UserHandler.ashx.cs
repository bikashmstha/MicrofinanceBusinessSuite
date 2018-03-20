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
using MicrofinanceBusinessSuite.Controllers.Security;
using BusinessObjects;
using System.Web.Script.Serialization;


namespace MicrofinanceBusinessSuite.Handlers.Security
{
    /// <summary>
    /// Summary description for UserHandler
    /// </summary>
    public class UserHandler : BaseHandler
    {

        public HttpContext Context
        {
            get
            {

                return HttpContext.Current;
            }
        }



        private static UserController controller = new UserController();
        public object GetUserShort()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetUserShort();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object ResetPassword(string officeCode, string userCode, string newPwd, string cNewPwd, string changeByOfficeCode, string changeByUserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            //Religion obj = (new JavaScriptSerializer().Deserialize(religion, typeof(Religion))) as Religion;
            //obj.CreatedBy = GeneralHelper.UserId;
            //obj.CreatedOn = GeneralHelper.MisDateNepali;

            OutMessage oMsg = (OutMessage)controller.ResetUserPassword(officeCode, userCode, newPwd, cNewPwd, changeByOfficeCode, changeByUserCode);

            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }




        public object GetUserFromSession()
        {
            LoginController controller = new LoginController();
            ExtJSResponse extResp = new ExtJSResponse();
            ExtJSResponse extRespUser = controller.GetUserFromSession();

            string response = extResp.GetResponse(extRespUser, 1);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response; ;
        }


        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string user)
        {
            ExtJSResponse resp = new ExtJSResponse();
            User obj = (new JavaScriptSerializer().Deserialize(user, typeof(User))) as User;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string user)
        {
            ExtJSResponse resp = new ExtJSResponse();
            User search = (new JavaScriptSerializer().Deserialize(user, typeof(User))) as User;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }




    }
}