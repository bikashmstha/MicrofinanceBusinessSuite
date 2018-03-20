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
    /// Summary description for BudgetLimitAmtHandler
    /// </summary>
    public class BudgetLimitAmtHandler : BaseHandler
    {
        private static BudgetLimitAmtController controller = new BudgetLimitAmtController();


        public object SaveBudgetLimitAmt(string budgetLimitAmt)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetLimitAmt obj = (new JavaScriptSerializer().Deserialize(budgetLimitAmt, typeof(BudgetLimitAmt))) as BudgetLimitAmt;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveBudgetLimitAmt(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchBudgetLimitAmt(string budgetLimitAmt)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetLimitAmt search = (new JavaScriptSerializer().Deserialize(budgetLimitAmt, typeof(BudgetLimitAmt))) as BudgetLimitAmt;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetLimitAmt(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetBudgetLimitAmount(string FiscalYear, string TransactionDate, string TranOfficeCode, string AccountCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetBudgetLimitAmount(FiscalYear, TransactionDate, TranOfficeCode, AccountCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}