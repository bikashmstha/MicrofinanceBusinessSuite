using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.LoanTransaction
{
    /// <summary>
    /// Summary description for LoanUtilizationEntryHandler
    /// </summary>
    public class LoanUtilizationEntryHandler : BaseHandler
    {
        private static LoanUtilizationEntryController controller = new LoanUtilizationEntryController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string loanUtilizationEntry)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanUtilizationEntry obj = (new JavaScriptSerializer().Deserialize(loanUtilizationEntry, typeof(LoanUtilizationEntry))) as LoanUtilizationEntry;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string loanUtilizationEntry)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanUtilizationEntry search = (new JavaScriptSerializer().Deserialize(loanUtilizationEntry, typeof(LoanUtilizationEntry))) as LoanUtilizationEntry;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}