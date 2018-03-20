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
    /// Summary description for LoanProductDetailHandler
    /// </summary>
    public class LoanProductDetailHandler : BaseHandler
    {
        private static LoanProductDetailController controller = new LoanProductDetailController();


        public object SaveLoanProductDetail(string loanProductDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanProductDetail obj = (new JavaScriptSerializer().Deserialize(loanProductDetail, typeof(LoanProductDetail))) as LoanProductDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanProductDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanProductDetail(string loanProductDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanProductDetail search = (new JavaScriptSerializer().Deserialize(loanProductDetail, typeof(LoanProductDetail))) as LoanProductDetail;
            OutMessage oMsg = (OutMessage)controller.SearchLoanProductDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanProductDetailList(string LoanProductCode, string LoanType)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanProductDetailList(LoanProductCode, LoanType);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}