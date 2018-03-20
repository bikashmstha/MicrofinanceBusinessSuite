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
    /// Summary description for StaffLoanDisbursementLoanHandler
    /// </summary>
    public class StaffLoanDisbursementLoanHandler : BaseHandler
    {
        private static StaffLoanDisbursementLoanController controller = new StaffLoanDisbursementLoanController();


        public object SaveStaffLoanDisbursementLoan(string staffLoanDisbursementLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementLoan obj = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementLoan, typeof(StaffLoanDisbursementLoan))) as StaffLoanDisbursementLoan;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanDisbursementLoan(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanDisbursementLoan(string staffLoanDisbursementLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementLoan search = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementLoan, typeof(StaffLoanDisbursementLoan))) as StaffLoanDisbursementLoan;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanDisbursementLoan(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanDisLoan(string OfficeCode, string EmpName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanDisLoan(OfficeCode, EmpName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}