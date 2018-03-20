using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for CompulsoryAccountsEntryHandler
    /// </summary>
    public class CompulsoryAccountsEntryHandler : BaseHandler
    {
        private static CompulsoryAccountsEntryController controller = new CompulsoryAccountsEntryController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string CompulsoryAccountsEntry)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CompulsoryAccountsEntry obj = (new JavaScriptSerializer().Deserialize(CompulsoryAccountsEntry, typeof(CompulsoryAccountsEntry))) as CompulsoryAccountsEntry;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string CompulsoryAccountsEntry)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CompulsoryAccountsEntry search = (new JavaScriptSerializer().Deserialize(CompulsoryAccountsEntry, typeof(CompulsoryAccountsEntry))) as CompulsoryAccountsEntry;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}
