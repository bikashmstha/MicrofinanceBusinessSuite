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
    /// Summary description for InfFaAssetHandler
    /// </summary>
    public class InfFaAssetHandler : BaseHandler
    {
        private static InfFaAssetController controller = new InfFaAssetController();


        public object SaveInfFaAsset(string infFaAsset)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InfFaAsset obj = (new JavaScriptSerializer().Deserialize(infFaAsset, typeof(InfFaAsset))) as InfFaAsset;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveInfFaAsset(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchInfFaAsset(string infFaAsset)
        {
            ExtJSResponse resp = new ExtJSResponse();
            InfFaAsset search = (new JavaScriptSerializer().Deserialize(infFaAsset, typeof(InfFaAsset))) as InfFaAsset;
            OutMessage oMsg = (OutMessage)controller.SearchInfFaAsset(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}