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
    /// Summary description for MemoApprovalDetailHandler
    /// </summary>
    public class MemoApprovalDetailHandler : BaseHandler
    {
        private static MemoApprovalDetailController controller = new MemoApprovalDetailController();


        public object SaveMemoApprovalDetail(string memoApprovalDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoApprovalDetail obj = (new JavaScriptSerializer().Deserialize(memoApprovalDetail, typeof(MemoApprovalDetail))) as MemoApprovalDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoApprovalDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoApprovalDetail(string memoApprovalDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoApprovalDetail search = (new JavaScriptSerializer().Deserialize(memoApprovalDetail, typeof(MemoApprovalDetail))) as MemoApprovalDetail;
            OutMessage oMsg = (OutMessage)controller.SearchMemoApprovalDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoApprovalDtlDetail(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoApprovalDtlDetail(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        
    }
}