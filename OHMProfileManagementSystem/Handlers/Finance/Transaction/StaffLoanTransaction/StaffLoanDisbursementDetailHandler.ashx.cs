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
    /// Summary description for StaffLoanDisbursementDetailHandler
    /// </summary>
    public class StaffLoanDisbursementDetailHandler : BaseHandler
    {
        private static StaffLoanDisbursementDetailController controller = new StaffLoanDisbursementDetailController();


        public object SaveStaffLoanDisbursementDetail(string staffLoanDisbursementDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementDetail obj = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementDetail, typeof(StaffLoanDisbursementDetail))) as StaffLoanDisbursementDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanDisbursementDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanDisbursementDetail(string staffLoanDisbursementDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementDetail search = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementDetail, typeof(StaffLoanDisbursementDetail))) as StaffLoanDisbursementDetail;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanDisbursementDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanDisDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanDisDetail(OfficeCode, LoanNo, ClientName, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}