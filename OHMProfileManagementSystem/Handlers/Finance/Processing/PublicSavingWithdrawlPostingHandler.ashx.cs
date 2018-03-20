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
    /// Summary description for PublicSavingWithdrawlPostingHandler
    /// </summary>
    public class PublicSavingWithdrawlPostingHandler : BaseHandler
    {
        private static PublicSavingWithdrawlPostingController controller = new PublicSavingWithdrawlPostingController();


        public object SavePublicSavingWithdrawlPosting(string publicSavingWithdrawlPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawlPosting obj = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawlPosting, typeof(PublicSavingWithdrawlPosting))) as PublicSavingWithdrawlPosting;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingWithdrawlPosting(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingWithdrawlPosting(string publicSavingWithdrawlPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawlPosting search = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawlPosting, typeof(PublicSavingWithdrawlPosting))) as PublicSavingWithdrawlPosting;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingWithdrawlPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}