using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.EditTransaction
{
    /// <summary>
    /// Summary description for AdjustmentaccountforwithdrawHandler
    /// </summary>
    public class AdjustmentaccountforwithdrawHandler : BaseHandler
    {
        private static AdjustmentaccountforwithdrawController controller = new AdjustmentaccountforwithdrawController();


        public object SaveAdjustmentaccountforwithdraw(string AdjustmentAccountForWithdraw)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Adjustmentaccountforwithdraw obj = (new JavaScriptSerializer().Deserialize(AdjustmentAccountForWithdraw, typeof(Adjustmentaccountforwithdraw))) as Adjustmentaccountforwithdraw;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveAdjustmentaccountforwithdraw(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchAdjustmentaccountforwithdraw(string AdjustmentAccountForWithdraw)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Adjustmentaccountforwithdraw search = (new JavaScriptSerializer().Deserialize(AdjustmentAccountForWithdraw, typeof(Adjustmentaccountforwithdraw))) as Adjustmentaccountforwithdraw;
            OutMessage oMsg = (OutMessage)controller.SearchAdjustmentaccountforwithdraw(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetAdjAccForWithdraw(string OfficeCode, string ProductCode, string SavingAccountNo, string CenterCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetAdjAccForWithdraw(OfficeCode, ProductCode, SavingAccountNo, CenterCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}