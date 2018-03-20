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
    /// Summary description for LoanTransferFromClientHandler
    /// </summary>
    public class LoanTransferFromClientHandler : BaseHandler
    {
        private static LoanTransferFromClientController controller = new LoanTransferFromClientController();
        

        public object SaveLoanTransferFromClient(string loanTransferFromClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferFromClient obj = (new JavaScriptSerializer().Deserialize(loanTransferFromClient, typeof(LoanTransferFromClient))) as LoanTransferFromClient;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanTransferFromClient(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanTransferFromClient(string loanTransferFromClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferFromClient search = (new JavaScriptSerializer().Deserialize(loanTransferFromClient, typeof(LoanTransferFromClient))) as LoanTransferFromClient;
            OutMessage oMsg = (OutMessage)controller.SearchLoanTransferFromClient(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanTransferFrmClient(string OfficeCode, string CenterCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanTransferFrmClient(OfficeCode, CenterCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}