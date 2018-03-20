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
    /// Summary description for InterestSchemeMasterHandler
    /// </summary>
    public class InterestSchemeMasterHandler : BaseHandler
    {
        private static InterestSchemeMasterController controller = new InterestSchemeMasterController();


        public object SaveInterestSchemeMaster(string interestSchemeMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InterestSchemeMaster obj = (new JavaScriptSerializer().Deserialize(interestSchemeMaster, typeof(InterestSchemeMaster))) as InterestSchemeMaster;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveInterestSchemeMaster(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchInterestSchemeMaster(string interestSchemeMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InterestSchemeMaster search = (new JavaScriptSerializer().Deserialize(interestSchemeMaster, typeof(InterestSchemeMaster))) as InterestSchemeMaster;
            OutMessage oMsg = (OutMessage)controller.SearchInterestSchemeMaster(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetIntSchemeMasterList(string IntSchemeCode, string IntSchemeDesc, string SchemeFor)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetIntSchemeMasterList(IntSchemeCode, IntSchemeDesc, SchemeFor);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}