using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.PublicSavingTransaction
{
    /// <summary>
    /// Summary description for PublicAccountCloseProductHandler
    /// </summary>
    public class PublicAccountCloseProductHandler : BaseHandler
    {
        private static PublicAccountCloseProductController controller = new PublicAccountCloseProductController();


        public object SavePublicAccountCloseProduct(string publicAccountCloseProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCloseProduct obj = (new JavaScriptSerializer().Deserialize(publicAccountCloseProduct, typeof(PublicAccountCloseProduct))) as PublicAccountCloseProduct;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePublicAccountCloseProduct(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPublicAccountCloseProduct(string publicAccountCloseProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PublicAccountCloseProduct search = (new JavaScriptSerializer().Deserialize(publicAccountCloseProduct, typeof(PublicAccountCloseProduct))) as PublicAccountCloseProduct;
            OutMessage oMsg = (OutMessage)controller.SearchPublicAccountCloseProduct(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubAccCloseProd(string ProductName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubAccCloseProd(ProductName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}