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
    /// Summary description for MemoMasterDetailHandler
    /// </summary>
    public class MemoMasterDetailHandler : BaseHandler
    {
        private static MemoMasterDetailController controller = new MemoMasterDetailController();


        public object SaveMemoMasterDetail(string memoMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoMasterDetail obj = (new JavaScriptSerializer().Deserialize(memoMasterDetail, typeof(MemoMasterDetail))) as MemoMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoMasterDetail(string memoMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoMasterDetail search = (new JavaScriptSerializer().Deserialize(memoMasterDetail, typeof(MemoMasterDetail))) as MemoMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchMemoMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}