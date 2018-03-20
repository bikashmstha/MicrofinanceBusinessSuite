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
    /// Summary description for AccountForDepositHandler
    /// </summary>
    public class AccountForDepositHandler : BaseHandler
    {
        private static AccountForDepositController controller = new AccountForDepositController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string accountForDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountForDeposit obj = (new JavaScriptSerializer().Deserialize(accountForDeposit, typeof(AccountForDeposit))) as AccountForDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string accountForDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountForDeposit search = (new JavaScriptSerializer().Deserialize(accountForDeposit, typeof(AccountForDeposit))) as AccountForDeposit;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAccountForDeposit(string offCode, string productCode, string savingAccountNo, string centerCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAccountForDeposit(offCode, productCode, savingAccountNo, centerCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}