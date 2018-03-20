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
    /// Summary description for PubSavingDepositDetailHandler
    /// </summary>
    public class PubSavingDepositDetailHandler : BaseHandler
    {
        private static PubSavingDepositDetailController controller = new PubSavingDepositDetailController();


        public object SavePubSavingDepositDetail(string pubSavingDepositDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PubSavingDepositDetail obj = (new JavaScriptSerializer().Deserialize(pubSavingDepositDetail, typeof(PubSavingDepositDetail))) as PubSavingDepositDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePubSavingDepositDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPubSavingDepositDetail(string pubSavingDepositDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PubSavingDepositDetail search = (new JavaScriptSerializer().Deserialize(pubSavingDepositDetail, typeof(PubSavingDepositDetail))) as PubSavingDepositDetail;
            OutMessage oMsg = (OutMessage)controller.SearchPubSavingDepositDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavDepoDetail(string OfficeCode, long? DepositNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavDepoDetail(OfficeCode, DepositNo, SavingAccountNo, ClientName, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}