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
    /// Summary description for PublicReferenceAccountHandler
    /// </summary>
    public class PublicReferenceAccountHandler : BaseHandler
    {
        private static PublicReferenceAccountController controller = new PublicReferenceAccountController();


        public object SavePublicReferenceAccount(string publicReferenceAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicReferenceAccount obj = (new JavaScriptSerializer().Deserialize(publicReferenceAccount, typeof(PublicReferenceAccount))) as PublicReferenceAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicReferenceAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicReferenceAccount(string publicReferenceAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicReferenceAccount search = (new JavaScriptSerializer().Deserialize(publicReferenceAccount, typeof(PublicReferenceAccount))) as PublicReferenceAccount;
            OutMessage oMsg = (OutMessage)controller.SearchPublicReferenceAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubRefAcc(string OfficeCode, string ClientNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubRefAcc(OfficeCode, ClientNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}