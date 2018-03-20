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
    /// Summary description for GoodReceiptReturnItemHandler
    /// </summary>
    public class GoodReceiptReturnItemHandler : BaseHandler
    {
        private static GoodReceiptReturnItemController controller = new GoodReceiptReturnItemController();


        public object SaveGoodReceiptReturnItem(string goodReceiptReturnItem)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturnItem obj = (new JavaScriptSerializer().Deserialize(goodReceiptReturnItem, typeof(GoodReceiptReturnItem))) as GoodReceiptReturnItem;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptReturnItem(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptReturnItem(string goodReceiptReturnItem)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturnItem search = (new JavaScriptSerializer().Deserialize(goodReceiptReturnItem, typeof(GoodReceiptReturnItem))) as GoodReceiptReturnItem;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptReturnItem(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptReturnItem(string ItemDesc, string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptReturnItem(ItemDesc, ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}