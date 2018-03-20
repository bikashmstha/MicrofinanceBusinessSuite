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
    /// Summary description for LoanTransferToClientHandler
    /// </summary>
    public class LoanTransferToClientHandler : BaseHandler
    {
        private static LoanTransferToClientController controller = new LoanTransferToClientController();


        public object SaveLoanTransferToClient(string loanTransferToClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferToClient obj = (new JavaScriptSerializer().Deserialize(loanTransferToClient, typeof(LoanTransferToClient))) as LoanTransferToClient;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanTransferToClient(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanTransferToClient(string loanTransferToClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferToClient search = (new JavaScriptSerializer().Deserialize(loanTransferToClient, typeof(LoanTransferToClient))) as LoanTransferToClient;
            OutMessage oMsg = (OutMessage)controller.SearchLoanTransferToClient(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanTransferToClient(string OfficeCode, string CenterCode, string ProductCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanTransferToClient(OfficeCode, CenterCode, ProductCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}