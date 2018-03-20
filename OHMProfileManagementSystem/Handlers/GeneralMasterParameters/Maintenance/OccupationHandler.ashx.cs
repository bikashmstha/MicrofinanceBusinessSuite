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
    /// Summary description for OccupationHandler
    /// </summary>
    public class OccupationHandler : BaseHandler
    {

        public object GetOccupations()
        {
            OccupationController controller = new OccupationController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<Occupation> lst;

            try
            {
                lst = controller.GetOccupations();
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
        public object SaveOccupation(string occupation)
        {
            OccupationController controller = new OccupationController();
            ExtJSResponse resp = new ExtJSResponse();
            Occupation objOccupation = (new JavaScriptSerializer().Deserialize(occupation, typeof(Occupation))) as Occupation;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveOccupation(objOccupation);
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

        public object GetOccupationLov(string OccupationDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OccupationController controller = new OccupationController();
            OutMessage oMsg = (OutMessage)controller.GetOccupationLov(OccupationDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}