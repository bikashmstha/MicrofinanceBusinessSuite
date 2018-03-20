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
    /// Summary description for SavingCollectionSheetHandler
    /// </summary>
    public class SavingCollectionSheetHandler : BaseHandler
    {
        private static SavingCollectionSheetController controller = new SavingCollectionSheetController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string savingCollectionSheet)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingCollectionSheet obj = (new JavaScriptSerializer().Deserialize(savingCollectionSheet, typeof(SavingCollectionSheet))) as SavingCollectionSheet;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string savingCollectionSheet)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingCollectionSheet search = (new JavaScriptSerializer().Deserialize(savingCollectionSheet, typeof(SavingCollectionSheet))) as SavingCollectionSheet;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Delete(string sheetNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.Delete(sheetNo, GeneralHelper.UserId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Update(string sheetNo, string dataEntered, string dataEnteredDate, string welfareFundAmount, string user)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.Update(sheetNo,dataEntered,dataEnteredDate,welfareFundAmount, GeneralHelper.UserId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}