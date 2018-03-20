using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Loan
{
    /// <summary>
    /// Summary description for LoanPurposeHandler
    /// </summary>
    public class LoanPurposeHandler : BaseHandler
    {
        public object GetLoanPurpose()
        {
            LoanPurposeController controller = new LoanPurposeController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanPurpose> lst;

            try
            {
                lst = controller.GetLoanPurpose();
                resp.Success = "true";
                response = resp.GetResponse(lst, lst.Count);

            }
            catch (Exception ex)
            {
                resp.Success = "false";
                resp.Message = ex.Message;
                response = resp.GetResponse(null, 0);
            }



            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }

        public object SaveLoanPurpose(string loanPurpose)
        {
            LoanPurposeController controller = new LoanPurposeController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanPurpose objLoanPurpose = (new JavaScriptSerializer().Deserialize(loanPurpose, typeof(LoanPurpose))) as LoanPurpose;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanPurpose(objLoanPurpose);
                resp.Success = "true";
                response = resp.GetResponse(obj, 1);

            }
            catch (Exception ex)
            {

                resp.Success = "false";
                resp.Message = ex.Message;
                response = resp.GetResponse(null, 0);
            }
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;

        }

        public object GetMfLoanPurpose(string productCode, string purposeName)
        {
            LoanPurposeController controller = new LoanPurposeController();
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMfLoanPurpose(productCode, purposeName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}