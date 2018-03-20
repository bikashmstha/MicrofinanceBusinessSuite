using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.CollectionSheetTransaction
{
    /// <summary>
    /// Summary description for CollectionSheetMasterHandler
    /// </summary>
    public class CollectionSheetMasterHandler : BaseHandler
    {
        private static CollectionSheetMasterController controller = new CollectionSheetMasterController();
        public object UnenterCollectionSheetMaster(string offCode, string collectionSheetNo, string username)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.UnenterCollectionSheetMaster(offCode, collectionSheetNo, username);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}