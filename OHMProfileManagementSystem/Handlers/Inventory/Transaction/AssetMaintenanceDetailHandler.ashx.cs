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
    /// Summary description for AssetMaintenanceDetailHandler
    /// </summary>
    public class AssetMaintenanceDetailHandler : BaseHandler
    {
        private static AssetMaintenanceDetailController controller = new AssetMaintenanceDetailController();


        public object SaveAssetMaintenanceDetail(string assetMaintenanceDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetMaintenanceDetail obj = (new JavaScriptSerializer().Deserialize(assetMaintenanceDetail, typeof(AssetMaintenanceDetail))) as AssetMaintenanceDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAssetMaintenanceDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAssetMaintenanceDetail(string assetMaintenanceDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AssetMaintenanceDetail search = (new JavaScriptSerializer().Deserialize(assetMaintenanceDetail, typeof(AssetMaintenanceDetail))) as AssetMaintenanceDetail;
            OutMessage oMsg = (OutMessage)controller.SearchAssetMaintenanceDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAssetMaintenanceDtl(string AssetCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAssetMaintenanceDtl(AssetCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}