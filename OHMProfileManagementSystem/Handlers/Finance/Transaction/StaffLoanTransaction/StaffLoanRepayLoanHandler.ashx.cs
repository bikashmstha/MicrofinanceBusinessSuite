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
    /// Summary description for StaffLoanRepayLoanHandler
    /// </summary>
    public class StaffLoanRepayLoanHandler : BaseHandler
    {
        private static StaffLoanRepayLoanController controller = new StaffLoanRepayLoanController();


        public object SaveStaffLoanRepayLoan(string staffLoanRepayLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayLoan obj = (new JavaScriptSerializer().Deserialize(staffLoanRepayLoan, typeof(StaffLoanRepayLoan))) as StaffLoanRepayLoan;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanRepayLoan(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanRepayLoan(string staffLoanRepayLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayLoan search = (new JavaScriptSerializer().Deserialize(staffLoanRepayLoan, typeof(StaffLoanRepayLoan))) as StaffLoanRepayLoan;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanRepayLoan(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanRepayLoan(string OfficeCode, string ProductCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanRepayLoan(OfficeCode, ProductCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}