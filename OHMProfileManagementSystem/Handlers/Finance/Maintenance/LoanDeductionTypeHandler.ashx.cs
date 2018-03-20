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
    /// Summary description for LoanDeductionTypeHandler
    /// </summary>

    public class LoanDeductionTypeHandler : BaseHandler
    {
        private static LoanDeductionTypeController controller = new LoanDeductionTypeController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string loanDeductionType)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDeductionType obj = (new JavaScriptSerializer().Deserialize(loanDeductionType, typeof(LoanDeductionType))) as LoanDeductionType;
            //obj.CreatedBy = GeneralHelper.UserId;
            //obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string loanDeductionType)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanDeductionType search = (new JavaScriptSerializer().Deserialize(loanDeductionType, typeof(LoanDeductionType))) as LoanDeductionType;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanDeduction(string LoanDeductionDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanDeduction(LoanDeductionDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}
