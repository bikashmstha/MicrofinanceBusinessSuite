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
    /// Summary description for BudgetAllocationDetailHandler
    /// </summary>
    public class BudgetAllocationDetailHandler : BaseHandler
    {
        private static BudgetAllocationDetailController controller = new BudgetAllocationDetailController();


        
        public object SearchBudgetAllocationDetail(string budgetAllocationDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationDetail search = (new JavaScriptSerializer().Deserialize(budgetAllocationDetail, typeof(BudgetAllocationDetail))) as BudgetAllocationDetail;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetAllocationDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}