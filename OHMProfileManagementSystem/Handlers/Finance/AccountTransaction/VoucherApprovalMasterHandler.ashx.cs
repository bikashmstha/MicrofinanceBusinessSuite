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
    /// Summary description for VoucherApprovalMasterHandler
    /// </summary>
    public class VoucherApprovalMasterHandler : BaseHandler
    {
        private static VoucherApprovalMasterController controller = new VoucherApprovalMasterController();


        public object SaveVoucherApprovalMaster(string VoucherApprovalMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VoucherApprovalMaster obj = (new JavaScriptSerializer().Deserialize(VoucherApprovalMaster, typeof(VoucherApprovalMaster))) as VoucherApprovalMaster;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveVoucherApprovalMaster(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchVoucherApprovalMaster(string VoucherApprovalMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VoucherApprovalMaster search = (new JavaScriptSerializer().Deserialize(VoucherApprovalMaster, typeof(VoucherApprovalMaster))) as VoucherApprovalMaster;
            OutMessage oMsg = (OutMessage)controller.SearchVoucherApprovalMaster(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetVouApprovalMst(string OfficeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetVouApprovalMst(OfficeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}