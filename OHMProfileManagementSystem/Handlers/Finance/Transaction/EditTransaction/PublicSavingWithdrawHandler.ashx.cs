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
    /// Summary description for PublicSavingWithdrawHandler
    /// </summary>
    public class PublicSavingWithdrawHandler : BaseHandler
    {
        private static PublicSavingWithdrawController controller = new PublicSavingWithdrawController();


        public object SavePublicSavingWithdraw(string publicSavingWithdraw)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdraw obj = (new JavaScriptSerializer().Deserialize(publicSavingWithdraw, typeof(PublicSavingWithdraw))) as PublicSavingWithdraw;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingWithdraw(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingWithdraw(string publicSavingWithdraw)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdraw search = (new JavaScriptSerializer().Deserialize(publicSavingWithdraw, typeof(PublicSavingWithdraw))) as PublicSavingWithdraw;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingWithdraw(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }


    }
}