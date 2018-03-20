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
    /// Summary description for EmployeeKycDetailHandler
    /// </summary>
    public class EmployeeKycDetailHandler : BaseHandler
    {
        private static EmployeeKycDetailController controller = new EmployeeKycDetailController();


        public object SaveEmployeeKycDetail(string employeeKycDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycDetail obj = (new JavaScriptSerializer().Deserialize(employeeKycDetail, typeof(EmployeeKycDetail))) as EmployeeKycDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeKycDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeKycDetail(string employeeKycDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycDetail search = (new JavaScriptSerializer().Deserialize(employeeKycDetail, typeof(EmployeeKycDetail))) as EmployeeKycDetail;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeKycDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetEmpKycDetail(string OfficeCode, string ClientCode, string ClientName, string DateFrom, string DateTo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetEmpKycDetail(OfficeCode, ClientCode, ClientName, DateFrom, DateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}