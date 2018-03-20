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
    /// Summary description for TabHandler
    /// </summary>
    public class TabHandler : BaseHandler
    {
        public object SearchTab(string tabId, string tabDesc)
        {
            TabController controller = new TabController();
            Tab tab = new Tab();
            tab.TabId = tabId;
            tab.TabDesc = tabDesc;

            List<Tab> lst = controller.SearchTab(tab).ToList();
            return GetResponse(lst);
        }
        private object GetResponse(List<Tab> lst)
        {
            ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }
    }
}