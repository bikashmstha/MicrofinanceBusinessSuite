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
    /// Summary description for EthnicityInformationHandler
    /// </summary>
    public class EthnicityInformationHandler : BaseHandler
    {

        public object GetEthnicityInformations()
        {
            EthnicityInformationController controller = new EthnicityInformationController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<EthnicityInformation> lst;

            try
            {
                lst = controller.GetEthnicityInformations();
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
        public object SaveEthnicityInformation(string ethnicityInformation)
        {
            EthnicityInformationController controller = new EthnicityInformationController();
            ExtJSResponse resp = new ExtJSResponse();
            EthnicityInformation objEthnicityInformation = (new JavaScriptSerializer().Deserialize(ethnicityInformation, typeof(EthnicityInformation))) as EthnicityInformation;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveEthnicityInformation(objEthnicityInformation);
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