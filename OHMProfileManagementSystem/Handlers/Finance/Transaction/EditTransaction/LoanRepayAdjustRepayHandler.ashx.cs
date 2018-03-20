using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.EditTransaction
{
    /// <summary>
    /// Summary description for LoanRepayAdjustRepayHandler
    /// </summary>
    public class LoanRepayAdjustRepayHandler : BaseHandler
    {
        private static LoanRepayAdjustRepayController controller = new LoanRepayAdjustRepayController();


        public object GetLoanRepayAdjustRepay(string OfficeCode, string LoanNo, string LoanDno, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanRepayAdjustRepay(OfficeCode, LoanNo, LoanDno, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}