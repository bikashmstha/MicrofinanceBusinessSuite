using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using MicrofinanceBusinessSuite.Controllers.Maintenance;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Menu;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Menu
{
    /// <summary>
    /// Summary description for ModuleHandler
    /// </summary>
    public class ModuleHandler : BaseHandler
    {
        private static ModuleController controller = new ModuleController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string module)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Module obj = (new JavaScriptSerializer().Deserialize(module, typeof(Module))) as Module;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string module)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Module search = (new JavaScriptSerializer().Deserialize(module, typeof(Module))) as Module;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetModuleShort()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetModuleShort();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}