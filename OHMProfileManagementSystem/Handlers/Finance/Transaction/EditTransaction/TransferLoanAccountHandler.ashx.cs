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
    /// Summary description for TransferLoanAccountHandler
    /// </summary>
    public class TransferLoanAccountHandler : BaseHandler
    {
        private static TransferLoanAccountController controller = new TransferLoanAccountController();


        public object SaveTransferLoanAccount(string transferLoanAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferLoanAccount obj = (new JavaScriptSerializer().Deserialize(transferLoanAccount, typeof(TransferLoanAccount))) as TransferLoanAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveTransferLoanAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchTransferLoanAccount(string transferLoanAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferLoanAccount search = (new JavaScriptSerializer().Deserialize(transferLoanAccount, typeof(TransferLoanAccount))) as TransferLoanAccount;
            OutMessage oMsg = (OutMessage)controller.SearchTransferLoanAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}