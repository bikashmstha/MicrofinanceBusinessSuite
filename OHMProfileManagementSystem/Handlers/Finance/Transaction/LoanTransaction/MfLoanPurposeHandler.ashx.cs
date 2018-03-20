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
    /// Summary description for MfLoanPurposeHandler
    /// </summary>
    public class MfLoanPurposeHandler : BaseHandler
    {
        private static MfLoanPurposeController controller = new MfLoanPurposeController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mfLoanPurpose)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfLoanPurpose obj = (new JavaScriptSerializer().Deserialize(mfLoanPurpose, typeof(MfLoanPurpose))) as MfLoanPurpose;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mfLoanPurpose)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfLoanPurpose search = (new JavaScriptSerializer().Deserialize(mfLoanPurpose, typeof(MfLoanPurpose))) as MfLoanPurpose;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanProduct(string productCode, string purposeName)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanProduct(productCode, purposeName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}