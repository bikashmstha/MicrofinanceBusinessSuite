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
    /// Summary description for SavingTransferFromCenterHandler
    /// </summary>
    public class SavingTransferFromCenterHandler : BaseHandler
    {
        private static SavingTransferFromCenterController controller = new SavingTransferFromCenterController();


        public object SaveSavingTransferFromCenter(string savingTransferFromCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferFromCenter obj = (new JavaScriptSerializer().Deserialize(savingTransferFromCenter, typeof(SavingTransferFromCenter))) as SavingTransferFromCenter;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingTransferFromCenter(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingTransferFromCenter(string savingTransferFromCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingTransferFromCenter search = (new JavaScriptSerializer().Deserialize(savingTransferFromCenter, typeof(SavingTransferFromCenter))) as SavingTransferFromCenter;
            OutMessage oMsg = (OutMessage)controller.SearchSavingTransferFromCenter(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavTransferFrmCenter(string OfficeCode, string CenterName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavTransferFrmCenter(OfficeCode, CenterName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}