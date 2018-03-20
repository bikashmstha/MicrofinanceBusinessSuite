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
    /// Summary description for MfLoanRepaymentHandler
    /// </summary>
    public class MfLoanRepaymentHandler : BaseHandler
    {
        private static MfLoanRepaymentController controller = new MfLoanRepaymentController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mfLoanRepayment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfRepayLoan obj = (new JavaScriptSerializer().Deserialize(mfLoanRepayment, typeof(MfRepayLoan))) as MfRepayLoan;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mfLoanRepayment)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfRepayLoan search = (new JavaScriptSerializer().Deserialize(mfLoanRepayment, typeof(MfRepayLoan))) as MfRepayLoan;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object SaveLoanRepayment(string mfLoanRepayment)
        {

            ExtJSResponse resp = new ExtJSResponse();
            MfLoanRepayment obj = (new JavaScriptSerializer().Deserialize(mfLoanRepayment, typeof(MfLoanRepayment))) as MfLoanRepayment;
            OutMessage oMsg = (OutMessage)controller.SaveLoanRepayment(obj);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMfRepayLoan(string offCode, string centerCode, string productCode, string clientName)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMfRepayLoan(offCode, centerCode, productCode, clientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}