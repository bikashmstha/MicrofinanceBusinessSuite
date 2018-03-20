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
    /// Summary description for EmployeeTrainingDetailHandler
    /// </summary>
    public class EmployeeTrainingDetailHandler : BaseHandler
    {
        private static EmployeeTrainingDetailController controller = new EmployeeTrainingDetailController();


        public object SaveEmployeeTrainingDetail(string employeeTrainingDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTrainingDetail obj = (new JavaScriptSerializer().Deserialize(employeeTrainingDetail, typeof(EmployeeTrainingDetail))) as EmployeeTrainingDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeTrainingDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeTrainingDetail(string employeeTrainingDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTrainingDetail search = (new JavaScriptSerializer().Deserialize(employeeTrainingDetail, typeof(EmployeeTrainingDetail))) as EmployeeTrainingDetail;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeTrainingDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpTrainingDetail(string EmpId)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpTrainingDetail(EmpId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}