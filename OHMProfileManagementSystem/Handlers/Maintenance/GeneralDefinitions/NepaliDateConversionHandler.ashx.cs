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
    /// Summary description for NepaliDateConversionHandler
    /// </summary>
    public class NepaliDateConversionHandler : BaseHandler
    {

        public object GetNepaliDateConversion()
        {
            NepaliDateConversionController controller = new NepaliDateConversionController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<NepaliDateConversion> lst;

            try
            {
                lst = controller.GetNepaliDateConversions();
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

        public object SaveNepaliDateConversion(string nepaliDateConversion)
        {
            NepaliDateConversionController controller = new NepaliDateConversionController();
            ExtJSResponse resp = new ExtJSResponse();
            NepaliDateConversion objNepaliDateConversion = (new JavaScriptSerializer().Deserialize(nepaliDateConversion, typeof(NepaliDateConversion))) as NepaliDateConversion;
            objNepaliDateConversion.CreatedBy = GeneralHelper.UserId;
            objNepaliDateConversion.CreatedOn = GeneralHelper.DateEnglish;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveNepaliDateConversion(objNepaliDateConversion);
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