using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using MicrofinanceBusinessSuite.Controllers.Maintenance;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Maintenance
{
    /// <summary>
    /// Summary description for EthnicityCasteInformationHandler
    /// </summary>
    public class EthnicityCasteInformationHandler : BaseHandler
    {

        public object GetEthnicityCasteInformations(string ethnicityCasteCode)
        {
            EthnicityCasteInformationController controller = new EthnicityCasteInformationController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<EthnicityCasteInformation> lst;

            try
            {
                lst = controller.GetEthnicityCasteInformations(ethnicityCasteCode);
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
        public object SaveEthnicityCasteInformation(string ethnicityCasteInformation)
        {
            EthnicityCasteInformationController controller = new EthnicityCasteInformationController();
            ExtJSResponse resp = new ExtJSResponse();
            EthnicityCasteInformation objEthnicityCasteInformation = (new JavaScriptSerializer().Deserialize(ethnicityCasteInformation, typeof(EthnicityCasteInformation))) as EthnicityCasteInformation;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveEthnicityCasteInformation(objEthnicityCasteInformation);
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