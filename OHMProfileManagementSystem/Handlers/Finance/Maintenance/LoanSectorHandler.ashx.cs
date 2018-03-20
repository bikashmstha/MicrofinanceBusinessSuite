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
    /// Summary description for LoanSectorHandler
    /// </summary>
    public class LoanSectorHandler : BaseHandler
    {
        public object GetLoanSector()
        {
            LoanSectorController controller = new LoanSectorController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanSector> lst;

            try
            {
                lst = controller.GetLoanSector();
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

        public object SaveLoanSector(string loanSector)
        {
            LoanSectorController controller = new LoanSectorController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanSector objLoanSector = (new JavaScriptSerializer().Deserialize(loanSector, typeof(LoanSector))) as LoanSector;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanSector(objLoanSector);
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