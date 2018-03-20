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
    /// Summary description for JvSearchVoucherHandler
    /// </summary>
    public class JvSearchVoucherHandler : BaseHandler
    {
        private static JvSearchVoucherController controller = new JvSearchVoucherController();


        public object SaveJvSearchVoucher(string jVSearchVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            JvSearchVoucher obj = (new JavaScriptSerializer().Deserialize(jVSearchVoucher, typeof(JvSearchVoucher))) as JvSearchVoucher;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveJvSearchVoucher(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchJvSearchVoucher(string jVSearchVoucher)
        {
            ExtJSResponse resp = new ExtJSResponse();
            JvSearchVoucher search = (new JavaScriptSerializer().Deserialize(jVSearchVoucher, typeof(JvSearchVoucher))) as JvSearchVoucher;
            OutMessage oMsg = (OutMessage)controller.SearchJvSearchVoucher(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetJvSearchVoucher(string OfficeCode, string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetJvSearchVoucher(OfficeCode, VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}