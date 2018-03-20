using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for BudgetAllocationShareHandler
    /// </summary>
    public class BudgetAllocationShareHandler : BaseHandler
    {
        private static BudgetAllocationShareController controller = new BudgetAllocationShareController();


        public object SaveBudgetAllocationShare(string budgetAllocationShare)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationShare obj = (new JavaScriptSerializer().Deserialize(budgetAllocationShare, typeof(BudgetAllocationShare))) as BudgetAllocationShare;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveBudgetAllocationShare(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchBudgetAllocationShare(string budgetAllocationShare)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationShare search = (new JavaScriptSerializer().Deserialize(budgetAllocationShare, typeof(BudgetAllocationShare))) as BudgetAllocationShare;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetAllocationShare(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

    }
}