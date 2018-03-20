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
    /// Summary description for ProductForDepositHandler
    /// </summary>
    public class ProductForDepositHandler : BaseHandler
    {
        private static ProductForDepositController controller = new ProductForDepositController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string productForDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ProductForDeposit obj = (new JavaScriptSerializer().Deserialize(productForDeposit, typeof(ProductForDeposit))) as ProductForDeposit;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string productForDeposit)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ProductForDeposit search = (new JavaScriptSerializer().Deserialize(productForDeposit, typeof(ProductForDeposit))) as ProductForDeposit;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetProductForDeposit(string productName)
        {
            
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetProductForDeposit(productName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}