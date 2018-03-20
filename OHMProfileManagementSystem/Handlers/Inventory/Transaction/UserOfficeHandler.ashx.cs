using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using MicrofinanceBusinessSuite.Controllers.Inventory.Transaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for UserOfficeHandler
    /// </summary>
    public class UserOfficeHandler : BaseHandler
    {
        private static UserOfficeController controller = new UserOfficeController();


        public object SaveUserOffice(string userOffice)
        {
            ExtJSResponse resp = new ExtJSResponse();
            UserOffice obj = (new JavaScriptSerializer().Deserialize(userOffice, typeof(UserOffice))) as UserOffice;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveUserOffice(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchUserOffice(string userOffice)
        {
            ExtJSResponse resp = new ExtJSResponse();
            UserOffice search = (new JavaScriptSerializer().Deserialize(userOffice, typeof(UserOffice))) as UserOffice;
            OutMessage oMsg = (OutMessage)controller.SearchUserOffice(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetUserOffice(string UserCode, string OfficeName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetUserOffice(UserCode, OfficeName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}