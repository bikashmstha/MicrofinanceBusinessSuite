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
    /// Summary description for PublicAccountChequeAccountHandler
    /// </summary>
    public class PublicAccountChequeAccountHandler : BaseHandler
    {
        private static PublicAccountChequeAccountController controller = new PublicAccountChequeAccountController();


        public object SavePublicAccountChequeAccount(string publicAccountChequeAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountChequeAccount obj = (new JavaScriptSerializer().Deserialize(publicAccountChequeAccount, typeof(PublicAccountChequeAccount))) as PublicAccountChequeAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAccountChequeAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAccountChequeAccount(string publicAccountChequeAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountChequeAccount search = (new JavaScriptSerializer().Deserialize(publicAccountChequeAccount, typeof(PublicAccountChequeAccount))) as PublicAccountChequeAccount;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAccountChequeAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAccCheqAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAccCheqAcc(OfficeCode, ProductCode, SavingAccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}