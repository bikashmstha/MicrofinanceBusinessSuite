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
    /// Summary description for GroupEntryHandler
    /// </summary>
    public class GroupHandler: BaseHandler
    {
        private static GroupsController controller = new GroupsController();

        //public object GetGroups()
        //{
        //    GroupController controller = new GroupController();
        //    List<Group> lst = controller.GetGroups().ToList();
        //    return GetResponse(lst);
        //}
        public object SaveGroup(string group)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Group grp = (new JavaScriptSerializer().Deserialize(group, typeof(Group))) as Group;

            string success = controller.SaveGroup(grp);
           
            string response = resp.GetResponse(new List<Group>(), 0);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }

        public object SearchGroup(string group)
        {
            Group search = (new JavaScriptSerializer().Deserialize(group, typeof(Group))) as Group;
           object obj = controller.SearchGroup(search);
            return GetResponse(obj as List<Group>);
        }

        private object GetResponse(List<Group> lst)
        {
            ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }
        
    }
}