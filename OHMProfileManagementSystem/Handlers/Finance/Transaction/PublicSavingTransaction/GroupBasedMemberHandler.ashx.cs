using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.PublicSavingTransaction
{
    /// <summary>
    /// Summary description for GroupBasedMemberHandler
    /// </summary>
    public class GroupBasedMemberHandler : BaseHandler
    {
        private static GroupBasedMemberController controller = new GroupBasedMemberController();


        public object SaveGroupBasedMember(string groupBasedMember)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GroupBasedMember obj = (new JavaScriptSerializer().Deserialize(groupBasedMember, typeof(GroupBasedMember))) as GroupBasedMember;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGroupBasedMember(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGroupBasedMember(string groupBasedMember)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GroupBasedMember search = (new JavaScriptSerializer().Deserialize(groupBasedMember, typeof(GroupBasedMember))) as GroupBasedMember;
            OutMessage oMsg = (OutMessage)controller.SearchGroupBasedMember(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGroupBasedMem(string OfficeCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGroupBasedMem(OfficeCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}