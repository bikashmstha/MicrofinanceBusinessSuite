using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.LoanTransaction
{
    /// <summary>
    /// Summary description for MfRepayAdjustSavingHandler
    /// </summary>
    public class MfRepayAdjustSavingHandler : BaseHandler
    {
        private static MfRepayAdjustSavingController controller = new MfRepayAdjustSavingController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mfRepayAdjustSaving)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfRepayAdjustSaving obj = (new JavaScriptSerializer().Deserialize(mfRepayAdjustSaving, typeof(MfRepayAdjustSaving))) as MfRepayAdjustSaving;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mfRepayAdjustSaving)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfRepayAdjustSaving search = (new JavaScriptSerializer().Deserialize(mfRepayAdjustSaving, typeof(MfRepayAdjustSaving))) as MfRepayAdjustSaving;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMfRepayAdjustSaving(string offCode, string clientNo, string productName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMfRepayAdjustSaving(offCode, clientNo, productName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}