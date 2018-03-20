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
    /// Summary description for PublicSavingDepositHandler
    /// </summary>
    public class PublicSavingDepositHandler : BaseHandler
    {
        private static PublicSavingDepositController controller = new PublicSavingDepositController();


        public object SavePublicSavingDeposit(string publicSavingDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingDeposit obj = (new JavaScriptSerializer().Deserialize(publicSavingDeposit, typeof(PublicSavingDeposit))) as PublicSavingDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingDeposit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingDeposit(string publicSavingDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingDeposit search = (new JavaScriptSerializer().Deserialize(publicSavingDeposit, typeof(PublicSavingDeposit))) as PublicSavingDeposit;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingDeposit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }


    }
}