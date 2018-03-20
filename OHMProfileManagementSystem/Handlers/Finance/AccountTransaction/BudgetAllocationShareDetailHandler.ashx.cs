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
    /// Summary description for BudgetAllocationShareDetailHandler
    /// </summary>
    public class BudgetAllocationShareDetailHandler : BaseHandler
    {
        private static BudgetAllocationShareDetailController controller = new BudgetAllocationShareDetailController();


        public object SaveBudgetAllocationShareDetail(string budgetAllocationShareDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationShareDetail obj = (new JavaScriptSerializer().Deserialize(budgetAllocationShareDetail, typeof(BudgetAllocationShareDetail))) as BudgetAllocationShareDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveBudgetAllocationShareDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchBudgetAllocationShareDetail(string budgetAllocationShareDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationShareDetail search = (new JavaScriptSerializer().Deserialize(budgetAllocationShareDetail, typeof(BudgetAllocationShareDetail))) as BudgetAllocationShareDetail;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetAllocationShareDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetBudAllocShareDetail(string OfficeCode, string FiscalYear, string AccountCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetBudAllocShareDetail(OfficeCode, FiscalYear, AccountCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}