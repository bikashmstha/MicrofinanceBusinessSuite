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
    /// Summary description for GeneralDefinitionsUtilityHandler
    /// </summary>
    public class GeneralDefinitionsUtilityHandler : BaseHandler
    {
        public object GenerateDateOfNepaliFiscalYear(string fiscalYear)
        {
            GeneralDefinitionsUtilityController controller = new GeneralDefinitionsUtilityController();
            ExtJSResponse resp = new ExtJSResponse();
            //InstallmentPeriod objInstallmentPeriod = (new JavaScriptSerializer().Deserialize(installmentPeriod, typeof(InstallmentPeriod))) as InstallmentPeriod;
            string response = "";
            try
            {
                OutMessage obj = controller.GenerateDateOfNepaliFiscalYear(fiscalYear);
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
        public object GenerateDateOfEnglishFiscalYear(string fiscalYear)
        {
            GeneralDefinitionsUtilityController controller = new GeneralDefinitionsUtilityController();
            ExtJSResponse resp = new ExtJSResponse();
            //InstallmentPeriod objInstallmentPeriod = (new JavaScriptSerializer().Deserialize(installmentPeriod, typeof(InstallmentPeriod))) as InstallmentPeriod;
            string response = "";
            try
            {
                OutMessage obj = controller.GenerateDateOfEnglishFiscalYear(fiscalYear);
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