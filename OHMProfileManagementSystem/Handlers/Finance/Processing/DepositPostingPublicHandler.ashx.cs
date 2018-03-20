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
    /// Summary description for DepositPostingPublicHandler
    /// </summary>
    public class DepositPostingPublicHandler : BaseHandler
    {
        private static DepositPostingPublicController controller = new DepositPostingPublicController();


        public object SaveDepositPostingPublic(string depositPostingPublic)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DepositPostingPublic obj = (new JavaScriptSerializer().Deserialize(depositPostingPublic, typeof(DepositPostingPublic))) as DepositPostingPublic;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveDepositPostingPublic(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchDepositPostingPublic(string depositPostingPublic)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DepositPostingPublic search = (new JavaScriptSerializer().Deserialize(depositPostingPublic, typeof(DepositPostingPublic))) as DepositPostingPublic;
            OutMessage oMsg = (OutMessage)controller.SearchDepositPostingPublic(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}