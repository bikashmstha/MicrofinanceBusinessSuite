using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.StaffLoanTransaction
{
    /// <summary>
    /// Summary description for EmployeeKycEmployeeHandler
    /// </summary>
    public class EmployeeKycEmployeeHandler : BaseHandler
    {
        private static EmployeeKycEmployeeController controller = new EmployeeKycEmployeeController();


        public object SaveEmployeeKycEmployee(string employeeKycEmployee)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycEmployee obj = (new JavaScriptSerializer().Deserialize(employeeKycEmployee, typeof(EmployeeKycEmployee))) as EmployeeKycEmployee;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeKycEmployee(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeKycEmployee(string employeeKycEmployee)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycEmployee search = (new JavaScriptSerializer().Deserialize(employeeKycEmployee, typeof(EmployeeKycEmployee))) as EmployeeKycEmployee;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeKycEmployee(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpKycEmp(string OfficeCode, string EmpName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpKycEmp(OfficeCode, EmpName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}