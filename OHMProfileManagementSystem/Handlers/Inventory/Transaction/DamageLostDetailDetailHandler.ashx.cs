using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using MicrofinanceBusinessSuite.Controllers.Inventory.Transaction;
using MicrofinanceBusinessSuite.Utility;


namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for DamageLostDetailDetailHandler
    /// </summary>
    public class DamageLostDetailDetailHandler : BaseHandler
    {
        private static DamageLostDetailDetailController controller = new DamageLostDetailDetailController();


        public object SaveDamageLostDetailDetail(string damageLostDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DamageLostDetailDetail obj = (new JavaScriptSerializer().Deserialize(damageLostDetailDetail, typeof(DamageLostDetailDetail))) as DamageLostDetailDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveDamageLostDetailDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchDamageLostDetailDetail(string damageLostDetailDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DamageLostDetailDetail search = (new JavaScriptSerializer().Deserialize(damageLostDetailDetail, typeof(DamageLostDetailDetail))) as DamageLostDetailDetail;
            OutMessage oMsg = (OutMessage)controller.SearchDamageLostDetailDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetDamageLostDtlDetail(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetDamageLostDtlDetail(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}