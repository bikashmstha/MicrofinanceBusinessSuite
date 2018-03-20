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
    /// Summary description for EmployeeAllowanceAmountHandler
    /// </summary>
    public class EmployeeAllowanceAmountHandler : BaseHandler
    {
        private static EmployeeAllowanceAmountController controller = new EmployeeAllowanceAmountController();


        public object SaveEmployeeAllowanceAmount(string employeeAllowanceAmount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeAllowanceAmount obj = (new JavaScriptSerializer().Deserialize(employeeAllowanceAmount, typeof(EmployeeAllowanceAmount))) as EmployeeAllowanceAmount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeAllowanceAmount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeAllowanceAmount(string employeeAllowanceAmount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeAllowanceAmount search = (new JavaScriptSerializer().Deserialize(employeeAllowanceAmount, typeof(EmployeeAllowanceAmount))) as EmployeeAllowanceAmount;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeAllowanceAmount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpAllowanceAmt(long Sno, string FiscalYear, string PostCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpAllowanceAmt(Sno, FiscalYear, PostCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}