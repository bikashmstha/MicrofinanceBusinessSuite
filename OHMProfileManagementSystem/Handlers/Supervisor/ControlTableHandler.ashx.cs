using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Supervisor;
using MicrofinanceBusinessSuite.Controllers.Supervisor;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Supervisor
{
    /// <summary>
    /// Summary description for ControlTableHandler
    /// </summary>
    public class ControlTableHandler : BaseHandler
    {

        public object GetControlTable()
        {
            ControlTableController controller = new ControlTableController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<ControlTable> lst;

            try
            {
                lst = controller.GetControlTable();
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

        public object SaveControlTable(string controlTable)
        {
            ControlTableController controller = new ControlTableController();
            ExtJSResponse resp = new ExtJSResponse();
            ControlTable objControlTable = (new JavaScriptSerializer().Deserialize(controlTable, typeof(ControlTable))) as ControlTable;
            objControlTable.CreatedBy = GeneralHelper.UserId;
            objControlTable.CreatedOn = GeneralHelper.MisDateNepali;
            
            
            string response = "";
            try
            {
                OutMessage obj = controller.SaveControlTable(objControlTable);
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