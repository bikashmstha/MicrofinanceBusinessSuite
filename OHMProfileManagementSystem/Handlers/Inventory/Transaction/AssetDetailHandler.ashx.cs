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
    /// Summary description for AssetDetailHandler
    /// </summary>
    public class AssetDetailHandler : BaseHandler
    {
        private static AssetDetailController controller = new AssetDetailController();


        public object SaveAssetDetail(string assetDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetDetail obj = (new JavaScriptSerializer().Deserialize(assetDetail, typeof(AssetDetail))) as AssetDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAssetDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAssetDetail(string assetDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetDetail search = (new JavaScriptSerializer().Deserialize(assetDetail, typeof(AssetDetail))) as AssetDetail;
            OutMessage oMsg = (OutMessage)controller.SearchAssetDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAssetDetail(string assetDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetDetail search = (new JavaScriptSerializer().Deserialize(assetDetail, typeof(AssetDetail))) as AssetDetail;
            OutMessage oMsg = (OutMessage)controller.GetAssetDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}