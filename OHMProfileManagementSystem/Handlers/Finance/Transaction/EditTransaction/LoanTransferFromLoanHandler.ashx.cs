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
    /// Summary description for LoanTransferFromLoanHandler
    /// </summary>
    public class LoanTransferFromLoanHandler : BaseHandler
    {
        private static LoanTransferFromLoanController controller = new LoanTransferFromLoanController();


        public object SaveLoanTransferFromLoan(string loanTransferFromLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferFromLoan obj = (new JavaScriptSerializer().Deserialize(loanTransferFromLoan, typeof(LoanTransferFromLoan))) as LoanTransferFromLoan;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanTransferFromLoan(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanTransferFromLoan(string loanTransferFromLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferFromLoan search = (new JavaScriptSerializer().Deserialize(loanTransferFromLoan, typeof(LoanTransferFromLoan))) as LoanTransferFromLoan;
            OutMessage oMsg = (OutMessage)controller.SearchLoanTransferFromLoan(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanTransferFrmLoan(string OfficeCode, string CenterCode, string ClientNo, string ProductCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanTransferFrmLoan(OfficeCode, CenterCode, ClientNo, ProductCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}