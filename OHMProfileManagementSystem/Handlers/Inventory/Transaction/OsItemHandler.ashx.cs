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
    /// Summary description for OsItemHandler
    /// </summary>
    public class OsItemHandler : BaseHandler
    {
        private static OsItemController controller = new OsItemController();


        public object SaveOsItem(string osItem)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OsItem obj = (new JavaScriptSerializer().Deserialize(osItem, typeof(OsItem))) as OsItem;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveOsItem(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchOsItem(string osItem)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OsItem search = (new JavaScriptSerializer().Deserialize(osItem, typeof(OsItem))) as OsItem;
            OutMessage oMsg = (OutMessage)controller.SearchOsItem(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetOsItem(string ItemDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOsItem(ItemDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}