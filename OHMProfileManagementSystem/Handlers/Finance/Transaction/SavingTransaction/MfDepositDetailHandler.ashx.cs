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
    /// Summary description for MfDepositDetailHandler
    /// </summary>
    public class MfDepositDetailHandler : BaseHandler
    {
        private static MfDepositDetailController controller = new MfDepositDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string mFDepositDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfDepositDetail obj = (new JavaScriptSerializer().Deserialize(mFDepositDetail, typeof(MfDepositDetail))) as MfDepositDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string mFDepositDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MfDepositDetail search = (new JavaScriptSerializer().Deserialize(mFDepositDetail, typeof(MfDepositDetail))) as MfDepositDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMfDepositDetail(string offCode, long? depositNo, string savingAccountNo, string clientName, string fromDate, string toDate)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMfDepositDetail(offCode, depositNo, savingAccountNo, clientName, fromDate, toDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}