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
    /// Summary description for CollectionSheetMasterOfflineHandler
    /// </summary>
    public class CollectionSheetMasterOfflineHandler : BaseHandler
    {
        private static CollectionSheetMasterOfflineController controller = new CollectionSheetMasterOfflineController();


        public object SaveCollectionSheetMasterOffline(string collectionSheetMasterOffline)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionSheetMasterOffline obj = (new JavaScriptSerializer().Deserialize(collectionSheetMasterOffline, typeof(CollectionSheetMasterOffline))) as CollectionSheetMasterOffline;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveCollectionSheetMasterOffline(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchCollectionSheetMasterOffline(string collectionSheetMasterOffline)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionSheetMasterOffline search = (new JavaScriptSerializer().Deserialize(collectionSheetMasterOffline, typeof(CollectionSheetMasterOffline))) as CollectionSheetMasterOffline;
            OutMessage oMsg = (OutMessage)controller.SearchCollectionSheetMasterOffline(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCollectionSheetMstOffline(string OfficeCode, string Date)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCollectionSheetMstOffline(OfficeCode, Date);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}