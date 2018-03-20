using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using MicrofinanceBusinessSuite.Controllers.Inventory.Transaction;
using MicrofinanceBusinessSuite.Utility;


namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for InItemTransactionMasterHandler
    /// </summary>
    public class InItemTransactionMasterHandler : BaseHandler
    {
        private static InItemTransactionMasterController controller = new InItemTransactionMasterController();


        public object SaveInItemTransactionMaster(string inItemTransactionMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InItemTransactionMaster obj = (new JavaScriptSerializer().Deserialize(inItemTransactionMaster, typeof(InItemTransactionMaster))) as InItemTransactionMaster;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveInItemTransactionMaster(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchInItemTransactionMaster(string inItemTransactionMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InItemTransactionMaster search = (new JavaScriptSerializer().Deserialize(inItemTransactionMaster, typeof(InItemTransactionMaster))) as InItemTransactionMaster;
            OutMessage oMsg = (OutMessage)controller.SearchInItemTransactionMaster(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}