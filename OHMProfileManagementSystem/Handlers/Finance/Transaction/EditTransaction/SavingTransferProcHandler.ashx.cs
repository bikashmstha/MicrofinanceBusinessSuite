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
    /// Summary description for SavingTransferProcHandler
    /// </summary>
    public class SavingTransferProcHandler : BaseHandler
    {
        private static SavingTransferProcController controller = new SavingTransferProcController();


        public object SaveSavingTransferProc(string savingTransferProc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferProc obj = (new JavaScriptSerializer().Deserialize(savingTransferProc, typeof(SavingTransferProc))) as SavingTransferProc;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingTransferProc(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingTransferProc(string savingTransferProc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferProc search = (new JavaScriptSerializer().Deserialize(savingTransferProc, typeof(SavingTransferProc))) as SavingTransferProc;
            OutMessage oMsg = (OutMessage)controller.SearchSavingTransferProc(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavTransferProc(string ProductName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavTransferProc(ProductName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}