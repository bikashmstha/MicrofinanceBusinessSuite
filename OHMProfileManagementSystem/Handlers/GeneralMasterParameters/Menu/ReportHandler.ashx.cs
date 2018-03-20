using App.Utilities.Web.Handlers;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MicrofinanceBusinessSuite.Controllers.Common;
namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Menu
{
    /// <summary>
    /// Summary description for ReportHandler
    /// </summary>
    public class ReportHandler : BaseHandler
    {

        public object GetReportShort(string moduleId, string tabId)
        {
            ReportController controller = new ReportController();
            
            List<Report> lst = controller.GetReportShort(moduleId,tabId).ToList();
            return GetResponse(lst);
        }
        private object GetResponse(List<Report> lst)
        {
            ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }
    }
}