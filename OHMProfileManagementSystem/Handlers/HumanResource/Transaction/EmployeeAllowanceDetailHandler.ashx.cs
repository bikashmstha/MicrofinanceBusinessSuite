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
    /// Summary description for EmployeeAllowanceDetailHandler
    /// </summary>
    public class EmployeeAllowanceDetailHandler : BaseHandler
    {
        private static EmployeeAllowanceDetailController controller = new EmployeeAllowanceDetailController();


        public object SaveEmployeeAllowanceDetail(string employeeAllowanceDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeAllowanceDetail obj = (new JavaScriptSerializer().Deserialize(employeeAllowanceDetail, typeof(EmployeeAllowanceDetail))) as EmployeeAllowanceDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeAllowanceDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeAllowanceDetail(string employeeAllowanceDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeAllowanceDetail search = (new JavaScriptSerializer().Deserialize(employeeAllowanceDetail, typeof(EmployeeAllowanceDetail))) as EmployeeAllowanceDetail;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeAllowanceDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpAllowanceDetail(string EmpId, long? Sno, string FiscalYear)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpAllowanceDetail(EmpId, Sno, FiscalYear);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}