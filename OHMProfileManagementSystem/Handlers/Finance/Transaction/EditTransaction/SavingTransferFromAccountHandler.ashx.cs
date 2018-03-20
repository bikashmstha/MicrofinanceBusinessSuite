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
    /// Summary description for SavingTransferFromAccountHandler
    /// </summary>
    public class SavingTransferFromAccountHandler : BaseHandler
    {
        private static SavingTransferFromAccountController controller = new SavingTransferFromAccountController();


        public object SaveSavingTransferFromAccount(string savingTransferFromAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferFromAccount obj = (new JavaScriptSerializer().Deserialize(savingTransferFromAccount, typeof(SavingTransferFromAccount))) as SavingTransferFromAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingTransferFromAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingTransferFromAccount(string savingTransferFromAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferFromAccount search = (new JavaScriptSerializer().Deserialize(savingTransferFromAccount, typeof(SavingTransferFromAccount))) as SavingTransferFromAccount;
            OutMessage oMsg = (OutMessage)controller.SearchSavingTransferFromAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavTransferFrmAcc(string OfficeCode, string CenterCode, string ClientNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavTransferFrmAcc(OfficeCode, CenterCode, ClientNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}