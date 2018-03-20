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
    /// Summary description for DepartmentHandler
    /// </summary>
    public class DepartmentHandler : BaseHandler
    {
        private static DepartmentController controller = new DepartmentController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string Department)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Department obj = (new JavaScriptSerializer().Deserialize(Department, typeof(Department))) as Department;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;

            OutMessage oMsg = (OutMessage)controller.Save(obj);

            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string Department)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Department search = (new JavaScriptSerializer().Deserialize(Department, typeof(Department))) as Department;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}