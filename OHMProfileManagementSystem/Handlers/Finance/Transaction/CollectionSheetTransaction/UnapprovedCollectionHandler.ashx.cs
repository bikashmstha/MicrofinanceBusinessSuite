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
    /// Summary description for UnapprovedCollectionHandler
    /// </summary>
    public class UnapprovedCollectionHandler : BaseHandler
    {
        private static UnapprovedCollectionController controller = new UnapprovedCollectionController();


        public object SaveUnapprovedCollection(string unapprovedCollection)
        {
            ExtJSResponse resp = new ExtJSResponse();
            UnapprovedCollection obj = (new JavaScriptSerializer().Deserialize(unapprovedCollection, typeof(UnapprovedCollection))) as UnapprovedCollection;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveUnapprovedCollection(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchUnapprovedCollection(string unapprovedCollection)
        {
            ExtJSResponse resp = new ExtJSResponse();
            UnapprovedCollection search = (new JavaScriptSerializer().Deserialize(unapprovedCollection, typeof(UnapprovedCollection))) as UnapprovedCollection;
            OutMessage oMsg = (OutMessage)controller.SearchUnapprovedCollection(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGetUnapprovedColl(string OfficeCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGetUnapprovedColl(OfficeCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}