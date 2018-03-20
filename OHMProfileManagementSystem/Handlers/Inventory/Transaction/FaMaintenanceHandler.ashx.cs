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
    /// Summary description for FaMaintenanceHandler
    /// </summary>
    public class FaMaintenanceHandler : BaseHandler
    {
        private static FaMaintenanceController controller = new FaMaintenanceController();


        public object SaveFaMaintenance(string famaintenance)
        {
            ExtJSResponse resp = new ExtJSResponse();
            FaMaintenance obj = (new JavaScriptSerializer().Deserialize(famaintenance, typeof(FaMaintenance))) as FaMaintenance;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveFaMaintenance(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchFaMaintenance(string famaintenance)
        {
            ExtJSResponse resp = new ExtJSResponse();
            FaMaintenance search = (new JavaScriptSerializer().Deserialize(famaintenance, typeof(FaMaintenance))) as FaMaintenance;
            OutMessage oMsg = (OutMessage)controller.SearchFaMaintenance(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}