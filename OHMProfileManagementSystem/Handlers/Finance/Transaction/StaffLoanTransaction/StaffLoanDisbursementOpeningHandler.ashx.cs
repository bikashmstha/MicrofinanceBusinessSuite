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
    /// Summary description for StaffLoanDisbursementOpeningHandler
    /// </summary>
    public class StaffLoanDisbursementOpeningHandler : BaseHandler
    {
        private static StaffLoanDisbursementOpeningController controller = new StaffLoanDisbursementOpeningController();


        public object SaveStaffLoanDisbursementOpening(string staffLoanDisbursementOpening)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementOpening obj = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementOpening, typeof(StaffLoanDisbursementOpening))) as StaffLoanDisbursementOpening;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanDisbursementOpening(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanDisbursementOpening(string staffLoanDisbursementOpening)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementOpening search = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementOpening, typeof(StaffLoanDisbursementOpening))) as StaffLoanDisbursementOpening;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanDisbursementOpening(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}