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
    /// Summary description for SavingTransferFromClientHandler
    /// </summary>
    public class SavingTransferFromClientHandler : BaseHandler
    {
        private static SavingTransferFromClientController controller = new SavingTransferFromClientController();


        public object SaveSavingTransferFromClient(string savingTransferFromClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferFromClient obj = (new JavaScriptSerializer().Deserialize(savingTransferFromClient, typeof(SavingTransferFromClient))) as SavingTransferFromClient;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingTransferFromClient(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingTransferFromClient(string savingTransferFromClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferFromClient search = (new JavaScriptSerializer().Deserialize(savingTransferFromClient, typeof(SavingTransferFromClient))) as SavingTransferFromClient;
            OutMessage oMsg = (OutMessage)controller.SearchSavingTransferFromClient(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavTransferFrmClient(string OfficeCode, string CenterCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavTransferFrmClient(OfficeCode, CenterCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}