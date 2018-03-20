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
    /// Summary description for StaffLoanRepayDetailHandler
    /// </summary>
    public class StaffLoanRepayDetailHandler : BaseHandler
    {
        private static StaffLoanRepayDetailController controller = new StaffLoanRepayDetailController();


        public object SaveStaffLoanRepayDetail(string staffLoanRepayDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayDetail obj = (new JavaScriptSerializer().Deserialize(staffLoanRepayDetail, typeof(StaffLoanRepayDetail))) as StaffLoanRepayDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanRepayDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanRepayDetail(string staffLoanRepayDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayDetail search = (new JavaScriptSerializer().Deserialize(staffLoanRepayDetail, typeof(StaffLoanRepayDetail))) as StaffLoanRepayDetail;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanRepayDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanRepayDetail(string OfficeCode, long? RepaymentNo, string LoanDno, string ClientName, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanRepayDetail(OfficeCode, RepaymentNo, LoanDno, ClientName, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}