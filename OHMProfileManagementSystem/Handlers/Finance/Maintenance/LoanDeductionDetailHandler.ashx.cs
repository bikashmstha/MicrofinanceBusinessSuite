using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for LoanDeductionDetailHandler
    /// </summary>
    public class LoanDeductionDetailHandler : BaseHandler
    {
        private static LoanDeductionDetailController controller = new LoanDeductionDetailController();


        public object SaveLoanDeductionDetail(string loanDeductionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDeductionDetail obj = (new JavaScriptSerializer().Deserialize(loanDeductionDetail, typeof(LoanDeductionDetail))) as LoanDeductionDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanDeductionDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanDeductionDetail(string loanDeductionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDeductionDetail search = (new JavaScriptSerializer().Deserialize(loanDeductionDetail, typeof(LoanDeductionDetail))) as LoanDeductionDetail;
            OutMessage oMsg = (OutMessage)controller.SearchLoanDeductionDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanDeductionDtl(string LoanProductCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanDeductionDtl(LoanProductCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}