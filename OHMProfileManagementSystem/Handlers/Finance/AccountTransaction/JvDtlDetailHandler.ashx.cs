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
    /// Summary description for JvDtlDetailHandler
    /// </summary>
    public class JvDtlDetailHandler : BaseHandler
    {
        private static JvDtlDetailController controller = new JvDtlDetailController();


        public object SaveJvDtlDetail(string jVDtlDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            JvDtlDetail obj = (new JavaScriptSerializer().Deserialize(jVDtlDetail, typeof(JvDtlDetail))) as JvDtlDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveJvDtlDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchJvDtlDetail(string jVDtlDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            JvDtlDetail search = (new JavaScriptSerializer().Deserialize(jVDtlDetail, typeof(JvDtlDetail))) as JvDtlDetail;
            OutMessage oMsg = (OutMessage)controller.SearchJvDtlDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetJvDtlDetail(string VoucherNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetJvDtlDetail(VoucherNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}