using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.StaffLoanTransaction
{
    /// <summary>
    /// Summary description for StaffLoanRepayAdjustmentSavingHandler
    /// </summary>
    public class StaffLoanRepayAdjustmentSavingHandler : BaseHandler
    {
        private static StaffLoanRepayAdjustmentSavingController controller = new StaffLoanRepayAdjustmentSavingController();


        public object SaveStaffLoanRepayAdjustmentSaving(string staffLoanRepayAdjustmentSaving)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayAdjustmentSaving obj = (new JavaScriptSerializer().Deserialize(staffLoanRepayAdjustmentSaving, typeof(StaffLoanRepayAdjustmentSaving))) as StaffLoanRepayAdjustmentSaving;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanRepayAdjustmentSaving(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanRepayAdjustmentSaving(string staffLoanRepayAdjustmentSaving)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayAdjustmentSaving search = (new JavaScriptSerializer().Deserialize(staffLoanRepayAdjustmentSaving, typeof(StaffLoanRepayAdjustmentSaving))) as StaffLoanRepayAdjustmentSaving;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanRepayAdjustmentSaving(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanRepayAdjSav(string OfficeCode, string ClientNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanRepayAdjSav(OfficeCode, ClientNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}