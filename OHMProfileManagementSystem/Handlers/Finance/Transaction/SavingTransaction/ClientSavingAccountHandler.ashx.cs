using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.SavingTransaction
{
    /// <summary>
    /// Summary description for ClientSavingAccountHandler
    /// </summary>
    public class ClientSavingAccountHandler : BaseHandler
    {
        private static ClientSavingAccountController controller = new ClientSavingAccountController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string clientSavingAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ClientSavingAccount obj = (new JavaScriptSerializer().Deserialize(clientSavingAccount, typeof(ClientSavingAccount))) as ClientSavingAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string clientSavingAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ClientSavingAccount search = (new JavaScriptSerializer().Deserialize(clientSavingAccount, typeof(ClientSavingAccount))) as ClientSavingAccount;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemberAccountOpen(string offCode, string memberName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemberAccountOpen(offCode, memberName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemberAccountForCheque(string offCode, string clientNo)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemberAccountForCheque(offCode, clientNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}