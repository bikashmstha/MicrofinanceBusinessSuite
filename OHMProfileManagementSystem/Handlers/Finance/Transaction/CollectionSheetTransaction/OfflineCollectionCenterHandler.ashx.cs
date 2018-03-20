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
    /// Summary description for OfflineCollectionCenterHandler
    /// </summary>
    public class OfflineCollectionCenterHandler : BaseHandler
    {
        private static OfflineCollectionCenterController controller = new OfflineCollectionCenterController();
        public object GetOfflineCollectionCenters( string offCode, string centerName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOfflineCollectionCenter( offCode, centerName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetOfflineCollectionCentersByDate(string date,string offCode, string centerName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOfflineCollectionCenterByDate(date,offCode, centerName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}