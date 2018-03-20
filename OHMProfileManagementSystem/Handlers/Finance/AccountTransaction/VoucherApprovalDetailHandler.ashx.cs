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
    /// Summary description for VoucherApprovalDetailHandler
    /// </summary>
    public class VoucherApprovalDetailHandler : BaseHandler
    {
        private static VoucherApprovalDetailController controller = new VoucherApprovalDetailController();


        public object SaveVoucherApprovalDetail(string VoucherApprovalDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VoucherApprovalDetail obj = (new JavaScriptSerializer().Deserialize(VoucherApprovalDetail, typeof(VoucherApprovalDetail))) as VoucherApprovalDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveVoucherApprovalDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchVoucherApprovalDetail(string VoucherApprovalDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VoucherApprovalDetail search = (new JavaScriptSerializer().Deserialize(VoucherApprovalDetail, typeof(VoucherApprovalDetail))) as VoucherApprovalDetail;
            OutMessage oMsg = (OutMessage)controller.SearchVoucherApprovalDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetVouApprovalDet(string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetVouApprovalDet(VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}