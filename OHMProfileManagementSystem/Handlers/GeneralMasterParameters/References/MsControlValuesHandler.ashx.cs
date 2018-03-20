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
    /// Summary description for MsControlValuesHandler
    /// </summary>
    public class MsControlValuesHandler : BaseHandler
    {
        public object GetMsControlValues()
        {
            MsControlValuesController controller = new MsControlValuesController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<MsControlValues> lst;

            try
            {
                lst = controller.GetMsControlValues();
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

        public object SaveMsControlValues(string controlValues)
        {
            MsControlValuesController controller = new MsControlValuesController();
            ExtJSResponse resp = new ExtJSResponse();
            MsControlValues objControlValues = (new JavaScriptSerializer().Deserialize(controlValues, typeof(MsControlValues))) as MsControlValues;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveMsControlValues(objControlValues);
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