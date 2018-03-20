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
    /// Summary description for BudgetAllocationAccountHandler
    /// </summary>
    public class BudgetAllocationAccountHandler : BaseHandler
    {
        private static BudgetAllocationAccountController controller = new BudgetAllocationAccountController();


        public object SaveBudgetAllocationAccount(string budgetAllocationAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationAccount obj = (new JavaScriptSerializer().Deserialize(budgetAllocationAccount, typeof(BudgetAllocationAccount))) as BudgetAllocationAccount;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveBudgetAllocationAccount(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchBudgetAllocationAccount(string budgetAllocationAccount)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationAccount search = (new JavaScriptSerializer().Deserialize(budgetAllocationAccount, typeof(BudgetAllocationAccount))) as BudgetAllocationAccount;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetAllocationAccount(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetBudAllocAcc(string AccountDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetBudAllocAcc(AccountDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}