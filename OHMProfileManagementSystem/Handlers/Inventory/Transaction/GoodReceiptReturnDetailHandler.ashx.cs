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
    /// Summary description for GoodReceiptReturnDetailHandler
    /// </summary>
    public class GoodReceiptReturnDetailHandler : BaseHandler
    {
        private static GoodReceiptReturnDetailController controller = new GoodReceiptReturnDetailController();


        public object SaveGoodReceiptReturnDetail(string goodReceiptReturnDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturnDetail obj = (new JavaScriptSerializer().Deserialize(goodReceiptReturnDetail, typeof(GoodReceiptReturnDetail))) as GoodReceiptReturnDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptReturnDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptReturnDetail(string goodReceiptReturnDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturnDetail search = (new JavaScriptSerializer().Deserialize(goodReceiptReturnDetail, typeof(GoodReceiptReturnDetail))) as GoodReceiptReturnDetail;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptReturnDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptReturnDetail(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptReturnDetail(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}