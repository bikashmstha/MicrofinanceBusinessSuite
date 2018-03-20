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
    /// Summary description for FiscalYearHandler
    /// </summary>
    public class NepaliFiscalYearHandler : BaseHandler
    {
        public object GetNepaliFiscalYear()
        {

            NepaliFiscalYearController controller = new NepaliFiscalYearController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<NepaliFiscalYear> lst;
            
            try
            {
                lst = controller.GetNepaliFiscalYear();
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

        public object SaveNepaliFiscalYear(string nepaliFiscalYear)
        {
            NepaliFiscalYearController controller = new NepaliFiscalYearController();
            ExtJSResponse resp = new ExtJSResponse();
            NepaliFiscalYear objNarration = (new JavaScriptSerializer().Deserialize(nepaliFiscalYear, typeof(NepaliFiscalYear))) as NepaliFiscalYear;
            objNarration.CreatedBy = GeneralHelper.UserId;
            objNarration.CreatedOn = GeneralHelper.MisDateNepali;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveNepaliFiscalYear(objNarration);
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