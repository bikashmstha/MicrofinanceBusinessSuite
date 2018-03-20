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

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Menu
{
    /// <summary>
    /// Summary description for MenuEntryHandlerashx
    /// </summary>
    public class MenuEntryHandler : BaseHandler
    {

        public object GetMenuLists(string moduleid,string tabid)
        {
            MenuEntryController controller = new MenuEntryController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<MenuEntry> lst;

            try
            {
                lst = controller.GetMenuLists(moduleid,tabid);
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
        public object SaveMenuEntry(string menuEntry)
        {
            MenuEntryController controller = new MenuEntryController();
            ExtJSResponse resp = new ExtJSResponse();
            MenuEntry objMenuEntry = (new JavaScriptSerializer().Deserialize(menuEntry, typeof(MenuEntry))) as MenuEntry;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveMenuEntry(objMenuEntry);
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