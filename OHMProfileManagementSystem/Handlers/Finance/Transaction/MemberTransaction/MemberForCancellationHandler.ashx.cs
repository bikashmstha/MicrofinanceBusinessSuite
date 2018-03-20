using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Transaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.MemberTransaction
{
    /// <summary>
    /// Summary description for MemberForCancellationHandler
    /// </summary>
    public class MemberForCancellationHandler : BaseHandler
    {
        private static MemberForCancellationController controller = new MemberForCancellationController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string memberforcancellation)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberForCancellation obj = (new JavaScriptSerializer().Deserialize(memberforcancellation, typeof(MemberForCancellation))) as MemberForCancellation;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string memberforcancellation)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberForCancellation search = (new JavaScriptSerializer().Deserialize(memberforcancellation, typeof(MemberForCancellation))) as MemberForCancellation;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetMemberForCancelList(string offCode, string centerCode, string memberName, string clientNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemberForCancelList(offCode, centerCode, memberName, clientNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}