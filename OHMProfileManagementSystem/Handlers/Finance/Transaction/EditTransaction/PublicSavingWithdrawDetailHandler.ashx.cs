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
    /// Summary description for PublicSavingWithdrawDetailHandler
    /// </summary>
    public class PublicSavingWithdrawDetailHandler : BaseHandler
    {
        private static PublicSavingWithdrawDetailController controller = new PublicSavingWithdrawDetailController();


        public object SavePublicSavingWithdrawDetail(string publicSavingWithdrawDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawDetail obj = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawDetail, typeof(PublicSavingWithdrawDetail))) as PublicSavingWithdrawDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingWithdrawDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingWithdrawDetail(string publicSavingWithdrawDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawDetail search = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawDetail, typeof(PublicSavingWithdrawDetail))) as PublicSavingWithdrawDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingWithdrawDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavWithDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavWithDetail(OfficeCode, WithdrawalNo, SavingAccountNo, ClientName, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}