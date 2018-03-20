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
    /// Summary description for StaffLoanRepaymentHandler
    /// </summary>
    public class StaffLoanRepaymentHandler : BaseHandler
    {
        private static StaffLoanRepaymentController controller = new StaffLoanRepaymentController();


        public object SaveStaffLoanRepayment(string staffLoanRepayment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayment obj = (new JavaScriptSerializer().Deserialize(staffLoanRepayment, typeof(StaffLoanRepayment))) as StaffLoanRepayment;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanRepayment(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanRepayment(string staffLoanRepayment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanRepayment search = (new JavaScriptSerializer().Deserialize(staffLoanRepayment, typeof(StaffLoanRepayment))) as StaffLoanRepayment;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanRepayment(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }


    }
}