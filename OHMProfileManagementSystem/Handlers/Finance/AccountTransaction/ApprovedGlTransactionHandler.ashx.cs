using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for ApprovedGlTransactionHandler
    /// </summary>
    public class ApprovedGlTransactionHandler : BaseHandler
    {
        private static ApprovedGlTransactionController controller = new ApprovedGlTransactionController();


        public object SaveApprovedGlTransaction(string approvedGLTransaction)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ApprovedGlTransaction obj = (new JavaScriptSerializer().Deserialize(approvedGLTransaction, typeof(ApprovedGlTransaction))) as ApprovedGlTransaction;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveApprovedGlTransaction(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchApprovedGlTransaction(string approvedGLTransaction)
        {
            ExtJSResponse resp = new ExtJSResponse();
            ApprovedGlTransaction search = (new JavaScriptSerializer().Deserialize(approvedGLTransaction, typeof(ApprovedGlTransaction))) as ApprovedGlTransaction;
            OutMessage oMsg = (OutMessage)controller.SearchApprovedGlTransaction(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}