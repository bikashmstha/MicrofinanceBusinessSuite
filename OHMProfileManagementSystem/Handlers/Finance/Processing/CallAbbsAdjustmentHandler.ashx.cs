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
    /// Summary description for CallAbbsAdjustmentHandler
    /// </summary>
    public class CallAbbsAdjustmentHandler : BaseHandler
    {
        private static CallAbbsAdjustmentController controller = new CallAbbsAdjustmentController();


        public object SaveCallAbbsAdjustment(string callAbbsAdjustment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CallAbbsAdjustment obj = (new JavaScriptSerializer().Deserialize(callAbbsAdjustment, typeof(CallAbbsAdjustment))) as CallAbbsAdjustment;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveCallAbbsAdjustment(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchCallAbbsAdjustment(string callAbbsAdjustment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CallAbbsAdjustment search = (new JavaScriptSerializer().Deserialize(callAbbsAdjustment, typeof(CallAbbsAdjustment))) as CallAbbsAdjustment;
            OutMessage oMsg = (OutMessage)controller.SearchCallAbbsAdjustment(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}