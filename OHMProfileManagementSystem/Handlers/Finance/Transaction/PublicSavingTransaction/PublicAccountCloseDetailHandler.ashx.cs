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
    /// Summary description for PublicAccountCloseDetailHandler
    /// </summary>
    public class PublicAccountCloseDetailHandler : BaseHandler
    {
        private static PublicAccountCloseDetailController controller = new PublicAccountCloseDetailController();


        public object SavePublicAccountCloseDetail(string publicAccountCloseDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCloseDetail obj = (new JavaScriptSerializer().Deserialize(publicAccountCloseDetail, typeof(PublicAccountCloseDetail))) as PublicAccountCloseDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAccountCloseDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAccountCloseDetail(string publicAccountCloseDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCloseDetail search = (new JavaScriptSerializer().Deserialize(publicAccountCloseDetail, typeof(PublicAccountCloseDetail))) as PublicAccountCloseDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAccountCloseDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAccCloseDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAccCloseDetail(OfficeCode, WithdrawalNo, SavingAccountNo, ClientName, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}