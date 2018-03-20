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
    /// Summary description for LocationHandler
    /// </summary>
    public class LocationHandler : BaseHandler
    {
        private static LocationController controller = new LocationController();


        public object SaveLocation(string location)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Location obj = (new JavaScriptSerializer().Deserialize(location, typeof(Location))) as Location;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLocation(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLocation(string location)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Location search = (new JavaScriptSerializer().Deserialize(location, typeof(Location))) as Location;
            OutMessage oMsg = (OutMessage)controller.SearchLocation(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLocation(string OfficeCode, string LocationDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLocation(OfficeCode, LocationDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}