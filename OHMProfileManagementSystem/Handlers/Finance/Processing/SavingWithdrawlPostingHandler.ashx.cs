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
    /// Summary description for SavingWithdrawlPostingHandler
    /// </summary>
    public class SavingWithdrawlPostingHandler : BaseHandler
    {
        private static SavingWithdrawlPostingController controller = new SavingWithdrawlPostingController();


        public object SaveSavingWithdrawlPosting(string savingWithdrawlPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<SavingWithdrawlPosting> lst = (new JavaScriptSerializer().Deserialize(savingWithdrawlPosting, typeof(List<SavingWithdrawlPosting>))) as List<SavingWithdrawlPosting>;
             OutMessage oMsg = (OutMessage)controller.SaveSavingWithdrawlPosting(lst);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingWithdrawlPosting(string savingWithdrawlPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingWithdrawlPosting search = (new JavaScriptSerializer().Deserialize(savingWithdrawlPosting, typeof(SavingWithdrawlPosting))) as SavingWithdrawlPosting;
            OutMessage oMsg = (OutMessage)controller.SearchSavingWithdrawlPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}