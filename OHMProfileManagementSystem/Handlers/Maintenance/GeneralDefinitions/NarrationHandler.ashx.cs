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
    /// Summary description for NarrationHandler
    /// </summary>
    public class NarrationHandler : BaseHandler
    {

        public object GetNarrations()
        {
            NarrationController controller = new NarrationController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<Narration> lst;
            
            try
            {
                lst = controller.GetNarrations();
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

        public object SaveNarration(string narration)
        {
            NarrationController controller = new NarrationController();
            ExtJSResponse resp = new ExtJSResponse();
            Narration objNarration = (new JavaScriptSerializer().Deserialize(narration, typeof(Narration))) as Narration;
            objNarration.CreatedBy = GeneralHelper.UserId;
            objNarration.CreatedOn = GeneralHelper.DateEnglish;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveNarration(objNarration);
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