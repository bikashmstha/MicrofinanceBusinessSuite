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
    /// Summary description for ReceiptVoucherMasterDetailHandler
    /// </summary>
    public class ReceiptVoucherMasterDetailHandler : BaseHandler
    {
        private static ReceiptVoucherMasterDetailController controller = new ReceiptVoucherMasterDetailController();


        public object SaveReceiptVoucherMasterDetail(string receiptVoucherMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReceiptVoucherMasterDetail obj = (new JavaScriptSerializer().Deserialize(receiptVoucherMasterDetail, typeof(ReceiptVoucherMasterDetail))) as ReceiptVoucherMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveReceiptVoucherMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchReceiptVoucherMasterDetail(string receiptVoucherMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReceiptVoucherMasterDetail search = (new JavaScriptSerializer().Deserialize(receiptVoucherMasterDetail, typeof(ReceiptVoucherMasterDetail))) as ReceiptVoucherMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchReceiptVoucherMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetReceiptVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetReceiptVoucherMstDetail(OfficeCode, VoucherNo, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}