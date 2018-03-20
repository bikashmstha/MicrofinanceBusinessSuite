using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for ContraBankAccountHandler
    /// </summary>
    public class ContraBankAccountHandler : BaseHandler
    {
        private static ContraBankAccountController controller = new ContraBankAccountController();


        public object SaveContraBankAccount(string contraBankAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ContraBankAccount obj = (new JavaScriptSerializer().Deserialize(contraBankAccount, typeof(ContraBankAccount))) as ContraBankAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveContraBankAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchContraBankAccount(string contraBankAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ContraBankAccount search = (new JavaScriptSerializer().Deserialize(contraBankAccount, typeof(ContraBankAccount))) as ContraBankAccount;
            OutMessage oMsg = (OutMessage)controller.SearchContraBankAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetContraBnkAcc(string AccountDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetContraBnkAcc(AccountDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}