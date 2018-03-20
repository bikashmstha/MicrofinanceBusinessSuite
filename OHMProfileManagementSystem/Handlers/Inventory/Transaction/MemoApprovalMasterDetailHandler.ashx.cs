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
    /// Summary description for MemoApprovalMasterDetailHandler
    /// </summary>
    public class MemoApprovalMasterDetailHandler : BaseHandler
    {
        private static MemoApprovalMasterDetailController controller = new MemoApprovalMasterDetailController();


        public object SaveMemoApprovalMasterDetail(string memoApprovalMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoApprovalMasterDetail obj = (new JavaScriptSerializer().Deserialize(memoApprovalMasterDetail, typeof(MemoApprovalMasterDetail))) as MemoApprovalMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoApprovalMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoApprovalMasterDetail(string memoApprovalMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoApprovalMasterDetail search = (new JavaScriptSerializer().Deserialize(memoApprovalMasterDetail, typeof(MemoApprovalMasterDetail))) as MemoApprovalMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchMemoApprovalMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoApprovalMstDetail(string OfficeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoApprovalMstDetail(OfficeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}