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
    /// Summary description for OpeningStockMasterDetailHandler
    /// </summary>
    public class OpeningStockMasterDetailHandler : BaseHandler
    {
        private static OpeningStockMasterDetailController controller = new OpeningStockMasterDetailController();


        public object SaveOpeningStockMasterDetail(string openingStockMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OpeningStockMasterDetail obj = (new JavaScriptSerializer().Deserialize(openingStockMasterDetail, typeof(OpeningStockMasterDetail))) as OpeningStockMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveOpeningStockMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchOpeningStockMasterDetail(string openingStockMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OpeningStockMasterDetail search = (new JavaScriptSerializer().Deserialize(openingStockMasterDetail, typeof(OpeningStockMasterDetail))) as OpeningStockMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchOpeningStockMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetOpeningStockMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOpeningStockMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}