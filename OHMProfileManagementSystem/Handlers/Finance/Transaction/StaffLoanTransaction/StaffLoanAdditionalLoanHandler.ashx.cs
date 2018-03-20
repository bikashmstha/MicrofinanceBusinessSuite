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
    /// Summary description for StaffLoanAdditionalLoanHandler
    /// </summary>
    public class StaffLoanAdditionalLoanHandler : BaseHandler
    {
        private static StaffLoanAdditionalLoanController controller = new StaffLoanAdditionalLoanController();


        public object SaveStaffLoanAdditionalLoan(string staffLoanAdditionalLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanAdditionalLoan obj = (new JavaScriptSerializer().Deserialize(staffLoanAdditionalLoan, typeof(StaffLoanAdditionalLoan))) as StaffLoanAdditionalLoan;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanAdditionalLoan(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanAdditionalLoan(string staffLoanAdditionalLoan)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanAdditionalLoan search = (new JavaScriptSerializer().Deserialize(staffLoanAdditionalLoan, typeof(StaffLoanAdditionalLoan))) as StaffLoanAdditionalLoan;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanAdditionalLoan(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanAddLoan(string OfficeCode, string ProductCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanAddLoan(OfficeCode, ProductCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}