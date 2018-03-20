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
    /// Summary description for ReceiptSearchVoucherHandler
    /// </summary>
    public class ReceiptSearchVoucherHandler : BaseHandler
    {
        private static ReceiptSearchVoucherController controller = new ReceiptSearchVoucherController();


        public object SaveReceiptSearchVoucher(string receiptSearchVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReceiptSearchVoucher obj = (new JavaScriptSerializer().Deserialize(receiptSearchVoucher, typeof(ReceiptSearchVoucher))) as ReceiptSearchVoucher;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveReceiptSearchVoucher(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchReceiptSearchVoucher(string receiptSearchVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReceiptSearchVoucher search = (new JavaScriptSerializer().Deserialize(receiptSearchVoucher, typeof(ReceiptSearchVoucher))) as ReceiptSearchVoucher;
            OutMessage oMsg = (OutMessage)controller.SearchReceiptSearchVoucher(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetRcpSearchVoucher(string OfficeCode, string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetRcpSearchVoucher(OfficeCode, VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}