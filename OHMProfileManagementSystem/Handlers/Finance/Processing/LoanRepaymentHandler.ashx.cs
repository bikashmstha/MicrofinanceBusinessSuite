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
    /// Summary description for LoanRepaymentHandler
    /// </summary>
    public class LoanRepaymentHandler : BaseHandler
    {
        private static LoanRepaymentController controller = new LoanRepaymentController();


        public object SaveLoanRepayment(string loanRepayment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanRepayment obj = (new JavaScriptSerializer().Deserialize(loanRepayment, typeof(LoanRepayment))) as LoanRepayment;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanRepayment(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanRepayment(string loanRepayment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanRepayment search = (new JavaScriptSerializer().Deserialize(loanRepayment, typeof(LoanRepayment))) as LoanRepayment;
            OutMessage oMsg = (OutMessage)controller.SearchLoanRepayment(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanRepayment(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanRepayment(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}