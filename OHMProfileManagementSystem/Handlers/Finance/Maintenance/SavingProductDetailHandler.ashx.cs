using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for SavingProductDetailHandler
    /// </summary>
    public class SavingProductDetailHandler : BaseHandler
    {
        private static SavingProductDetailController controller = new SavingProductDetailController();


        public object SaveSavingProductDetail(string savingProductDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingProductDetail obj = (new JavaScriptSerializer().Deserialize(savingProductDetail, typeof(SavingProductDetail))) as SavingProductDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveSavingProductDetail(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchSavingProductDetail(string savingProductDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            SavingProductDetail search = (new JavaScriptSerializer().Deserialize(savingProductDetail, typeof(SavingProductDetail))) as SavingProductDetail;
            OutMessage oMsg = (OutMessage)controller.SearchSavingProductDetail(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetSavingProductDetail()
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetSavingProductDetail();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}