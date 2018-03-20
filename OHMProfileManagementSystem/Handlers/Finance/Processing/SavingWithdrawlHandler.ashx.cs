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
    /// Summary description for SavingWithdrawlHandler
    /// </summary>
    public class SavingWithdrawlHandler : BaseHandler
    {
        private static SavingWithdrawlController controller = new SavingWithdrawlController();


        public object SaveSavingWithdrawl(string savingWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingWithdrawl obj = (new JavaScriptSerializer().Deserialize(savingWithdrawl, typeof(SavingWithdrawl))) as SavingWithdrawl;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingWithdrawl(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingWithdrawl(string savingWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingWithdrawl search = (new JavaScriptSerializer().Deserialize(savingWithdrawl, typeof(SavingWithdrawl))) as SavingWithdrawl;
            OutMessage oMsg = (OutMessage)controller.SearchSavingWithdrawl(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavingWithdrawal(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavingWithdrawal(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}