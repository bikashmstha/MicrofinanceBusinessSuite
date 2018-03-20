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
    /// Summary description for PublicChequeNoHandler
    /// </summary>
    public class PublicChequeNoHandler : BaseHandler
    {
        private static PublicChequeNoController controller = new PublicChequeNoController();


        public object SavePublicChequeNo(string publicChequeNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicChequeNo obj = (new JavaScriptSerializer().Deserialize(publicChequeNo, typeof(PublicChequeNo))) as PublicChequeNo;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicChequeNo(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicChequeNo(string publicChequeNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicChequeNo search = (new JavaScriptSerializer().Deserialize(publicChequeNo, typeof(PublicChequeNo))) as PublicChequeNo;
            OutMessage oMsg = (OutMessage)controller.SearchPublicChequeNo(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubChequeNo(string OfficeCode, string AccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubChequeNo(OfficeCode, AccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}