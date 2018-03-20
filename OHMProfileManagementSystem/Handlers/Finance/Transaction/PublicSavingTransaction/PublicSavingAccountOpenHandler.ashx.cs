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
    /// Summary description for PublicSavingAccountOpenHandler
    /// </summary>
    public class PublicSavingAccountOpenHandler : BaseHandler
    {
        private static PublicSavingAccountOpenController controller = new PublicSavingAccountOpenController();


        public object SavePublicSavingAccountOpen(string publicSavingAccountOpen)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingAccountOpen obj = (new JavaScriptSerializer().Deserialize(publicSavingAccountOpen, typeof(PublicSavingAccountOpen))) as PublicSavingAccountOpen;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingAccountOpen(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingAccountOpen(string publicSavingAccountOpen)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingAccountOpen search = (new JavaScriptSerializer().Deserialize(publicSavingAccountOpen, typeof(PublicSavingAccountOpen))) as PublicSavingAccountOpen;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingAccountOpen(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }


    }
}