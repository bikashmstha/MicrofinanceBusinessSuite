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
    /// Summary description for LiveStockBenefitPostingHandler
    /// </summary>
    public class LiveStockBenefitPostingHandler : BaseHandler
    {
        private static LiveStockBenefitPostingController controller = new LiveStockBenefitPostingController();


        public object SaveLiveStockBenefitPosting(string liveStockBenefitPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<LiveStockBenefitPosting> obj = (new JavaScriptSerializer().Deserialize(liveStockBenefitPosting, typeof(List<LiveStockBenefitPosting>))) as List<LiveStockBenefitPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveLiveStockBenefitPosting(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLiveStockBenefitPosting(string liveStockBenefitPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LiveStockBenefitPosting search = (new JavaScriptSerializer().Deserialize(liveStockBenefitPosting, typeof(LiveStockBenefitPosting))) as LiveStockBenefitPosting;
            OutMessage oMsg = (OutMessage)controller.SearchLiveStockBenefitPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}