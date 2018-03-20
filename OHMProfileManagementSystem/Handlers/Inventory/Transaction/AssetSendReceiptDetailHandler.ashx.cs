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
    /// Summary description for AssetSendReceiptDetailHandler
    /// </summary>
    public class AssetSendReceiptDetailHandler : BaseHandler
    {
        private static AssetSendReceiptDetailController controller = new AssetSendReceiptDetailController();


        
        public object GetAssetSendReceiptDetail(string AssetCode, string ReceiveSendDrop)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAssetSendReceiptDetail(AssetCode, ReceiveSendDrop);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}