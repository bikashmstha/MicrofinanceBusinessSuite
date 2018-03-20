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
    /// Summary description for MfAdditionalLoanDisbursementHandler
    /// </summary>
    public class MfAdditionalLoanDisbursementHandler : BaseHandler
    {
        private static MfAdditionalLoanDisbursementController controller = new MfAdditionalLoanDisbursementController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mfAdditionalLoanDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfAdditionalLoanDisbursement obj = (new JavaScriptSerializer().Deserialize(mfAdditionalLoanDisbursement, typeof(MfAdditionalLoanDisbursement))) as MfAdditionalLoanDisbursement;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mfAdditionalLoanDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfAdditionalLoanDisbursement search = (new JavaScriptSerializer().Deserialize(mfAdditionalLoanDisbursement, typeof(MfAdditionalLoanDisbursement))) as MfAdditionalLoanDisbursement;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}