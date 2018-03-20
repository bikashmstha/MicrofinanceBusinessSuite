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
    /// Summary description for CollectionSheetPostingHandler
    /// </summary>
    public class CollectionSheetPostingHandler : BaseHandler
    {
        private static CollectionSheetPostingController controller = new CollectionSheetPostingController();


        public object SaveCollectionSheetPosting(string collectionSheetPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionSheetPosting obj = (new JavaScriptSerializer().Deserialize(collectionSheetPosting, typeof(CollectionSheetPosting))) as CollectionSheetPosting;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveCollectionSheetPosting(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchCollectionSheetPosting(string collectionSheetPosting)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CollectionSheetPosting search = (new JavaScriptSerializer().Deserialize(collectionSheetPosting, typeof(CollectionSheetPosting))) as CollectionSheetPosting;
            OutMessage oMsg = (OutMessage)controller.SearchCollectionSheetPosting(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}