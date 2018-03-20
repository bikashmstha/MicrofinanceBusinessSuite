using App.Utilities.Web.Handlers;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters
{
    /// <summary>
    /// Summary description for OfficeHandler
    /// </summary>
    public class OfficeTypeHandler : BaseHandler
    {
        public object GetOfficeTypes()
        {
            OfficeTypeController controller = new OfficeTypeController();
            List<OfficeType> lst = controller.GetOfficeTypes().ToList();
            return GetResponse(lst);
        }
        

        private object GetResponse(List<OfficeType> lst)
        {
            ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }
        
    }
}