using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Maintenance
{
    /// <summary>
    /// Summary description for ReligionHandler
    /// </summary>
    public class ReligionHandler : BaseHandler
    {
        private static ReligionController controller = new ReligionController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string religion)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Religion obj = (new JavaScriptSerializer().Deserialize(religion, typeof(Religion))) as Religion;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            
            OutMessage oMsg = (OutMessage)controller.Save(obj);

            resp.Success = oMsg.OutResultCode=="SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string religion)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Religion search = (new JavaScriptSerializer().Deserialize(religion, typeof(Religion))) as Religion;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}