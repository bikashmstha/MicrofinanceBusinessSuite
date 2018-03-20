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
    /// Summary description for LoanTransferFromCenterHandler
    /// </summary>
    public class LoanTransferFromCenterHandler : BaseHandler
    {
        private static LoanTransferFromCenterController controller = new LoanTransferFromCenterController();
        

        public object SaveLoanTransferFromCenter(string loanTransferFromCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferFromCenter obj = (new JavaScriptSerializer().Deserialize(loanTransferFromCenter, typeof(LoanTransferFromCenter))) as LoanTransferFromCenter;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanTransferFromCenter(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanTransferFromCenter(string loanTransferFromCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferFromCenter search = (new JavaScriptSerializer().Deserialize(loanTransferFromCenter, typeof(LoanTransferFromCenter))) as LoanTransferFromCenter;
            OutMessage oMsg = (OutMessage)controller.SearchLoanTransferFromCenter(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanTransferFrmCenter(string OfficeCode, string CenterName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanTransferFrmCenter(OfficeCode, CenterName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}