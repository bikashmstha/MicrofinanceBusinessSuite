using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.HumanResource.Transaction;
using MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.HumanResource.Transaction
{
    /// <summary>
    /// Summary description for EmployeePromotionHandler
    /// </summary>
    public class EmployeePromotionHandler : BaseHandler
    {
        private static EmployeePromotionController controller = new EmployeePromotionController();


        public object SaveEmployeePromotion(string employeePromotion)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeePromotion obj = (new JavaScriptSerializer().Deserialize(employeePromotion, typeof(EmployeePromotion))) as EmployeePromotion;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeePromotion(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeePromotion(string employeePromotion)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeePromotion search = (new JavaScriptSerializer().Deserialize(employeePromotion, typeof(EmployeePromotion))) as EmployeePromotion;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeePromotion(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}