using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegratedTaxSystem.Controllers;
using IntegratedTaxSystem.Controllers.Security;

using System.Web.SessionState;
using App.Utilities.Web.Handlers;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Security;
using MicrofinanceBusinessSuite.Controllers.Security;
using BusinessObjects;
using System.Web.Script.Serialization;
namespace MicrofinanceBusinessSuite.Handlers.Security
{
    /// <summary>
    /// Summary description for RoleHandler
    /// </summary>
    public class RoleHandler : BaseHandler
    {
        private static RoleController controller = new RoleController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string role)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Role obj = (new JavaScriptSerializer().Deserialize(role, typeof(Role))) as Role;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string role)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Role search = (new JavaScriptSerializer().Deserialize(role, typeof(Role))) as Role;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}