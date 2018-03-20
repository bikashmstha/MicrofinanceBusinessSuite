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
    /// Summary description for MemberProtectBenefitPostingHandler
    /// </summary>
    public class MemberProtectBenefitPostingHandler : BaseHandler
    {
        private static MemberProtectBenefitPostingController controller = new MemberProtectBenefitPostingController();


        public object SaveMemberProtectBenefitPosting(string memberProtectBenefitPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<MemberProtectBenefitPosting> obj = (new JavaScriptSerializer().Deserialize(memberProtectBenefitPosting, typeof(List<MemberProtectBenefitPosting>))) as List<MemberProtectBenefitPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveMemberProtectBenefitPosting(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemberProtectBenefitPosting(string memberProtectBenefitPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberProtectBenefitPosting search = (new JavaScriptSerializer().Deserialize(memberProtectBenefitPosting, typeof(MemberProtectBenefitPosting))) as MemberProtectBenefitPosting;
            OutMessage oMsg = (OutMessage)controller.SearchMemberProtectBenefitPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}