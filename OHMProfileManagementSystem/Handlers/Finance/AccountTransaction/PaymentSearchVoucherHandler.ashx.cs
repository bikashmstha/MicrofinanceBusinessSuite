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
    /// Summary description for PaymentSearchVoucherHandler
    /// </summary>
    public class PaymentSearchVoucherHandler : BaseHandler
    {
        private static PaymentSearchVoucherController controller = new PaymentSearchVoucherController();


        public object SavePaymentSearchVoucher(string paymentSearchVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PaymentSearchVoucher obj = (new JavaScriptSerializer().Deserialize(paymentSearchVoucher, typeof(PaymentSearchVoucher))) as PaymentSearchVoucher;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePaymentSearchVoucher(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPaymentSearchVoucher(string paymentSearchVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PaymentSearchVoucher search = (new JavaScriptSerializer().Deserialize(paymentSearchVoucher, typeof(PaymentSearchVoucher))) as PaymentSearchVoucher;
            OutMessage oMsg = (OutMessage)controller.SearchPaymentSearchVoucher(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPaySearchVoucher(string OfficeCode, string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPaySearchVoucher(OfficeCode, VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}