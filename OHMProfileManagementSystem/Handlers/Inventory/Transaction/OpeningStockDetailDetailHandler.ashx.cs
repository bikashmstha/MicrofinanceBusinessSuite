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
    /// Summary description for OpeningStockDetailDetailHandler
    /// </summary>
    public class OpeningStockDetailDetailHandler : BaseHandler
    {
        private static OpeningStockDetailDetailController controller = new OpeningStockDetailDetailController();


        public object SaveOpeningStockDetailDetail(string openingStockDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OpeningStockDetailDetail obj = (new JavaScriptSerializer().Deserialize(openingStockDetailDetail, typeof(OpeningStockDetailDetail))) as OpeningStockDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveOpeningStockDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchOpeningStockDetailDetail(string openingStockDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OpeningStockDetailDetail search = (new JavaScriptSerializer().Deserialize(openingStockDetailDetail, typeof(OpeningStockDetailDetail))) as OpeningStockDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchOpeningStockDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetOpeningStockDtlDetail(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOpeningStockDtlDetail(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}