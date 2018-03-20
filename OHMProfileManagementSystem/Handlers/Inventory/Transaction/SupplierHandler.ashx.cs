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
    /// Summary description for SupplierHandler
    /// </summary>
    public class SupplierHandler : BaseHandler
    {
        private static SupplierController controller = new SupplierController();


        public object SaveSupplier(string supplier)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Supplier obj = (new JavaScriptSerializer().Deserialize(supplier, typeof(Supplier))) as Supplier;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSupplier(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSupplier(string supplier)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Supplier search = (new JavaScriptSerializer().Deserialize(supplier, typeof(Supplier))) as Supplier;
            OutMessage oMsg = (OutMessage)controller.SearchSupplier(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSupplier(string SupplierDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSupplier(SupplierDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}