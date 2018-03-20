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
    /// Summary description for StaffLoanAdjustmentDetailHandler
    /// </summary>
    public class StaffLoanAdjustmentDetailHandler : BaseHandler
    {
        private static StaffLoanAdjustmentDetailController controller = new StaffLoanAdjustmentDetailController();


        public object SaveStaffLoanAdjustmentDetail(string staffLoanAdjustmentDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanAdjustmentDetail obj = (new JavaScriptSerializer().Deserialize(staffLoanAdjustmentDetail, typeof(StaffLoanAdjustmentDetail))) as StaffLoanAdjustmentDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanAdjustmentDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanAdjustmentDetail(string staffLoanAdjustmentDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanAdjustmentDetail search = (new JavaScriptSerializer().Deserialize(staffLoanAdjustmentDetail, typeof(StaffLoanAdjustmentDetail))) as StaffLoanAdjustmentDetail;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanAdjustmentDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanAdjDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanAdjDetail(OfficeCode, LoanNo, ClientName, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}