using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using MicrofinanceBusinessSuite.Controllers.Inventory.Transaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for MemoApprovalHandler
    /// </summary>
    public class MemoApprovalHandler : BaseHandler
    {
        private static MemoApprovalController controller = new MemoApprovalController();


        public object SaveMemoApproval(string memoApproval)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoApproval obj = (new JavaScriptSerializer().Deserialize(memoApproval, typeof(MemoApproval))) as MemoApproval;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoApproval(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoApproval(string memoApproval)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoApproval search = (new JavaScriptSerializer().Deserialize(memoApproval, typeof(MemoApproval))) as MemoApproval;
            OutMessage oMsg = (OutMessage)controller.SearchMemoApproval(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}