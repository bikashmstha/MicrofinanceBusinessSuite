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
    /// Summary description for BudgetAllocationDetailDetailHandler
    /// </summary>
    public class BudgetAllocationDetailDetailHandler : BaseHandler
    {
        private static BudgetAllocationDetailDetailController controller = new BudgetAllocationDetailDetailController();


        public object SaveBudgetAllocationDetailDetail(string budgetAllocationDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationDetailDetail obj = (new JavaScriptSerializer().Deserialize(budgetAllocationDetailDetail, typeof(BudgetAllocationDetailDetail))) as BudgetAllocationDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveBudgetAllocationDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchBudgetAllocationDetailDetail(string budgetAllocationDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationDetailDetail search = (new JavaScriptSerializer().Deserialize(budgetAllocationDetailDetail, typeof(BudgetAllocationDetailDetail))) as BudgetAllocationDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetAllocationDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetBudAllocDtlDetail(string OfficeCode, string FiscalYear)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetBudAllocDtlDetail(OfficeCode, FiscalYear);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}