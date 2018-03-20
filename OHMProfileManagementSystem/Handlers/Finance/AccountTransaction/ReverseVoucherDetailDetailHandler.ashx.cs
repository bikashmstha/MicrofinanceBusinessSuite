using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for ReverseVoucherDetailDetailHandler
    /// </summary>
    public class ReverseVoucherDetailDetailHandler : BaseHandler
    {
        private static ReverseVoucherDetailDetailController controller = new ReverseVoucherDetailDetailController();


        public object SaveReverseVoucherDetailDetail(string reverseVoucherDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReverseVoucherDetailDetail obj = (new JavaScriptSerializer().Deserialize(reverseVoucherDetailDetail, typeof(ReverseVoucherDetailDetail))) as ReverseVoucherDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveReverseVoucherDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchReverseVoucherDetailDetail(string reverseVoucherDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReverseVoucherDetailDetail search = (new JavaScriptSerializer().Deserialize(reverseVoucherDetailDetail, typeof(ReverseVoucherDetailDetail))) as ReverseVoucherDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchReverseVoucherDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetReverseVoucherDtlDetail(string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetReverseVoucherDtlDetail(VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}