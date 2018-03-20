using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.MemberTransaction
{
    /// <summary>
    /// Summary description for MemberCancellationRestoreHandler
    /// </summary>
    public class MemberCancellationRestoreHandler : BaseHandler
    {
        private static MemberCancellationRestoreController controller = new MemberCancellationRestoreController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string membercancellationrestore)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberCancellationRestore obj = (new JavaScriptSerializer().Deserialize(membercancellationrestore, typeof(MemberCancellationRestore))) as MemberCancellationRestore;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string membercancellationrestore)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemberCancellationRestore search = (new JavaScriptSerializer().Deserialize(membercancellationrestore, typeof(MemberCancellationRestore))) as MemberCancellationRestore;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}