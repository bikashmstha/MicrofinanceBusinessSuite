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
    /// Summary description for PubSavingProductHandler
    /// </summary>
    public class PubSavingProductHandler : BaseHandler
    {
        private static PubSavingProductController controller = new PubSavingProductController();


        public object SavePubSavingProduct(string pubSavingProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PubSavingProduct obj = (new JavaScriptSerializer().Deserialize(pubSavingProduct, typeof(PubSavingProduct))) as PubSavingProduct;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SavePubSavingProduct(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchPubSavingProduct(string pubSavingProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            PubSavingProduct search = (new JavaScriptSerializer().Deserialize(pubSavingProduct, typeof(PubSavingProduct))) as PubSavingProduct;
            OutMessage oMsg = (OutMessage)controller.SearchPubSavingProduct(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetPubSavingProd(string ProductName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetPubSavingProd(ProductName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}