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
    /// Summary description for GoodReceiptReturnMasterDetailHandler
    /// </summary>
    public class GoodReceiptReturnMasterDetailHandler : BaseHandler
    {
        private static GoodReceiptReturnMasterDetailController controller = new GoodReceiptReturnMasterDetailController();


        public object SaveGoodReceiptReturnMasterDetail(string goodReceiptReturnMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturnMasterDetail obj = (new JavaScriptSerializer().Deserialize(goodReceiptReturnMasterDetail, typeof(GoodReceiptReturnMasterDetail))) as GoodReceiptReturnMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptReturnMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptReturnMasterDetail(string goodReceiptReturnMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptReturnMasterDetail search = (new JavaScriptSerializer().Deserialize(goodReceiptReturnMasterDetail, typeof(GoodReceiptReturnMasterDetail))) as GoodReceiptReturnMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptReturnMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptReturnMstDtl(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptReturnMstDtl(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}