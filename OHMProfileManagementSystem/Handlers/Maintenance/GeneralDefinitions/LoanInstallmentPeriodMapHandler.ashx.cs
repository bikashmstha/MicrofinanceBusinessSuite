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
    /// Summary description for LoanInstallmentPeriodMapHandler
    /// </summary>
    public class LoanInstallmentPeriodMapHandler : BaseHandler
    {

        public object GetLoanInstallmentPeriodMap()
        {
            LoanInstallmentPeriodMapController controller = new LoanInstallmentPeriodMapController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanInstallmentPeriodMap> lst;

            try
            {
                lst = controller.GetLoanInstallmentPeriodMap();
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

        public object SaveLoanInstallmentPeriodMap(string loanInstallmentPeriodMap)
        {
            LoanInstallmentPeriodMapController controller = new LoanInstallmentPeriodMapController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanInstallmentPeriodMap objLoanInstallmentPeriodMap = (new JavaScriptSerializer().Deserialize(loanInstallmentPeriodMap, typeof(LoanInstallmentPeriodMap))) as LoanInstallmentPeriodMap;
            objLoanInstallmentPeriodMap.CreatedBy = GeneralHelper.UserId;
            objLoanInstallmentPeriodMap.CreatedOn = GeneralHelper.DateEnglish;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanInstallmentPeriodMap(objLoanInstallmentPeriodMap);
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