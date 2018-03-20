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
    /// Summary description for EmployeeKycInfoHandler
    /// </summary>
    public class EmployeeKycInfoHandler : BaseHandler
    {
        private static EmployeeKycInfoController controller = new EmployeeKycInfoController();


        public object SaveEmployeeKycInfo(string employeeKycInfo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycInfo obj = (new JavaScriptSerializer().Deserialize(employeeKycInfo, typeof(EmployeeKycInfo))) as EmployeeKycInfo;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeKycInfo(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeKycInfo(string employeeKycInfo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeKycInfo search = (new JavaScriptSerializer().Deserialize(employeeKycInfo, typeof(EmployeeKycInfo))) as EmployeeKycInfo;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeKycInfo(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}