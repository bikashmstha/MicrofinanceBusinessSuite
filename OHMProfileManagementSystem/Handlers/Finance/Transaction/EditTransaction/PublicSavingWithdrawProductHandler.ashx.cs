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
    /// Summary description for PublicSavingWithdrawProductHandler
    /// </summary>
    public class PublicSavingWithdrawProductHandler : BaseHandler
    {
        private static PublicSavingWithdrawProductController controller = new PublicSavingWithdrawProductController();


        public object SavePublicSavingWithdrawProduct(string publicSavingWithdrawProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawProduct obj = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawProduct, typeof(PublicSavingWithdrawProduct))) as PublicSavingWithdrawProduct;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicSavingWithdrawProduct(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicSavingWithdrawProduct(string publicSavingWithdrawProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicSavingWithdrawProduct search = (new JavaScriptSerializer().Deserialize(publicSavingWithdrawProduct, typeof(PublicSavingWithdrawProduct))) as PublicSavingWithdrawProduct;
            OutMessage oMsg = (OutMessage)controller.SearchPublicSavingWithdrawProduct(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavWithProd(string ProductName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavWithProd(ProductName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}