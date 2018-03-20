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
    /// Summary description for SavingDepositPostingHandler
    /// </summary>
    public class SavingDepositPostingHandler : BaseHandler
    {
        private static SavingDepositPostingController controller = new SavingDepositPostingController();


        public object SaveSavingDepositPosting(string savingDepositPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            List<SavingDepositPosting> lst = (new JavaScriptSerializer().Deserialize(savingDepositPosting, typeof(List<SavingDepositPosting>))) as List<SavingDepositPosting>;
            OutMessage oMsg = (OutMessage)controller.SaveSavingDepositPosting(lst);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingDepositPosting(string savingDepositPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingDepositPosting search = (new JavaScriptSerializer().Deserialize(savingDepositPosting, typeof(SavingDepositPosting))) as SavingDepositPosting;
            OutMessage oMsg = (OutMessage)controller.SearchSavingDepositPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}