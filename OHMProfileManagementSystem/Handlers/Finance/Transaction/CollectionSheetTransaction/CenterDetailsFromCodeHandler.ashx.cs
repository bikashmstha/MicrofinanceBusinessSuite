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
    /// Summary description for CenterDetailsFromCodeHandler
    /// </summary>
    public class CenterDetailsFromCodeHandler : BaseHandler
    {
        private static CenterDetailsFromCodeController controller = new CenterDetailsFromCodeController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string centerDetailsFromCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CenterDetailsFromCode obj = (new JavaScriptSerializer().Deserialize(centerDetailsFromCode, typeof(CenterDetailsFromCode))) as CenterDetailsFromCode;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string centerDetailsFromCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CenterDetailsFromCode search = (new JavaScriptSerializer().Deserialize(centerDetailsFromCode, typeof(CenterDetailsFromCode))) as CenterDetailsFromCode;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCenterDetailsFromCode(string centerCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCenterDetailsFromCode(centerCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}