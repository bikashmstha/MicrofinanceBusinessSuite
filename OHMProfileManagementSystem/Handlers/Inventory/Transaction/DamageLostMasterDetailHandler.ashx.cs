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
    /// Summary description for DamageLostMasterDetailHandler
    /// </summary>
    public class DamageLostMasterDetailHandler : BaseHandler
    {
        private static DamageLostMasterDetailController controller = new DamageLostMasterDetailController();


        public object SaveDamageLostMasterDetail(string damageLostMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DamageLostMasterDetail obj = (new JavaScriptSerializer().Deserialize(damageLostMasterDetail, typeof(DamageLostMasterDetail))) as DamageLostMasterDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveDamageLostMasterDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchDamageLostMasterDetail(string damageLostMasterDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DamageLostMasterDetail search = (new JavaScriptSerializer().Deserialize(damageLostMasterDetail, typeof(DamageLostMasterDetail))) as DamageLostMasterDetail;
            OutMessage oMsg = (OutMessage)controller.SearchDamageLostMasterDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetDamageLostMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetDamageLostMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}