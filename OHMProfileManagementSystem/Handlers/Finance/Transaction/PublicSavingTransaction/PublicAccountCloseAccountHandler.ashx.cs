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
    /// Summary description for PublicAccountCloseAccountHandler
    /// </summary>
    public class PublicAccountCloseAccountHandler : BaseHandler
    {
        private static PublicAccountCloseAccountController controller = new PublicAccountCloseAccountController();


        public object SavePublicAccountCloseAccount(string publicAccountCloseAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCloseAccount obj = (new JavaScriptSerializer().Deserialize(publicAccountCloseAccount, typeof(PublicAccountCloseAccount))) as PublicAccountCloseAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAccountCloseAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAccountCloseAccount(string publicAccountCloseAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCloseAccount search = (new JavaScriptSerializer().Deserialize(publicAccountCloseAccount, typeof(PublicAccountCloseAccount))) as PublicAccountCloseAccount;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAccountCloseAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAccCloseAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAccCloseAcc(OfficeCode, ProductCode, SavingAccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}