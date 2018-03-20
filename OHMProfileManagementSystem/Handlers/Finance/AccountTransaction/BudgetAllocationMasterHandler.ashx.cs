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
    /// Summary description for BudgetAllocationMasterHandler
    /// </summary>
    public class BudgetAllocationMasterHandler : BaseHandler
    {
        private static BudgetAllocationMasterController controller = new BudgetAllocationMasterController();


        public object SaveBudgetAllocationMaster(string budgetAllocationMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationMaster obj = (new JavaScriptSerializer().Deserialize(budgetAllocationMaster, typeof(BudgetAllocationMaster))) as BudgetAllocationMaster;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveBudgetAllocationMaster(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchBudgetAllocationMaster(string budgetAllocationMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            BudgetAllocationMaster search = (new JavaScriptSerializer().Deserialize(budgetAllocationMaster, typeof(BudgetAllocationMaster))) as BudgetAllocationMaster;
            OutMessage oMsg = (OutMessage)controller.SearchBudgetAllocationMaster(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

    }
}