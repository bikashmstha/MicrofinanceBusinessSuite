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
    /// Summary description for DepreciationDetailHandler
    /// </summary>
    public class DepreciationDetailHandler : BaseHandler
    {
        private static DepreciationDetailController controller = new DepreciationDetailController();


        public object SaveDepreciationDetail(string depreciationDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DepreciationDetail obj = (new JavaScriptSerializer().Deserialize(depreciationDetail, typeof(DepreciationDetail))) as DepreciationDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveDepreciationDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchDepreciationDetail(string depreciationDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DepreciationDetail search = (new JavaScriptSerializer().Deserialize(depreciationDetail, typeof(DepreciationDetail))) as DepreciationDetail;
            OutMessage oMsg = (OutMessage)controller.SearchDepreciationDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetDepreciationDetail(string AssetCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetDepreciationDetail(AssetCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}