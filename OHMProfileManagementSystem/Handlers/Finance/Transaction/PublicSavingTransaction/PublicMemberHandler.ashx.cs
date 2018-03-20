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
    /// Summary description for PublicMemberHandler
    /// </summary>
    public class PublicMemberHandler : BaseHandler
    {
        private static PublicMemberController controller = new PublicMemberController();


        public object SavePublicMember(string publicMember)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicMember obj = (new JavaScriptSerializer().Deserialize(publicMember, typeof(PublicMember))) as PublicMember;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicMember(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicMember(string publicMember)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicMember search = (new JavaScriptSerializer().Deserialize(publicMember, typeof(PublicMember))) as PublicMember;
            OutMessage oMsg = (OutMessage)controller.SearchPublicMember(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}