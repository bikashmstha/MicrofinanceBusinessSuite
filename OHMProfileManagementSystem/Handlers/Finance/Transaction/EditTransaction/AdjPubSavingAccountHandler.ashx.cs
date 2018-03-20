using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.EditTransaction
{
    /// <summary>
    /// Summary description for AdjPubSavingAccountHandler
    /// </summary>
    public class AdjPubSavingAccountHandler : BaseHandler
    {
        private static AdjPubSavingAccountController controller = new AdjPubSavingAccountController();


        public object SaveAdjPubSavingAccount(string adjPubSavingAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AdjPubSavingAccount obj = (new JavaScriptSerializer().Deserialize(adjPubSavingAccount, typeof(AdjPubSavingAccount))) as AdjPubSavingAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAdjPubSavingAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAdjPubSavingAccount(string adjPubSavingAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AdjPubSavingAccount search = (new JavaScriptSerializer().Deserialize(adjPubSavingAccount, typeof(AdjPubSavingAccount))) as AdjPubSavingAccount;
            OutMessage oMsg = (OutMessage)controller.SearchAdjPubSavingAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAdjPubSavingAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAdjPubSavingAcc(OfficeCode, ProductCode, SavingAccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}