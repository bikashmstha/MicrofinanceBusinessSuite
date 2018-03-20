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
    /// Summary description for VoucherAccountHandler
    /// </summary>
    public class VoucherAccountHandler : BaseHandler
    {
        private static VoucherAccountController controller = new VoucherAccountController();


        public object SaveVoucherAccount(string voucherAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VoucherAccount obj = (new JavaScriptSerializer().Deserialize(voucherAccount, typeof(VoucherAccount))) as VoucherAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveVoucherAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchVoucherAccount(string voucherAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VoucherAccount search = (new JavaScriptSerializer().Deserialize(voucherAccount, typeof(VoucherAccount))) as VoucherAccount;
            OutMessage oMsg = (OutMessage)controller.SearchVoucherAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetVoucherAcc(string OfficeCode, string AccountDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetVoucherAcc(OfficeCode, AccountDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}