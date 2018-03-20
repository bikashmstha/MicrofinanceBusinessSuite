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
    /// Summary description for LoanProductPeriodMapHandler
    /// </summary>
    public class LoanProductPeriodMapHandler : BaseHandler
    {

        public object GetLoanProductPeriodMap(string loanProductCode)
        {
            LoanProductPeriodMapController controller = new LoanProductPeriodMapController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanProductPeriodMap> lst;

            try
            {
                lst = controller.GetLoanProductPeriodMap(loanProductCode);
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

        public object SaveLoanProductPeriodMap(string loanProductPeriodMap)
        {
            LoanProductPeriodMapController controller = new LoanProductPeriodMapController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanProductPeriodMap objLoanProductPeriodMap = (new JavaScriptSerializer().Deserialize(loanProductPeriodMap, typeof(LoanProductPeriodMap))) as LoanProductPeriodMap;
            objLoanProductPeriodMap.CreatedBy = GeneralHelper.UserId;
            objLoanProductPeriodMap.CreatedOn = GeneralHelper.DateEnglish;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanProductPeriodMap(objLoanProductPeriodMap);
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