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
    /// Summary description for GoodReceiptDetailDetailHandler
    /// </summary>
    public class GoodReceiptDetailDetailHandler : BaseHandler
    {
        private static GoodReceiptDetailDetailController controller = new GoodReceiptDetailDetailController();


        public object SaveGoodReceiptDetailDetail(string goodReceiptDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptDetailDetail obj = (new JavaScriptSerializer().Deserialize(goodReceiptDetailDetail, typeof(GoodReceiptDetailDetail))) as GoodReceiptDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptDetailDetail(string goodReceiptDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptDetailDetail search = (new JavaScriptSerializer().Deserialize(goodReceiptDetailDetail, typeof(GoodReceiptDetailDetail))) as GoodReceiptDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptDtlDetail(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptDtlDetail(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}