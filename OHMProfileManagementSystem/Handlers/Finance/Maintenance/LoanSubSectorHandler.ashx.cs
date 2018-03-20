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
    /// Summary description for LoanSubSectorHandler
    /// </summary>
    public class LoanSubSectorHandler : BaseHandler
    {
        public object GetLoanSubSector()
        {
            LoanSubSectorController controller = new LoanSubSectorController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanSubSector> lst;

            try
            {
                lst = controller.GetSubLoanSector();
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
        public object SaveLoanSubSector(string loanSubSector)
        {
            LoanSubSectorController controller = new LoanSubSectorController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanSubSector objLoanSubSector = (new JavaScriptSerializer().Deserialize(loanSubSector, typeof(LoanSubSector))) as LoanSubSector;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanSubSector(objLoanSubSector);
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