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
    /// Summary description for LoanCollectionDetailHandler
    /// </summary>
    public class LoanCollectionDetailHandler : BaseHandler
    {
        private static LoanCollectionDetailController controller = new LoanCollectionDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string loanCollectionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanCollectionDetail obj = (new JavaScriptSerializer().Deserialize(loanCollectionDetail, typeof(LoanCollectionDetail))) as LoanCollectionDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string loanCollectionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanCollectionDetail search = (new JavaScriptSerializer().Deserialize(loanCollectionDetail, typeof(LoanCollectionDetail))) as LoanCollectionDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCollectionLoanDetail(string centerCode, string collectionSheetNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCollectionLoanDetail(centerCode, collectionSheetNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object  UpdateLoanCollectionSheet(string collectionSheetNo, string user)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.DeleteLoanCollectionSheet(collectionSheetNo, GeneralHelper.UserId);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object UpdateLoanCollectionSheet(string loanCollectionDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanCollectionDetail obj = (new JavaScriptSerializer().Deserialize(loanCollectionDetail, typeof(LoanCollectionDetail))) as LoanCollectionDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.UpdateLoanCollectionSheet(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}