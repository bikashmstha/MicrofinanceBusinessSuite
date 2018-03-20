using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Maintenance;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Maintenance
{
    /// <summary>
    /// Summary description for OfficeWiseHolidayHandler
    /// </summary>
    public class OfficeWiseHolidayHandler : BaseHandler
    {

        private static OfficeWiseHolidayController controller = new OfficeWiseHolidayController();
        public object Get(string offCode,string startDate, string endDate)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get(offCode,startDate, endDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string officeWiseHoliday)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OfficeWiseHoliday obj = (new JavaScriptSerializer().Deserialize(officeWiseHoliday, typeof(OfficeWiseHoliday))) as OfficeWiseHoliday;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;

            OutMessage oMsg = (OutMessage)controller.Save(obj);

            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string officeWiseHoliday)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OfficeWiseHoliday search = (new JavaScriptSerializer().Deserialize(officeWiseHoliday, typeof(OfficeWiseHoliday))) as OfficeWiseHoliday;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}