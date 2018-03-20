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
    /// Summary description for PublicAccountChequeHandler
    /// </summary>
    public class PublicAccountChequeHandler : BaseHandler
    {
        private static PublicAccountChequeController controller = new PublicAccountChequeController();


        public object SavePublicAccountCheque(string publicAccountCheque)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCheque obj = (new JavaScriptSerializer().Deserialize(publicAccountCheque, typeof(PublicAccountCheque))) as PublicAccountCheque;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAccountCheque(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAccountCheque(string publicAccountCheque)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCheque search = (new JavaScriptSerializer().Deserialize(publicAccountCheque, typeof(PublicAccountCheque))) as PublicAccountCheque;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAccountCheque(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAccCheque(string AccountNo, string ChequeNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAccCheque(AccountNo, ChequeNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}