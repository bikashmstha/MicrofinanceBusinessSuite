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
    /// Summary description for SavingDepositHandler
    /// </summary>
    public class SavingDepositHandler : BaseHandler
    {
        private static SavingDepositController controller = new SavingDepositController();


        public object SaveSavingDeposit(string savingDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingDeposit obj = (new JavaScriptSerializer().Deserialize(savingDeposit, typeof(SavingDeposit))) as SavingDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingDeposit(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingDeposit(string savingDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingDeposit search = (new JavaScriptSerializer().Deserialize(savingDeposit, typeof(SavingDeposit))) as SavingDeposit;
            OutMessage oMsg = (OutMessage)controller.SearchSavingDeposit(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavingDeposit(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavingDeposit(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}