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
    /// Summary description for LiveStockDepositPostingHandler
    /// </summary>
    public class LiveStockDepositPostingHandler : BaseHandler
    {
        private static LiveStockDepositPostingController controller = new LiveStockDepositPostingController();


        public object SaveLiveStockDepositPosting(string liveStockDepositPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<LiveStockDepositPosting> obj = (new JavaScriptSerializer().Deserialize(liveStockDepositPosting, typeof(List<LiveStockDepositPosting>))) as List<LiveStockDepositPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveLiveStockDepositPosting(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLiveStockDepositPosting(string liveStockDepositPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LiveStockDepositPosting search = (new JavaScriptSerializer().Deserialize(liveStockDepositPosting, typeof(LiveStockDepositPosting))) as LiveStockDepositPosting;
            OutMessage oMsg = (OutMessage)controller.SearchLiveStockDepositPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}