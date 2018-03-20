using App.Utilities.Web.Handlers;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters
{
    /// <summary>
    /// Summary description for OfficeHandler
    /// </summary>
    public class OfficeMapHandler : BaseHandler
    {
        private static OfficeMapController controller = new OfficeMapController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object Get()
        //{
        //    ExtJSResponse resp = new ExtJSResponse();
        //    object obj = controller.Get();
        //    string response = resp.GetResponse(obj, null);
        //    SetResponseContentType(ResponseContentTypes.JSON);
        //    return response;
        //}

        public object Save(string officeMap)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OfficeMap obj = (new JavaScriptSerializer().Deserialize(officeMap, typeof(OfficeMap))) as OfficeMap;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object SaveOfficeMap(string officeMap)
        //{
        //    ExtJSResponse resp = new ExtJSResponse();
        //    OfficeMap obj = (new JavaScriptSerializer().Deserialize(officeMap, typeof(OfficeMap))) as OfficeMap;
        //    object success = controller.SaveOfficeMap(obj);
        //    string response = resp.GetResponse(new List<OfficeMap>(), 0);
        //    SetResponseContentType(ResponseContentTypes.JSON);
        //    return response;
        //}

        public object Search(string officeMap)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OfficeMap search = (new JavaScriptSerializer().Deserialize(officeMap, typeof(OfficeMap))) as OfficeMap;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object Search(string officeMap)
        //{
        //    OfficeMap search = (new JavaScriptSerializer().Deserialize(officeMap, typeof(OfficeMap))) as OfficeMap;
        //    object obj = controller.SearchOfficeMap(search);
        //    return null;//GetResponse(obj);
        //}
    }
}