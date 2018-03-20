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
    /// Summary description for GoodReceiptReturnHandler
    /// </summary>
    public class GoodReceiptReturnHandler : BaseHandler
    {
        private static GoodReceiptReturnController controller = new GoodReceiptReturnController();


        public object SaveGoodReceiptReturn(string goodReceiptReturn)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturn obj = (new JavaScriptSerializer().Deserialize(goodReceiptReturn, typeof(GoodReceiptReturn))) as GoodReceiptReturn;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptReturn(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptReturn(string goodReceiptReturn)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturn search = (new JavaScriptSerializer().Deserialize(goodReceiptReturn, typeof(GoodReceiptReturn))) as GoodReceiptReturn;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptReturn(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptReturn(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptReturn(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}