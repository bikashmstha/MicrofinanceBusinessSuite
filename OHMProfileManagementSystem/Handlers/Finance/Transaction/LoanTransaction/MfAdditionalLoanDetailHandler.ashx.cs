using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.LoanTransaction
{
    /// <summary>
    /// Summary description for MfAdditionalLoanDetailHandler
    /// </summary>
    public class MfAdditionalLoanDetailHandler : BaseHandler
    {
        private static MfAdditionalLoanDetailController controller = new MfAdditionalLoanDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mfAdditionalLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfAdditionalLoanDetail obj = (new JavaScriptSerializer().Deserialize(mfAdditionalLoanDetail, typeof(MfAdditionalLoanDetail))) as MfAdditionalLoanDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mfAdditionalLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfAdditionalLoanDetail search = (new JavaScriptSerializer().Deserialize(mfAdditionalLoanDetail, typeof(MfAdditionalLoanDetail))) as MfAdditionalLoanDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMfAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMfAdditionalLoanDetail(offCode, clientName, loanNo, dateFrom, dateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}