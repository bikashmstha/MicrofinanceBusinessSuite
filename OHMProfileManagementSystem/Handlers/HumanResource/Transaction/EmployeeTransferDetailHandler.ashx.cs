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
    /// Summary description for EmployeeTransferDetailHandler
    /// </summary>
    public class EmployeeTransferDetailHandler : BaseHandler
    {
        private static EmployeeTransferDetailController controller = new EmployeeTransferDetailController();


        public object SaveEmployeeTransferDetail(string employeeTransferDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTransferDetail obj = (new JavaScriptSerializer().Deserialize(employeeTransferDetail, typeof(EmployeeTransferDetail))) as EmployeeTransferDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeTransferDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeTransferDetail(string employeeTransferDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTransferDetail search = (new JavaScriptSerializer().Deserialize(employeeTransferDetail, typeof(EmployeeTransferDetail))) as EmployeeTransferDetail;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeTransferDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpTransferDetail(string EmpId)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpTransferDetail(EmpId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}