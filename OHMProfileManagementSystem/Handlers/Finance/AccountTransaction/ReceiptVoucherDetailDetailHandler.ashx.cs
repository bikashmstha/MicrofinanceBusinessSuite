using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for ReceiptVoucherDetailDetailHandler
    /// </summary>
    public class ReceiptVoucherDetailDetailHandler : BaseHandler
    {
        private static ReceiptVoucherDetailDetailController controller = new ReceiptVoucherDetailDetailController();


        public object SaveReceiptVoucherDetailDetail(string receiptVoucherDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReceiptVoucherDetailDetail obj = (new JavaScriptSerializer().Deserialize(receiptVoucherDetailDetail, typeof(ReceiptVoucherDetailDetail))) as ReceiptVoucherDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveReceiptVoucherDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchReceiptVoucherDetailDetail(string receiptVoucherDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReceiptVoucherDetailDetail search = (new JavaScriptSerializer().Deserialize(receiptVoucherDetailDetail, typeof(ReceiptVoucherDetailDetail))) as ReceiptVoucherDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchReceiptVoucherDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetReceiptVoucherDtlDetail(string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetReceiptVoucherDtlDetail(VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}