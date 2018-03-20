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
    /// Summary description for AbbsSavingDepositHandler
    /// </summary>
    public class AbbsSavingDepositHandler : BaseHandler
    {
        private static AbbsSavingDepositController controller = new AbbsSavingDepositController();


        public object SaveAbbsSavingDeposit(string abbsSavingDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AbbsSavingDeposit obj = (new JavaScriptSerializer().Deserialize(abbsSavingDeposit, typeof(AbbsSavingDeposit))) as AbbsSavingDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAbbsSavingDeposit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAbbsSavingDeposit(string abbsSavingDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AbbsSavingDeposit search = (new JavaScriptSerializer().Deserialize(abbsSavingDeposit, typeof(AbbsSavingDeposit))) as AbbsSavingDeposit;
            OutMessage oMsg = (OutMessage)controller.SearchAbbsSavingDeposit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAbbsSavingDeposit(string OfficeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAbbsSavingDeposit(OfficeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}