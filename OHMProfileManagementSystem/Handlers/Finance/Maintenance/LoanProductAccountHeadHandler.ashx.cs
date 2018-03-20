using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for LoanProductAccountHeadHandler
    /// </summary>
    public class LoanProductAccountHeadHandler : BaseHandler
    {
        private static LoanProductAccountHeadController controller = new LoanProductAccountHeadController();


        public object SaveLoanProductAccountHead(string loanProductAccountHead)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanProductAccountHead obj = (new JavaScriptSerializer().Deserialize(loanProductAccountHead, typeof(LoanProductAccountHead))) as LoanProductAccountHead;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanProductAccountHead(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanProductAccountHead(string loanProductAccountHead)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanProductAccountHead search = (new JavaScriptSerializer().Deserialize(loanProductAccountHead, typeof(LoanProductAccountHead))) as LoanProductAccountHead;
            OutMessage oMsg = (OutMessage)controller.SearchLoanProductAccountHead(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanProAccHead(string AccountDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanProAccHead(AccountDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}