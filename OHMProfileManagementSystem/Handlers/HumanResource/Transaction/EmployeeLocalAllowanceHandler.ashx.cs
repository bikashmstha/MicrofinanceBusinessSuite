using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.HumanResource.Transaction;
using MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.HumanResource.Transaction
{
    /// <summary>
    /// Summary description for EmployeeLocalAllowanceHandler
    /// </summary>
    public class EmployeeLocalAllowanceHandler : BaseHandler
    {
        private static EmployeeLocalAllowanceController controller = new EmployeeLocalAllowanceController();


        public object SaveEmployeeLocalAllowance(string employeeLocalAllowance)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeLocalAllowance obj = (new JavaScriptSerializer().Deserialize(employeeLocalAllowance, typeof(EmployeeLocalAllowance))) as EmployeeLocalAllowance;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeLocalAllowance(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeLocalAllowance(string employeeLocalAllowance)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeLocalAllowance search = (new JavaScriptSerializer().Deserialize(employeeLocalAllowance, typeof(EmployeeLocalAllowance))) as EmployeeLocalAllowance;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeLocalAllowance(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}