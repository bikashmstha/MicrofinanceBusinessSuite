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
    /// Summary description for AccountCloseDetailHandler
    /// </summary>
    public class AccountCloseDetailHandler : BaseHandler
    {
        private static AccountCloseDetailController controller = new AccountCloseDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string accountCloseDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountCloseDetail obj = (new JavaScriptSerializer().Deserialize(accountCloseDetail, typeof(AccountCloseDetail))) as AccountCloseDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string accountCloseDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountCloseDetail search = (new JavaScriptSerializer().Deserialize(accountCloseDetail, typeof(AccountCloseDetail))) as AccountCloseDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAccountCloseDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAccountCloseDetail(withdrawlNo, offCode, savingAccountNo, clientName, fromDate, toDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}