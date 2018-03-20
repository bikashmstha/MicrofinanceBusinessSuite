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
    /// Summary description for TransferSavingAccountHandler
    /// </summary>
    public class TransferSavingAccountHandler : BaseHandler
    {
        private static TransferSavingAccountController controller = new TransferSavingAccountController();


        public object SaveTransferSavingAccount(string transferSavingAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferSavingAccount obj = (new JavaScriptSerializer().Deserialize(transferSavingAccount, typeof(TransferSavingAccount))) as TransferSavingAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveTransferSavingAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchTransferSavingAccount(string transferSavingAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferSavingAccount search = (new JavaScriptSerializer().Deserialize(transferSavingAccount, typeof(TransferSavingAccount))) as TransferSavingAccount;
            OutMessage oMsg = (OutMessage)controller.SearchTransferSavingAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}