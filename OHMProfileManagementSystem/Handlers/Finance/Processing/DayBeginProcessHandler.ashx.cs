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
    /// Summary description for DayBeginProcessHandler
    /// </summary>
    public class DayBeginProcessHandler : BaseHandler
    {
        private static DayBeginProcessController controller = new DayBeginProcessController();


        public object SaveDayBeginProcess(string dayBeginProcess)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DayBeginProcess obj = (new JavaScriptSerializer().Deserialize(dayBeginProcess, typeof(DayBeginProcess))) as DayBeginProcess;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveDayBeginProcess(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchDayBeginProcess(string dayBeginProcess)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DayBeginProcess search = (new JavaScriptSerializer().Deserialize(dayBeginProcess, typeof(DayBeginProcess))) as DayBeginProcess;
            OutMessage oMsg = (OutMessage)controller.SearchDayBeginProcess(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}