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
    /// Summary description for EmployeeKycClientHandler
    /// </summary>
    public class EmployeeKycClientHandler : BaseHandler
    {
        private static EmployeeKycClientController controller = new EmployeeKycClientController();


        public object SaveEmployeeKycClient(string employeeKycClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycClient obj = (new JavaScriptSerializer().Deserialize(employeeKycClient, typeof(EmployeeKycClient))) as EmployeeKycClient;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeKycClient(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeKycClient(string employeeKycClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycClient search = (new JavaScriptSerializer().Deserialize(employeeKycClient, typeof(EmployeeKycClient))) as EmployeeKycClient;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeKycClient(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpKycClientSearch(string OfficeCode, string EmpName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpKycClientSearch(OfficeCode, EmpName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}