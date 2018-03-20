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
    /// Summary description for PublicSavingAccountClosureHandler
    /// </summary>
    public class PublicSavingAccountClosureHandler : BaseHandler
    {
        private static PublicSavingAccountClosureController controller = new PublicSavingAccountClosureController();


        public object SavePublicSavingAccountClosure(string publicSavingAccountClosure)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingAccountClosure obj = (new JavaScriptSerializer().Deserialize(publicSavingAccountClosure, typeof(PublicSavingAccountClosure))) as PublicSavingAccountClosure;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingAccountClosure(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object DeletePublicSavingAccountClosure(string accountNo, string accountClosedDate, string otherIncomeVoucherNo, string username)
        {


            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.DeletePublicSavingAccountClosure(accountNo, accountClosedDate, otherIncomeVoucherNo, username);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        


    }
}