using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.LoanTransaction
{
    /// <summary>
    /// Summary description for LoanInformationHandler
    /// </summary>
    public class LoanInformationHandler : BaseHandler
    {
        private static LoanInformationController controller = new LoanInformationController();


        public object SaveLoanInformation(string loanInformation)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanInformation obj = (new JavaScriptSerializer().Deserialize(loanInformation, typeof(LoanInformation))) as LoanInformation;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanInformation(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanInformation(string loanInformation)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanInformation search = (new JavaScriptSerializer().Deserialize(loanInformation, typeof(LoanInformation))) as LoanInformation;
            OutMessage oMsg = (OutMessage)controller.SearchLoanInformation(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanInformation()
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanInformation();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}