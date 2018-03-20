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
    /// Summary description for WithdrawlPostingPublicHandler
    /// </summary>
    public class WithdrawlPostingPublicHandler : BaseHandler
    {
        private static WithdrawlPostingPublicController controller = new WithdrawlPostingPublicController();


        public object SaveWithdrawlPostingPublic(string withdrawlPostingPublic)
        {
            ExtJSResponse resp = new ExtJSResponse();
            WithdrawlPostingPublic obj = (new JavaScriptSerializer().Deserialize(withdrawlPostingPublic, typeof(WithdrawlPostingPublic))) as WithdrawlPostingPublic;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveWithdrawlPostingPublic(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchWithdrawlPostingPublic(string withdrawlPostingPublic)
        {
            ExtJSResponse resp = new ExtJSResponse();
            WithdrawlPostingPublic search = (new JavaScriptSerializer().Deserialize(withdrawlPostingPublic, typeof(WithdrawlPostingPublic))) as WithdrawlPostingPublic;
            OutMessage oMsg = (OutMessage)controller.SearchWithdrawlPostingPublic(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}