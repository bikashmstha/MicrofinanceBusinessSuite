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
    /// Summary description for AccountForWithdrawlHandler
    /// </summary>
    public class AccountForWithdrawlHandler : BaseHandler
    {
        private static AccountForWithdrawlController controller = new AccountForWithdrawlController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string accountForWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountForWithdrawl obj = (new JavaScriptSerializer().Deserialize(accountForWithdrawl, typeof(AccountForWithdrawl))) as AccountForWithdrawl;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string accountForWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountForWithdrawl search = (new JavaScriptSerializer().Deserialize(accountForWithdrawl, typeof(AccountForWithdrawl))) as AccountForWithdrawl;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAccountForWithdrawl(string offCode, string productCode, string savingAccountNo, string centerCode)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAccountForWithdrawl(offCode, productCode, savingAccountNo, centerCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}