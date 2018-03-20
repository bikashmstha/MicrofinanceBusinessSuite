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
    /// Summary description for StaffLoanDisbursementClientHandler
    /// </summary>
    public class StaffLoanDisbursementClientHandler : BaseHandler
    {
        private static StaffLoanDisbursementClientController controller = new StaffLoanDisbursementClientController();


        public object SaveStaffLoanDisbursementClient(string staffLoanDisbursementClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementClient obj = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementClient, typeof(StaffLoanDisbursementClient))) as StaffLoanDisbursementClient;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanDisbursementClient(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanDisbursementClient(string staffLoanDisbursementClient)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementClient search = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementClient, typeof(StaffLoanDisbursementClient))) as StaffLoanDisbursementClient;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanDisbursementClient(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanDisClient(string OfficeCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanDisClient(OfficeCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}