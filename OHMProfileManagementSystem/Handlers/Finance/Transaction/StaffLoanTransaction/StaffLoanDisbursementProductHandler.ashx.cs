using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.StaffLoanTransaction
{
    /// <summary>
    /// Summary description for StaffLoanDisbursementProductHandler
    /// </summary>
    public class StaffLoanDisbursementProductHandler : BaseHandler
    {
        private static StaffLoanDisbursementProductController controller = new StaffLoanDisbursementProductController();


        public object SaveStaffLoanDisbursementProduct(string staffLoanDisbursementProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementProduct obj = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementProduct, typeof(StaffLoanDisbursementProduct))) as StaffLoanDisbursementProduct;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffLoanDisbursementProduct(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffLoanDisbursementProduct(string staffLoanDisbursementProduct)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffLoanDisbursementProduct search = (new JavaScriptSerializer().Deserialize(staffLoanDisbursementProduct, typeof(StaffLoanDisbursementProduct))) as StaffLoanDisbursementProduct;
            OutMessage oMsg = (OutMessage)controller.SearchStaffLoanDisbursementProduct(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffLoanDisProd(string ProductName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffLoanDisProd(ProductName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}