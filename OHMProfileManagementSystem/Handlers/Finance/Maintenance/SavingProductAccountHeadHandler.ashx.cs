using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for SavingProductAccountHeadHandler
    /// </summary>
    public class SavingProductAccountHeadHandler : BaseHandler
    {
        private static SavingProductAccountHeadController controller = new SavingProductAccountHeadController();


        public object SaveSavingProductAccountHead(string savingProductAccountHead)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingProductAccountHead obj = (new JavaScriptSerializer().Deserialize(savingProductAccountHead, typeof(SavingProductAccountHead))) as SavingProductAccountHead;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingProductAccountHead(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingProductAccountHead(string savingProductAccountHead)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingProductAccountHead search = (new JavaScriptSerializer().Deserialize(savingProductAccountHead, typeof(SavingProductAccountHead))) as SavingProductAccountHead;
            OutMessage oMsg = (OutMessage)controller.SearchSavingProductAccountHead(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavingProAccHead(string AccountDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavingProAccHead(AccountDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}