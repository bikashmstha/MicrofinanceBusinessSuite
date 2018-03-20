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
    /// Summary description for MemberProtectionBenefitHandler
    /// </summary>
    public class MemberProtectionBenefitHandler : BaseHandler
    {
        private static MemberProtectionBenefitController controller = new MemberProtectionBenefitController();


        public object SaveMemberProtectionBenefit(string memberProtectionBenefit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberProtectionBenefit obj = (new JavaScriptSerializer().Deserialize(memberProtectionBenefit, typeof(MemberProtectionBenefit))) as MemberProtectionBenefit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemberProtectionBenefit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemberProtectionBenefit(string memberProtectionBenefit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberProtectionBenefit search = (new JavaScriptSerializer().Deserialize(memberProtectionBenefit, typeof(MemberProtectionBenefit))) as MemberProtectionBenefit;
            OutMessage oMsg = (OutMessage)controller.SearchMemberProtectionBenefit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemProtectBenifit(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemProtectBenifit(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}