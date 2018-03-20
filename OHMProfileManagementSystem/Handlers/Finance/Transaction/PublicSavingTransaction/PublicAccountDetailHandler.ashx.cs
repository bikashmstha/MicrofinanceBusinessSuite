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
    /// Summary description for PublicAccountDetailHandler
    /// </summary>
    public class PublicAccountDetailHandler : BaseHandler
    {
        private static PublicAccountDetailController controller = new PublicAccountDetailController();


        public object SavePublicAccountDetail(string publicAccountDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountDetail obj = (new JavaScriptSerializer().Deserialize(publicAccountDetail, typeof(PublicAccountDetail))) as PublicAccountDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAccountDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAccountDetail(string publicAccountDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountDetail search = (new JavaScriptSerializer().Deserialize(publicAccountDetail, typeof(PublicAccountDetail))) as PublicAccountDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAccountDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAccDetail(string OfficeCode, string ClientNo, string SavingAccountNo, string ClientName, string ProductClass, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAccDetail(OfficeCode, ClientNo, SavingAccountNo, ClientName, ProductClass, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}