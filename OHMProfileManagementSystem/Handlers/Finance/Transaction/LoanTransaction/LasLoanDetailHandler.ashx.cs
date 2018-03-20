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
    /// Summary description for LasLoanDetailHandler
    /// </summary>
    public class LasLoanDetailHandler : BaseHandler
    {
        private static LasLoanDetailController controller = new LasLoanDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string lasLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LasLoanDetail obj = (new JavaScriptSerializer().Deserialize(lasLoanDetail, typeof(LasLoanDetail))) as LasLoanDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string lasLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LasLoanDetail search = (new JavaScriptSerializer().Deserialize(lasLoanDetail, typeof(LasLoanDetail))) as LasLoanDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLasLoanDetail(string OfficeCode, string ClientName, string LoanNo, string DateFrom, string DateTo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLasLoanDetail(OfficeCode, ClientName, LoanNo, DateFrom, DateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}