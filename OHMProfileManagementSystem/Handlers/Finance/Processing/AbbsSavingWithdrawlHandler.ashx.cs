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
    /// Summary description for AbbsSavingWithdrawlHandler
    /// </summary>
    public class AbbsSavingWithdrawlHandler : BaseHandler
    {
        private static AbbsSavingWithdrawlController controller = new AbbsSavingWithdrawlController();


        public object SaveAbbsSavingWithdrawl(string abbsSavingWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AbbsSavingWithdrawl obj = (new JavaScriptSerializer().Deserialize(abbsSavingWithdrawl, typeof(AbbsSavingWithdrawl))) as AbbsSavingWithdrawl;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAbbsSavingWithdrawl(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAbbsSavingWithdrawl(string abbsSavingWithdrawl)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AbbsSavingWithdrawl search = (new JavaScriptSerializer().Deserialize(abbsSavingWithdrawl, typeof(AbbsSavingWithdrawl))) as AbbsSavingWithdrawl;
            OutMessage oMsg = (OutMessage)controller.SearchAbbsSavingWithdrawl(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAbbsSavingWithdrawal(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAbbsSavingWithdrawal(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}