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
    /// Summary description for MeLoanRepayDetailHandler
    /// </summary>
    public class MeLoanRepayDetailHandler : BaseHandler
    {
        private static MeLoanRepayDetailController controller = new MeLoanRepayDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string meLoanRepayDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MeLoanRepayDetail obj = (new JavaScriptSerializer().Deserialize(meLoanRepayDetail, typeof(MeLoanRepayDetail))) as MeLoanRepayDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string meLoanRepayDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MeLoanRepayDetail search = (new JavaScriptSerializer().Deserialize(meLoanRepayDetail, typeof(MeLoanRepayDetail))) as MeLoanRepayDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMeLoanRepayDetail(string offCode, string repaymentNo, string clientName, string loanDno, string dateFrom, string dateTo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMeLoanRepayDetail(offCode, repaymentNo, clientName, loanDno, dateFrom, dateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}