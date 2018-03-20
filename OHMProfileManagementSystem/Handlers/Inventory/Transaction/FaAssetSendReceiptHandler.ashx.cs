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
    /// Summary description for FaAssetSendReceiptHandler
    /// </summary>
    public class FaAssetSendReceiptHandler : BaseHandler
    {
        private static FaAssetSendReceiptController controller = new FaAssetSendReceiptController();


        public object SaveFaAssetSendReceipt(string faAssetSendReceipt)
        {
            ExtJSResponse resp = new ExtJSResponse();
            FaAssetSendReceipt obj = (new JavaScriptSerializer().Deserialize(faAssetSendReceipt, typeof(FaAssetSendReceipt))) as FaAssetSendReceipt;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveFaAssetSendReceipt(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchFaAssetSendReceipt(string faAssetSendReceipt)
        {
            ExtJSResponse resp = new ExtJSResponse();
            FaAssetSendReceipt search = (new JavaScriptSerializer().Deserialize(faAssetSendReceipt, typeof(FaAssetSendReceipt))) as FaAssetSendReceipt;
            OutMessage oMsg = (OutMessage)controller.SearchFaAssetSendReceipt(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}