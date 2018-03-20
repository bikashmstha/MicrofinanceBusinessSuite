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
    /// Summary description for MeLoanDetailHandler
    /// </summary>
    public class MeLoanDetailHandler : BaseHandler
    {
        private static MeLoanDetailController controller = new MeLoanDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string meLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MeLoanDetail obj = (new JavaScriptSerializer().Deserialize(meLoanDetail, typeof(MeLoanDetail))) as MeLoanDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string meLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MeLoanDetail search = (new JavaScriptSerializer().Deserialize(meLoanDetail, typeof(MeLoanDetail))) as MeLoanDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetMeLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMeLoanDetail(offCode, clientName, loanNo, dateFrom, dateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}