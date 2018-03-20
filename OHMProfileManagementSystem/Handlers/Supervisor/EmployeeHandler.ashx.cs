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
    /// Summary description for EmployeeHandler
    /// </summary>
    public class EmployeeHandler : BaseHandler
    {

        private static EmployeeController controller = new EmployeeController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string employee)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Employee obj = (new JavaScriptSerializer().Deserialize(employee, typeof(Employee))) as Employee;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string employee)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Employee search = (new JavaScriptSerializer().Deserialize(employee, typeof(Employee))) as Employee;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetEmployeeShort(string officeCode, string employeeName)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetEmployeeShort(officeCode,employeeName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetToEmployeeShort(string employeeName)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetToEmployeeShort( employeeName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetFieldAssistants(string officeCode, string empName)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetFieldAssistants(officeCode,empName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetEmployee(string OfficeName, string UserCode, string EmpName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmployee(OfficeName, UserCode, EmpName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetEmployeeLov(string OfficeCode, string PostCode, string EmpName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmployeeLov(OfficeCode, PostCode, EmpName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}