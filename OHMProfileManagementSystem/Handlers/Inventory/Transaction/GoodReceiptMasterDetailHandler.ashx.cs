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
    /// Summary description for GoodReceiptMasterDetailHandler
    /// </summary>
    public class GoodReceiptMasterDetailHandler : BaseHandler
    {
        private static GoodReceiptMasterDetailController controller = new GoodReceiptMasterDetailController();


        public object SaveGoodReceiptMasterDetail(string goodReceiptMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptMasterDetail obj = (new JavaScriptSerializer().Deserialize(goodReceiptMasterDetail, typeof(GoodReceiptMasterDetail))) as GoodReceiptMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptMasterDetail(string goodReceiptMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptMasterDetail search = (new JavaScriptSerializer().Deserialize(goodReceiptMasterDetail, typeof(GoodReceiptMasterDetail))) as GoodReceiptMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}