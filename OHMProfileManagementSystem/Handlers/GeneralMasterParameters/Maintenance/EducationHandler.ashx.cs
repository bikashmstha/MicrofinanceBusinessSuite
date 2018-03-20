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
    /// Summary description for EducationHandler
    /// </summary>
    public class EducationHandler : BaseHandler
    {

        public object GetEducations()
        {
            EducationController controller = new EducationController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<Education> lst;

            try
            {
                lst = controller.GetEducations();
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

        public object GetEducationLov(string educationDesc)
        {
            EducationController controller = new EducationController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<Education> lst;

            try
            {
                lst = controller.GetEducationLov(educationDesc);
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
        public object SaveEducation(string education)
        {
            EducationController controller = new EducationController();
            ExtJSResponse resp = new ExtJSResponse();
            Education objEducation = (new JavaScriptSerializer().Deserialize(education, typeof(Education))) as Education;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveEducation(objEducation);
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