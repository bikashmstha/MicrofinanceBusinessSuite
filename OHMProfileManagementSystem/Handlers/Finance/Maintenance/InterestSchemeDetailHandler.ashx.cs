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
    /// Summary description for InterestSchemeDetailHandler
    /// </summary>
    public class InterestSchemeDetailHandler : BaseHandler
    {
        private static InterestSchemeDetailController controller = new InterestSchemeDetailController();


        public object SaveInterestSchemeDetail(string interestSchemeDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InterestSchemeDetail obj = (new JavaScriptSerializer().Deserialize(interestSchemeDetail, typeof(InterestSchemeDetail))) as InterestSchemeDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveInterestSchemeDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchInterestSchemeDetail(string interestSchemeDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InterestSchemeDetail search = (new JavaScriptSerializer().Deserialize(interestSchemeDetail, typeof(InterestSchemeDetail))) as InterestSchemeDetail;
            OutMessage oMsg = (OutMessage)controller.SearchInterestSchemeDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetIntSchemeDtl(string IntSchemeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetIntSchemeDtl(IntSchemeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}