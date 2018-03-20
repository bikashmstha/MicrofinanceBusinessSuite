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
    /// Summary description for JvMasterDetailHandler
    /// </summary>
    public class JvMasterDetailHandler : BaseHandler
    {
        private static JvMasterDetailController controller = new JvMasterDetailController();


        public object SaveJvMasterDetail(string jVMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            JvMasterDetail obj = (new JavaScriptSerializer().Deserialize(jVMasterDetail, typeof(JvMasterDetail))) as JvMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveJvMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchJvMasterDetail(string jVMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            JvMasterDetail search = (new JavaScriptSerializer().Deserialize(jVMasterDetail, typeof(JvMasterDetail))) as JvMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchJvMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetJvMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetJvMstDetail(OfficeCode, VoucherNo, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}