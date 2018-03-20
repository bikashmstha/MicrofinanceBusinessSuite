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
    /// Summary description for PubSavingAccountSearchHandler
    /// </summary>
    public class PubSavingAccountSearchHandler : BaseHandler
    {
        private static PubSavingAccountSearchController controller = new PubSavingAccountSearchController();


        public object SavePubSavingAccountSearch(string pubSavingAccountSearch)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PubSavingAccountSearch obj = (new JavaScriptSerializer().Deserialize(pubSavingAccountSearch, typeof(PubSavingAccountSearch))) as PubSavingAccountSearch;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePubSavingAccountSearch(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPubSavingAccountSearch(string pubSavingAccountSearch)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PubSavingAccountSearch search = (new JavaScriptSerializer().Deserialize(pubSavingAccountSearch, typeof(PubSavingAccountSearch))) as PubSavingAccountSearch;
            OutMessage oMsg = (OutMessage)controller.SearchPubSavingAccountSearch(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavAccSearch(string OfficeCode, string SavingAccountNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavAccSearch(OfficeCode, SavingAccountNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}