using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using MicrofinanceBusinessSuite.Controllers.Finance.Processing;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Processing
{
    /// <summary>
    /// Summary description for PublicSavingWithdrawlHandler
    /// </summary>
    public class PublicSavingWithdrawlHandler : BaseHandler
    {
        private static PublicSavingWithdrawlController controller = new PublicSavingWithdrawlController();


        public object SavePublicSavingWithdrawl(string publicSavingWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawl obj = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawl, typeof(PublicSavingWithdrawl))) as PublicSavingWithdrawl;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingWithdrawl(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingWithdrawl(string publicSavingWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawl search = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawl, typeof(PublicSavingWithdrawl))) as PublicSavingWithdrawl;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingWithdrawl(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavingWithdrawal(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavingWithdrawal(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}