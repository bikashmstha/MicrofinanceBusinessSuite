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
    /// Summary description for LoanDisbursementPostingHandler
    /// </summary>
    public class LoanDisbursementPostingHandler : BaseHandler
    {
        private static LoanDisbursementPostingController controller = new LoanDisbursementPostingController();


        public object SaveLoanDisbursementPosting(string loanDisbursementPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<LoanDisbursementPosting> lst = (new JavaScriptSerializer().Deserialize(loanDisbursementPosting, typeof(List<LoanDisbursementPosting>))) as List<LoanDisbursementPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveLoanDisbursementPosting(lst);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanDisbursementPosting(string loanDisbursementPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDisbursementPosting search = (new JavaScriptSerializer().Deserialize(loanDisbursementPosting, typeof(LoanDisbursementPosting))) as LoanDisbursementPosting;
            OutMessage oMsg = (OutMessage)controller.SearchLoanDisbursementPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}