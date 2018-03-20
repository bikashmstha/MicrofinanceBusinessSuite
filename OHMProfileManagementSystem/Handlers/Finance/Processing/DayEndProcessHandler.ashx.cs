using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using MicrofinanceBusinessSuite.Controllers.Finance.Processing;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Processing
{
    /// <summary>
    /// Summary description for DayEndProcessHandler
    /// </summary>
    public class DayEndProcessHandler : BaseHandler
    {
        private static DayEndProcessController controller = new DayEndProcessController();


        public object SaveDayEndProcess(string dayEndProcess)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DayEndProcess obj = (new JavaScriptSerializer().Deserialize(dayEndProcess, typeof(DayEndProcess))) as DayEndProcess;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveDayEndProcess(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchDayEndProcess(string dayEndProcess)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DayEndProcess search = (new JavaScriptSerializer().Deserialize(dayEndProcess, typeof(DayEndProcess))) as DayEndProcess;
            OutMessage oMsg = (OutMessage)controller.SearchDayEndProcess(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}