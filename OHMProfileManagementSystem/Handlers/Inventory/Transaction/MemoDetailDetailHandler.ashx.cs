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
    /// Summary description for MemoDetailDetailHandler
    /// </summary>
    public class MemoDetailDetailHandler : BaseHandler
    {
        private static MemoDetailDetailController controller = new MemoDetailDetailController();


        public object SaveMemoDetailDetail(string memoDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoDetailDetail obj = (new JavaScriptSerializer().Deserialize(memoDetailDetail, typeof(MemoDetailDetail))) as MemoDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoDetailDetail(string memoDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoDetailDetail search = (new JavaScriptSerializer().Deserialize(memoDetailDetail, typeof(MemoDetailDetail))) as MemoDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchMemoDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoDtlDetail(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoDtlDetail(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}