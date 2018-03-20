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
    /// Summary description for StaffLoanDisbursementHandler
    /// </summary>
    public class StaffLoanDisbursementHandler : BaseHandler
    {
        private static StaffLoanDisbursementController controller = new StaffLoanDisbursementController();


        public object SaveStaffLoanDisbursement(string staffLoanDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursement obj = (new JavaScriptSerializer().Deserialize(staffLoanDisbursement, typeof(StaffLoanDisbursement))) as StaffLoanDisbursement;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanDisbursement(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        
    }
}