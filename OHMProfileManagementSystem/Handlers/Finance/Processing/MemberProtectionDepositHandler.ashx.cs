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
    /// Summary description for MemberProtectionDepositHandler
    /// </summary>
    public class MemberProtectionDepositHandler : BaseHandler
    {
        private static MemberProtectionDepositController controller = new MemberProtectionDepositController();


        public object SaveMemberProtectionDeposit(string memberProtectionDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberProtectionDeposit obj = (new JavaScriptSerializer().Deserialize(memberProtectionDeposit, typeof(MemberProtectionDeposit))) as MemberProtectionDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemberProtectionDeposit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemberProtectionDeposit(string memberProtectionDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberProtectionDeposit search = (new JavaScriptSerializer().Deserialize(memberProtectionDeposit, typeof(MemberProtectionDeposit))) as MemberProtectionDeposit;
            OutMessage oMsg = (OutMessage)controller.SearchMemberProtectionDeposit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemProtectDeposit(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemProtectDeposit(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}