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
    /// Summary description for EmployeePromotionDetailHandler
    /// </summary>
    public class EmployeePromotionDetailHandler : BaseHandler
    {
        private static EmployeePromotionDetailController controller = new EmployeePromotionDetailController();


        public object SaveEmployeePromotionDetail(string employeePromotionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeePromotionDetail obj = (new JavaScriptSerializer().Deserialize(employeePromotionDetail, typeof(EmployeePromotionDetail))) as EmployeePromotionDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeePromotionDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeePromotionDetail(string employeePromotionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeePromotionDetail search = (new JavaScriptSerializer().Deserialize(employeePromotionDetail, typeof(EmployeePromotionDetail))) as EmployeePromotionDetail;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeePromotionDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpPromotionDetail(string EmpId)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpPromotionDetail(EmpId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}