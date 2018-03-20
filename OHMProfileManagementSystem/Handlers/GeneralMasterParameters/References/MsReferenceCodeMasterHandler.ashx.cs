using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.References;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.References
{
    /// <summary>
    /// Summary description for MsReferenceCodeMasterHandler
    /// </summary>
    public class MsReferenceCodeMasterHandler : BaseHandler
    {
        public object GetMsReferenceCodeMaster()
        {
            MSReferenceCodeMasterController controller = new MSReferenceCodeMasterController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<MSReferenceCodeMaster> lst;

            try
            {
                lst = controller.GetMsReferenceCodeMaster();
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

        public object SaveMsReferenceCodeMaster(string referenceValuues)
        {
            MSReferenceCodeMasterController controller = new MSReferenceCodeMasterController();
            ExtJSResponse resp = new ExtJSResponse();
            MSReferenceCodeMaster objMSReferenceCodeMaster = (new JavaScriptSerializer().Deserialize(referenceValuues, typeof(MSReferenceCodeMaster))) as MSReferenceCodeMaster;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveMsReferenceCodeMaster(objMSReferenceCodeMaster);
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