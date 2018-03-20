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
    /// Summary description for MemoReturnMasterDetailHandler
    /// </summary>
    public class MemoReturnMasterDetailHandler : BaseHandler
    {
        private static MemoReturnMasterDetailController controller = new MemoReturnMasterDetailController();


        public object SaveMemoReturnMasterDetail(string memoReturnMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoReturnMasterDetail obj = (new JavaScriptSerializer().Deserialize(memoReturnMasterDetail, typeof(MemoReturnMasterDetail))) as MemoReturnMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoReturnMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoReturnMasterDetail(string memoReturnMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoReturnMasterDetail search = (new JavaScriptSerializer().Deserialize(memoReturnMasterDetail, typeof(MemoReturnMasterDetail))) as MemoReturnMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchMemoReturnMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoReturnMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoReturnMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}