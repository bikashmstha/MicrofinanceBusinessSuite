using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for RegenerateFiscalYearClosingHandler
    /// </summary>
    public class RegenerateFiscalYearClosingHandler : BaseHandler
    {
        private static RegenerateFiscalYearClosingController controller = new RegenerateFiscalYearClosingController();


        public object SaveRegenerateFiscalYearClosing(string regenerateFiscalYearClosing)
        {
            ExtJSResponse resp = new ExtJSResponse();
            RegenerateFiscalYearClosing obj = (new JavaScriptSerializer().Deserialize(regenerateFiscalYearClosing, typeof(RegenerateFiscalYearClosing))) as RegenerateFiscalYearClosing;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveRegenerateFiscalYearClosing(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchRegenerateFiscalYearClosing(string regenerateFiscalYearClosing)
        {
            ExtJSResponse resp = new ExtJSResponse();
            RegenerateFiscalYearClosing search = (new JavaScriptSerializer().Deserialize(regenerateFiscalYearClosing, typeof(RegenerateFiscalYearClosing))) as RegenerateFiscalYearClosing;
            OutMessage oMsg = (OutMessage)controller.SearchRegenerateFiscalYearClosing(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}