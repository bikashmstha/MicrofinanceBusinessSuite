using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for LoanProductPurposeHandler
    /// </summary>
    public class LoanPurposeProductDetailHandler : BaseHandler
    {
        private static LoanPurposeProductDetailController controller = new LoanPurposeProductDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string LoanPurposeProductDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanPurposeProductDetail obj = (new JavaScriptSerializer().Deserialize(LoanPurposeProductDetail, typeof(LoanPurposeProductDetail))) as LoanPurposeProductDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string LoanPurposeProductDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            LoanPurposeProductDetail search = (new JavaScriptSerializer().Deserialize(LoanPurposeProductDetail, typeof(LoanPurposeProductDetail))) as LoanPurposeProductDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}