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
    /// Summary description for PaymentVoucherMasterDetailHandler
    /// </summary>
    public class PaymentVoucherMasterDetailHandler : BaseHandler
    {
        private static PaymentVoucherMasterDetailController controller = new PaymentVoucherMasterDetailController();


        public object SavePaymentVoucherMasterDetail(string paymentVoucherMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PaymentVoucherMasterDetail obj = (new JavaScriptSerializer().Deserialize(paymentVoucherMasterDetail, typeof(PaymentVoucherMasterDetail))) as PaymentVoucherMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePaymentVoucherMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPaymentVoucherMasterDetail(string paymentVoucherMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PaymentVoucherMasterDetail search = (new JavaScriptSerializer().Deserialize(paymentVoucherMasterDetail, typeof(PaymentVoucherMasterDetail))) as PaymentVoucherMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPaymentVoucherMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPayVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPayVoucherMstDetail(OfficeCode, VoucherNo, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}