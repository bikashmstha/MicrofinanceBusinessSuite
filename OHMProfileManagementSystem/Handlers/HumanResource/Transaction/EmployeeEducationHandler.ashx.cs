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
    /// Summary description for EmployeeEducationHandler
    /// </summary>
    public class EmployeeEducationHandler : BaseHandler
    {
        private static EmployeeEducationController controller = new EmployeeEducationController();


        public object SaveEmployeeEducation(string employeeEducation)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeEducation obj = (new JavaScriptSerializer().Deserialize(employeeEducation, typeof(EmployeeEducation))) as EmployeeEducation;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeEducation(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeEducation(string employeeEducation)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeEducation search = (new JavaScriptSerializer().Deserialize(employeeEducation, typeof(EmployeeEducation))) as EmployeeEducation;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeEducation(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}