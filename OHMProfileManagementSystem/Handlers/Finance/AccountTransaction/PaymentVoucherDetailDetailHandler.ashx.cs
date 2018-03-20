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
    /// Summary description for PaymentVoucherDetailDetailHandler
    /// </summary>
    public class PaymentVoucherDetailDetailHandler : BaseHandler
    {
        private static PaymentVoucherDetailDetailController controller = new PaymentVoucherDetailDetailController();


        public object SavePaymentVoucherDetailDetail(string paymentVoucherDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PaymentVoucherDetailDetail obj = (new JavaScriptSerializer().Deserialize(paymentVoucherDetailDetail, typeof(PaymentVoucherDetailDetail))) as PaymentVoucherDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePaymentVoucherDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPaymentVoucherDetailDetail(string paymentVoucherDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PaymentVoucherDetailDetail search = (new JavaScriptSerializer().Deserialize(paymentVoucherDetailDetail, typeof(PaymentVoucherDetailDetail))) as PaymentVoucherDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPaymentVoucherDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPayVoucherDtlDetail(string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPayVoucherDtlDetail(VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}