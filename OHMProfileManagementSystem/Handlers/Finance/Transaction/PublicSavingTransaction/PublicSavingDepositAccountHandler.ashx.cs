using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.PublicSavingTransaction
{
    /// <summary>
    /// Summary description for PublicSavingDepositAccountHandler
    /// </summary>
    public class PublicSavingDepositAccountHandler : BaseHandler
    {
        private static PublicSavingDepositAccountController controller = new PublicSavingDepositAccountController();


        public object SavePublicSavingDepositAccount(string publicSavingDepositAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingDepositAccount obj = (new JavaScriptSerializer().Deserialize(publicSavingDepositAccount, typeof(PublicSavingDepositAccount))) as PublicSavingDepositAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingDepositAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingDepositAccount(string publicSavingDepositAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingDepositAccount search = (new JavaScriptSerializer().Deserialize(publicSavingDepositAccount, typeof(PublicSavingDepositAccount))) as PublicSavingDepositAccount;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingDepositAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavingDepoAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavingDepoAcc(OfficeCode, ProductCode, SavingAccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}