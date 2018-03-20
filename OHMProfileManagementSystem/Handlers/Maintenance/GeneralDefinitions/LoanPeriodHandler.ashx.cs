using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Maintenance.GeneralDefinitions;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Maintenance.GeneralDefinitions
{
    /// <summary>
    /// Summary description for LoanPeriodHandler
    /// </summary>
    public class LoanPeriodHandler : BaseHandler
    {

        public object GetLoanPeriod()
        {
            LoanPeriodController controller = new LoanPeriodController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanPeriod> lst;

            try
            {
                lst = controller.GetLoanPeriod();
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

        public object SaveLoanPeriod(string loanPeriod)
        {
            LoanPeriodController controller = new LoanPeriodController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanPeriod objLoanPeriod = (new JavaScriptSerializer().Deserialize(loanPeriod, typeof(LoanPeriod))) as LoanPeriod;
            objLoanPeriod.CreatedBy = GeneralHelper.UserId;
            objLoanPeriod.CreatedOn = GeneralHelper.DateEnglish;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanPeriod(objLoanPeriod);
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
    }
}