using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.SavingTransaction
{
    /// <summary>
    /// Summary description for MfWithDrawlDetailHandler
    /// </summary>
    public class MfWithdrawlDetailHandler : BaseHandler
    {
        private static MfWithdrawlDetailController controller = new MfWithdrawlDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mfWithDrawlDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfWithdrawlDetail obj = (new JavaScriptSerializer().Deserialize(mfWithDrawlDetail, typeof(MfWithdrawlDetail))) as MfWithdrawlDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mfWithDrawlDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfWithdrawlDetail search = (new JavaScriptSerializer().Deserialize(mfWithDrawlDetail, typeof(MfWithdrawlDetail))) as MfWithdrawlDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMfWithdrawDetail(string offCode, long? withdrawlNo, string savingAccountNo, string clientName, string fromDate, string toDate)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMfWithdrawDetail(offCode, withdrawlNo, savingAccountNo, clientName, fromDate, toDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}