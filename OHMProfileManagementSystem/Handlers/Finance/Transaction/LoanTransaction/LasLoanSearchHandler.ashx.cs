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
    /// Summary description for LasLoanSearchHandler
    /// </summary>
    public class LasLoanSearchHandler : BaseHandler
    {
        private static LasLoanSearchController controller = new LasLoanSearchController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string lasLoanSearch)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LasLoanSearch obj = (new JavaScriptSerializer().Deserialize(lasLoanSearch, typeof(LasLoanSearch))) as LasLoanSearch;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string lasLoanSearch)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LasLoanSearch search = (new JavaScriptSerializer().Deserialize(lasLoanSearch, typeof(LasLoanSearch))) as LasLoanSearch;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLasLoanSearch(string OfficeCode, string ClientName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLasLoanSearch(OfficeCode, ClientName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}