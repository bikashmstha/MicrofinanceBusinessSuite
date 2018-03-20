using App.Utilities.Web.Handlers;
using BusinessObjects;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.LoanTransaction
{
    /// <summary>
    /// Summary description for LoanRepayAdjustLoanHandler
    /// </summary>
    public class LoanRepayAdjustLoanHandler : BaseHandler
    {
        private static LoanRepayAdjustLoanController controller = new LoanRepayAdjustLoanController();
        public object GetLoanRepayAdjustLoan(string OfficeCode, string ClientName, string FromDate, string ToDate)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanRepayAdjustLoan(OfficeCode,ClientName,FromDate,ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object GetLoanProduct(string productName)
        //{

        //    ExtJSResponse resp = new ExtJSResponse();
        //    OutMessage oMsg = (OutMessage)controller.GetLoanProduct(productName);
        //    resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
        //    resp.Message = oMsg.OutResultMessage;
        //    return resp.GetResponse(oMsg.Result, null);
        //}
        
    }
}