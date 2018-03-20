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
    /// Summary description for PublicClientDetailHandler
    /// </summary>
    public class PublicClientDetailHandler : BaseHandler
    {
        private static PublicClientDetailController controller = new PublicClientDetailController();


        public object SavePublicClientDetail(string publicClientDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicClientDetail obj = (new JavaScriptSerializer().Deserialize(publicClientDetail, typeof(PublicClientDetail))) as PublicClientDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicClientDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicClientDetail(string publicClientDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicClientDetail search = (new JavaScriptSerializer().Deserialize(publicClientDetail, typeof(PublicClientDetail))) as PublicClientDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPublicClientDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubClientDetail(string OfficeCode, string MemberCode, string MemberName, string MemDateFrom, string MemDateTo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubClientDetail(OfficeCode, MemberCode, MemberName, MemDateFrom, MemDateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}