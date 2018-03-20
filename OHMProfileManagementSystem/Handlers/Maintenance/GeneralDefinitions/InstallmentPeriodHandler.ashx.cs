using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;
using MicrofinanceBusinessSuite.Controllers.Maintenance.GeneralDefinitions;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Maintenance.GeneralDefinitions
{
    /// <summary>
    /// Summary description for InstallmentPeriodHandler
    /// </summary>
    public class InstallmentPeriodHandler : BaseHandler
    {

        public object GetInstallmentPeriod()
        {
            InstallmentPeriodController controller = new InstallmentPeriodController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<InstallmentPeriod> lst;

            try
            {
                lst = controller.GetInstallmentPeriod();
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

        public object SaveInstallmentPeriod(string installmentPeriod)
        {
            InstallmentPeriodController controller = new InstallmentPeriodController();
            ExtJSResponse resp = new ExtJSResponse();
           
            InstallmentPeriod objInstallmentPeriod = (new JavaScriptSerializer().Deserialize(installmentPeriod, typeof(InstallmentPeriod))) as InstallmentPeriod;
            objInstallmentPeriod.CreatedBy = GeneralHelper.UserId;
            objInstallmentPeriod.CreatedOn = GeneralHelper.DateEnglish;
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveInstallmentPeriod(objInstallmentPeriod);
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