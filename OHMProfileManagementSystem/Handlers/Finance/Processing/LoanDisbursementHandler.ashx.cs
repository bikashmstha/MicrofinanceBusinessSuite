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
    /// Summary description for LoanDisbursementHandler
    /// </summary>
    public class LoanDisbursementHandler : BaseHandler
    {
        private static LoanDisbursementController controller = new LoanDisbursementController();


        public object SaveLoanDisbursement(string loanDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDisbursement obj = (new JavaScriptSerializer().Deserialize(loanDisbursement, typeof(LoanDisbursement))) as LoanDisbursement;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanDisbursement(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanDisbursement(string loanDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDisbursement search = (new JavaScriptSerializer().Deserialize(loanDisbursement, typeof(LoanDisbursement))) as LoanDisbursement;
            OutMessage oMsg = (OutMessage)controller.SearchLoanDisbursement(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanDisbursement(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanDisbursement(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}