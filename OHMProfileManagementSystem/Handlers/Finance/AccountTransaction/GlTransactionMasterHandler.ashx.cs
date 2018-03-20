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
    /// Summary description for GlTransactionMasterHandler
    /// </summary>
    public class GlTransactionMasterHandler : BaseHandler
    {
        private static GlTransactionMasterController controller = new GlTransactionMasterController();


        public object SaveGlTransactionMaster(string glTransactionMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GlTransactionMaster obj = (new JavaScriptSerializer().Deserialize(glTransactionMaster, typeof(GlTransactionMaster))) as GlTransactionMaster;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGlTransactionMaster(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGlTransactionMaster(string glTransactionMaster)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GlTransactionMaster search = (new JavaScriptSerializer().Deserialize(glTransactionMaster, typeof(GlTransactionMaster))) as GlTransactionMaster;
            OutMessage oMsg = (OutMessage)controller.SearchGlTransactionMaster(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}