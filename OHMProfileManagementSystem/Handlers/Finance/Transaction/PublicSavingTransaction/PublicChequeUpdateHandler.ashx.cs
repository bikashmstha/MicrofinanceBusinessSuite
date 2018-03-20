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
    /// Summary description for PublicChequeUpdateHandler
    /// </summary>
    public class PublicChequeUpdateHandler : BaseHandler
    {
        private static PublicChequeUpdateController controller = new PublicChequeUpdateController();


        public object SavePublicChequeUpdate(string publicChequeUpdate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicChequeUpdate obj = (new JavaScriptSerializer().Deserialize(publicChequeUpdate, typeof(PublicChequeUpdate))) as PublicChequeUpdate;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicChequeUpdate(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicChequeUpdate(string publicChequeUpdate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicChequeUpdate search = (new JavaScriptSerializer().Deserialize(publicChequeUpdate, typeof(PublicChequeUpdate))) as PublicChequeUpdate;
            OutMessage oMsg = (OutMessage)controller.SearchPublicChequeUpdate(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubChequeUpdate()
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubChequeUpdate();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}