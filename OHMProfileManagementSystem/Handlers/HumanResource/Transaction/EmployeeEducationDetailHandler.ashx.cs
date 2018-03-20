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
    /// Summary description for EmployeeEducationDetailHandler
    /// </summary>
    public class EmployeeEducationDetailHandler : BaseHandler
    {
        private static EmployeeEducationDetailController controller = new EmployeeEducationDetailController();


        public object SaveEmployeeEducationDetail(string employeeEducationDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeEducationDetail obj = (new JavaScriptSerializer().Deserialize(employeeEducationDetail, typeof(EmployeeEducationDetail))) as EmployeeEducationDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeEducationDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeEducationDetail(string employeeEducationDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeEducationDetail search = (new JavaScriptSerializer().Deserialize(employeeEducationDetail, typeof(EmployeeEducationDetail))) as EmployeeEducationDetail;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeEducationDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpEducationDetail(string EmpId)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpEducationDetail(EmpId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}