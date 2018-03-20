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
    /// Summary description for ReverseVoucherMasterDetailHandler
    /// </summary>
    public class ReverseVoucherMasterDetailHandler : BaseHandler
    {
        private static ReverseVoucherMasterDetailController controller = new ReverseVoucherMasterDetailController();


        public object SaveReverseVoucherMasterDetail(string reverseVoucherMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReverseVoucherMasterDetail obj = (new JavaScriptSerializer().Deserialize(reverseVoucherMasterDetail, typeof(ReverseVoucherMasterDetail))) as ReverseVoucherMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveReverseVoucherMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchReverseVoucherMasterDetail(string reverseVoucherMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ReverseVoucherMasterDetail search = (new JavaScriptSerializer().Deserialize(reverseVoucherMasterDetail, typeof(ReverseVoucherMasterDetail))) as ReverseVoucherMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchReverseVoucherMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetReverseVoucherMstDtl()
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetReverseVoucherMstDtl();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}