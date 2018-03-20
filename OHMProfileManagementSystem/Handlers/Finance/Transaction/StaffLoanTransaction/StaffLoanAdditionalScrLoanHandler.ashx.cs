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
    /// Summary description for StaffLoanAdditionalScrLoanHandler
    /// </summary>
    public class StaffLoanAdditionalScrLoanHandler : BaseHandler
    {
        private static StaffLoanAdditionalScrLoanController controller = new StaffLoanAdditionalScrLoanController();


        public object SaveStaffLoanAdditionalScrLoan(string staffLoanAdditionalScrLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanAdditionalScrLoan obj = (new JavaScriptSerializer().Deserialize(staffLoanAdditionalScrLoan, typeof(StaffLoanAdditionalScrLoan))) as StaffLoanAdditionalScrLoan;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanAdditionalScrLoan(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanAdditionalScrLoan(string staffLoanAdditionalScrLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanAdditionalScrLoan search = (new JavaScriptSerializer().Deserialize(staffLoanAdditionalScrLoan, typeof(StaffLoanAdditionalScrLoan))) as StaffLoanAdditionalScrLoan;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanAdditionalScrLoan(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanAdjScrLoan(string OfficeCode, string EmpName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanAdjScrLoan(OfficeCode, EmpName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}