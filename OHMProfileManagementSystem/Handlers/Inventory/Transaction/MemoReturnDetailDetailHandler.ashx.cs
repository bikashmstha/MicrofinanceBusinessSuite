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
    /// Summary description for MemoReturnDetailDetailHandler
    /// </summary>
    public class MemoReturnDetailDetailHandler : BaseHandler
    {
        private static MemoReturnDetailDetailController controller = new MemoReturnDetailDetailController();


        public object SaveMemoReturnDetailDetail(string memoReturnDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoReturnDetailDetail obj = (new JavaScriptSerializer().Deserialize(memoReturnDetailDetail, typeof(MemoReturnDetailDetail))) as MemoReturnDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoReturnDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoReturnDetailDetail(string memoReturnDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoReturnDetailDetail search = (new JavaScriptSerializer().Deserialize(memoReturnDetailDetail, typeof(MemoReturnDetailDetail))) as MemoReturnDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchMemoReturnDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoReturnDetailDtl(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoReturnDetailDtl(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}