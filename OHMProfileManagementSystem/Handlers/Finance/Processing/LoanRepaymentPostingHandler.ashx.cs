using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using MicrofinanceBusinessSuite.Controllers.Finance.Processing;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Processing
{
    /// <summary>
    /// Summary description for LoanRepaymentPostingHandler
    /// </summary>
    public class LoanRepaymentPostingHandler : BaseHandler
    {
        private static LoanRepaymentPostingController controller = new LoanRepaymentPostingController();


        public object SaveLoanRepaymentPosting(string loanRepaymentPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<LoanRepaymentPosting> lst = (new JavaScriptSerializer().Deserialize(loanRepaymentPosting, typeof(List<LoanRepaymentPosting>))) as List<LoanRepaymentPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveLoanRepaymentPosting(lst);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanRepaymentPosting(string loanRepaymentPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanRepaymentPosting search = (new JavaScriptSerializer().Deserialize(loanRepaymentPosting, typeof(LoanRepaymentPosting))) as LoanRepaymentPosting;
            OutMessage oMsg = (OutMessage)controller.SearchLoanRepaymentPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}