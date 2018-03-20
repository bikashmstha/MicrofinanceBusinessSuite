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
    /// Summary description for PublicWithdrawWithAccountHandler
    /// </summary>
    public class PublicWithdrawWithAccountHandler : BaseHandler
    {
        private static PublicWithdrawWithAccountController controller = new PublicWithdrawWithAccountController();


        public object SavePublicWithdrawWithAccount(string publicWithdrawWithAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicWithdrawWithAccount obj = (new JavaScriptSerializer().Deserialize(publicWithdrawWithAccount, typeof(PublicWithdrawWithAccount))) as PublicWithdrawWithAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicWithdrawWithAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicWithdrawWithAccount(string publicWithdrawWithAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicWithdrawWithAccount search = (new JavaScriptSerializer().Deserialize(publicWithdrawWithAccount, typeof(PublicWithdrawWithAccount))) as PublicWithdrawWithAccount;
            OutMessage oMsg = (OutMessage)controller.SearchPublicWithdrawWithAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubWithAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubWithAcc(OfficeCode, ProductCode, SavingAccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}