using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for SavingTypeHandler
    /// </summary>
    public class SavingTypeHandler : BaseHandler
    {
        private static SavingTypeController controller = new SavingTypeController();


        public object SaveSavingType(string savingType)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingType obj = (new JavaScriptSerializer().Deserialize(savingType, typeof(SavingType))) as SavingType;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingType(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingType(string savingType)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingType search = (new JavaScriptSerializer().Deserialize(savingType, typeof(SavingType))) as SavingType;
            OutMessage oMsg = (OutMessage)controller.SearchSavingType(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavingType(string SavingProductType)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavingType(SavingProductType);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}