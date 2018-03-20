using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Supervisor;
using MicrofinanceBusinessSuite.Controllers.Supervisor;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Supervisor
{
    /// <summary>
    /// Summary description for OfficeDepartmentHandler
    /// </summary>
    public class OfficeDepartmentHandler : BaseHandler
    {
        private static OfficeDepartmentController controller = new OfficeDepartmentController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string OfficeDepartment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OfficeDepartment obj = (new JavaScriptSerializer().Deserialize(OfficeDepartment, typeof(OfficeDepartment))) as OfficeDepartment;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string OfficeDepartment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OfficeDepartment search = (new JavaScriptSerializer().Deserialize(OfficeDepartment, typeof(OfficeDepartment))) as OfficeDepartment;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}