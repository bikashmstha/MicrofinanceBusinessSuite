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
    /// Summary description for AssetItemHandler
    /// </summary>
    public class AssetItemHandler : BaseHandler
    {
        private static AssetItemController controller = new AssetItemController();


        public object SaveAssetItem(string assetItem)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetItem obj = (new JavaScriptSerializer().Deserialize(assetItem, typeof(AssetItem))) as AssetItem;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAssetItem(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAssetItem(string assetItem)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetItem search = (new JavaScriptSerializer().Deserialize(assetItem, typeof(AssetItem))) as AssetItem;
            OutMessage oMsg = (OutMessage)controller.SearchAssetItem(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAssetItem(string ItemDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAssetItem(ItemDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}