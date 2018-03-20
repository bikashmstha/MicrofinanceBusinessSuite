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
    /// Summary description for PublicAdjustmentdepositaccountHandler
    /// </summary>
    public class PublicAdjustmentdepositaccountHandler : BaseHandler
    {
        private static PublicAdjustmentdepositaccountController controller = new PublicAdjustmentdepositaccountController();


        public object SavePublicAdjustmentdepositaccount(string publicAdjustmentDepositAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAdjustmentdepositaccount obj = (new JavaScriptSerializer().Deserialize(publicAdjustmentDepositAccount, typeof(PublicAdjustmentdepositaccount))) as PublicAdjustmentdepositaccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAdjustmentdepositaccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAdjustmentdepositaccount(string publicAdjustmentDepositAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAdjustmentdepositaccount search = (new JavaScriptSerializer().Deserialize(publicAdjustmentDepositAccount, typeof(PublicAdjustmentdepositaccount))) as PublicAdjustmentdepositaccount;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAdjustmentdepositaccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAdjDepoAcc(string OfficeCode, string AccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAdjDepoAcc(OfficeCode, AccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}