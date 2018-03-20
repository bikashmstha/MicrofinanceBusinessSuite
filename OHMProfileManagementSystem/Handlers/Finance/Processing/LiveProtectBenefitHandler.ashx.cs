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
    /// Summary description for LiveProtectBenefitHandler
    /// </summary>
    public class LiveProtectBenefitHandler : BaseHandler
    {
        private static LiveProtectBenefitController controller = new LiveProtectBenefitController();


        public object SaveLiveProtectBenefit(string LiveProtectBenefit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LiveProtectBenefit obj = (new JavaScriptSerializer().Deserialize(LiveProtectBenefit, typeof(LiveProtectBenefit))) as LiveProtectBenefit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLiveProtectBenefit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLiveProtectBenefit(string LiveProtectBenefit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LiveProtectBenefit search = (new JavaScriptSerializer().Deserialize(LiveProtectBenefit, typeof(LiveProtectBenefit))) as LiveProtectBenefit;
            OutMessage oMsg = (OutMessage)controller.SearchLiveProtectBenefit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLiveProtectBenifit(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLiveProtectBenifit(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}