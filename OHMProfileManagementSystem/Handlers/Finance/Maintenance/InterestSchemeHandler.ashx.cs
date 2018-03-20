using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for InterestSchemeHandler
    /// </summary>
    public class InterestSchemeHandler : BaseHandler
    {
        private static InterestSchemeController controller = new InterestSchemeController();


        public object SaveInterestScheme(string interestScheme)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InterestScheme obj = (new JavaScriptSerializer().Deserialize(interestScheme, typeof(InterestScheme))) as InterestScheme;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveInterestScheme(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchInterestScheme(string interestScheme)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InterestScheme search = (new JavaScriptSerializer().Deserialize(interestScheme, typeof(InterestScheme))) as InterestScheme;
            OutMessage oMsg = (OutMessage)controller.SearchInterestScheme(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetInterestScheme(string IntSchemeDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetInterestScheme(IntSchemeDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}