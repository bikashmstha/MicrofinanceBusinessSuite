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
    /// Summary description for CollectionSheetMasterOnlineHandler
    /// </summary>
    public class CollectionSheetMasterOnlineHandler : BaseHandler
    {
        private static CollectionSheetMasterOnlineController controller = new CollectionSheetMasterOnlineController();


        public object SaveCollectionSheetMasterOnline(string collectionSheetMasterOnline)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionSheetMasterOnline obj = (new JavaScriptSerializer().Deserialize(collectionSheetMasterOnline, typeof(CollectionSheetMasterOnline))) as CollectionSheetMasterOnline;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveCollectionSheetMasterOnline(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchCollectionSheetMasterOnline(string collectionSheetMasterOnline)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionSheetMasterOnline search = (new JavaScriptSerializer().Deserialize(collectionSheetMasterOnline, typeof(CollectionSheetMasterOnline))) as CollectionSheetMasterOnline;
            OutMessage oMsg = (OutMessage)controller.SearchCollectionSheetMasterOnline(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCollectionSheetMstOnline(string OfficeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCollectionSheetMstOnline(OfficeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}