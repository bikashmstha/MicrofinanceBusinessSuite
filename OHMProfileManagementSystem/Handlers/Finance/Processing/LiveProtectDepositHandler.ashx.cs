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
    /// Summary description for LiveProtectDepositHandler
    /// </summary>
    public class LiveProtectDepositHandler : BaseHandler
    {
        private static LiveProtectDepositController controller = new LiveProtectDepositController();


        public object SaveLiveProtectDeposit(string LiveProtectDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LiveProtectDeposit obj = (new JavaScriptSerializer().Deserialize(LiveProtectDeposit, typeof(LiveProtectDeposit))) as LiveProtectDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLiveProtectDeposit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLiveProtectDeposit(string LiveProtectDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LiveProtectDeposit search = (new JavaScriptSerializer().Deserialize(LiveProtectDeposit, typeof(LiveProtectDeposit))) as LiveProtectDeposit;
            OutMessage oMsg = (OutMessage)controller.SearchLiveProtectDeposit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLiveProtectDeposit(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLiveProtectDeposit(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}