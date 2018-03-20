using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.EditTransaction
{
    /// <summary>
    /// Summary description for LoanTransferProductHandler
    /// </summary>
    public class LoanTransferProductHandler : BaseHandler
    {
        private static LoanTransferProductController controller = new LoanTransferProductController();


        public object SaveLoanTransferProduct(string loanTransferProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferProduct obj = (new JavaScriptSerializer().Deserialize(loanTransferProduct, typeof(LoanTransferProduct))) as LoanTransferProduct;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveLoanTransferProduct(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchLoanTransferProduct(string loanTransferProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanTransferProduct search = (new JavaScriptSerializer().Deserialize(loanTransferProduct, typeof(LoanTransferProduct))) as LoanTransferProduct;
            OutMessage oMsg = (OutMessage)controller.SearchLoanTransferProduct(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetLoanTransferProduct(string ProductName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetLoanTransferProduct(ProductName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}