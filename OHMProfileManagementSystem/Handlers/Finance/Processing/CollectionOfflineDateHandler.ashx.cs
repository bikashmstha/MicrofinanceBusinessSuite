using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using MicrofinanceBusinessSuite.Controllers.Finance.Processing;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Processing
{
    /// <summary>
    /// Summary description for CollectionOfflineDateHandler
    /// </summary>
    public class CollectionOfflineDateHandler : BaseHandler
    {
        private static CollectionOfflineDateController controller = new CollectionOfflineDateController();


        public object SaveCollectionOfflineDate(string collectionOfflineDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionOfflineDate obj = (new JavaScriptSerializer().Deserialize(collectionOfflineDate, typeof(CollectionOfflineDate))) as CollectionOfflineDate;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveCollectionOfflineDate(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchCollectionOfflineDate(string collectionOfflineDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionOfflineDate search = (new JavaScriptSerializer().Deserialize(collectionOfflineDate, typeof(CollectionOfflineDate))) as CollectionOfflineDate;
            OutMessage oMsg = (OutMessage)controller.SearchCollectionOfflineDate(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCollectionOfflineDate(string OfficeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCollectionOfflineDate(OfficeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}