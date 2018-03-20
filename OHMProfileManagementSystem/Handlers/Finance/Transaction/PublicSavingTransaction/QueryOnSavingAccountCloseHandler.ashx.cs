using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.PublicSavingTransaction
{
    /// <summary>
    /// Summary description for QueryOnSavingAccountCloseHandler
    /// </summary>
    public class QueryOnSavingAccountCloseHandler : BaseHandler
    {
        private static QueryOnSavingAccountCloseController controller = new QueryOnSavingAccountCloseController();


       

        public object GetQueryOnSavingAcClose(string AccountNo, string SavingProductCode, string WithdrawDate, string Username)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetQueryOnSavingAcClose(AccountNo, SavingProductCode, WithdrawDate, Username);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}