using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for CenterLovHandler
    /// </summary>
    public class CenterLovHandler : BaseHandler
    {
        private static CenterLovController controller = new CenterLovController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string centerlov)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CenterLov obj = (new JavaScriptSerializer().Deserialize(centerlov, typeof(CenterLov))) as CenterLov;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Search(string centerlov)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CenterLov search = (new JavaScriptSerializer().Deserialize(centerlov, typeof(CenterLov))) as CenterLov;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetTransferLovList(string centerlov)
        {
            ExtJSResponse resp = new ExtJSResponse();
            CenterLov search = (new JavaScriptSerializer().Deserialize(centerlov, typeof(CenterLov))) as CenterLov;
            OutMessage oMsg = (OutMessage)controller.GetTransferLovList(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

    }
}