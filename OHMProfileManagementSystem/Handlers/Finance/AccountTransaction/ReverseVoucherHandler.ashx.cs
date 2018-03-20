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
    /// Summary description for ReverseVoucherHandler
    /// </summary>
    public class ReverseVoucherHandler : BaseHandler
    {
        private static ReverseVoucherController controller = new ReverseVoucherController();


        public object SaveReverseVoucher(string reverseVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReverseVoucher obj = (new JavaScriptSerializer().Deserialize(reverseVoucher, typeof(ReverseVoucher))) as ReverseVoucher;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveReverseVoucher(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchReverseVoucher(string reverseVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReverseVoucher search = (new JavaScriptSerializer().Deserialize(reverseVoucher, typeof(ReverseVoucher))) as ReverseVoucher;
            OutMessage oMsg = (OutMessage)controller.SearchReverseVoucher(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetReverseVoucher(string OfficeCode, string FiscalYear, string Particulars)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetReverseVoucher(OfficeCode, FiscalYear, Particulars);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}