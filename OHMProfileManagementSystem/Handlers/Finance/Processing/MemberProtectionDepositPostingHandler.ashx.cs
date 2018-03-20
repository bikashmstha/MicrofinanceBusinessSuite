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
    /// Summary description for MemberProtectionDepositPostingHandler
    /// </summary>
    public class MemberProtectionDepositPostingHandler : BaseHandler
    {
        private static MemberProtectionDepositPostingController controller = new MemberProtectionDepositPostingController();


        public object SaveMemberProtectionDepositPosting(string memberProtectionDepositPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<MemberProtectionDepositPosting> obj = (new JavaScriptSerializer().Deserialize(memberProtectionDepositPosting, typeof(List<MemberProtectionDepositPosting>))) as List<MemberProtectionDepositPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveMemberProtectionDepositPosting(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemberProtectionDepositPosting(string memberProtectionDepositPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberProtectionDepositPosting search = (new JavaScriptSerializer().Deserialize(memberProtectionDepositPosting, typeof(MemberProtectionDepositPosting))) as MemberProtectionDepositPosting;
            OutMessage oMsg = (OutMessage)controller.SearchMemberProtectionDepositPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}