using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using MicrofinanceBusinessSuite.Controllers.Inventory.Transaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for GoodReceiptSearchHandler
    /// </summary>
    public class GoodReceiptSearchHandler : BaseHandler
    {
        private static GoodReceiptSearchController controller = new GoodReceiptSearchController();


        public object SaveGoodReceiptSearch(string goodReceiptSearch)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptSearch obj = (new JavaScriptSerializer().Deserialize(goodReceiptSearch, typeof(GoodReceiptSearch))) as GoodReceiptSearch;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptSearch(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptSearch(string goodReceiptSearch)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptSearch search = (new JavaScriptSerializer().Deserialize(goodReceiptSearch, typeof(GoodReceiptSearch))) as GoodReceiptSearch;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptSearch(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptSearch(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptSearch(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}