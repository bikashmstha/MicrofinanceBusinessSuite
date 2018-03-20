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
    /// Summary description for LoanAgainstSavingDisbursementHandler
    /// </summary>
    public class LoanAgainstSavingDisbursementHandler : BaseHandler
    {
        private static LoanAgainstSavingDisbursementController controller = new LoanAgainstSavingDisbursementController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string loanAgainstSavingDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanAgainstSavingDisbursement obj = (new JavaScriptSerializer().Deserialize(loanAgainstSavingDisbursement, typeof(LoanAgainstSavingDisbursement))) as LoanAgainstSavingDisbursement;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string loanAgainstSavingDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanAgainstSavingDisbursement search = (new JavaScriptSerializer().Deserialize(loanAgainstSavingDisbursement, typeof(LoanAgainstSavingDisbursement))) as LoanAgainstSavingDisbursement;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}