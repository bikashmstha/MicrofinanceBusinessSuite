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
    /// Summary description for GoodReceiptEmployeeHandler
    /// </summary>
    public class GoodReceiptEmployeeHandler : BaseHandler
    {
        private static GoodReceiptEmployeeController controller = new GoodReceiptEmployeeController();


        public object SaveGoodReceiptEmployee(string goodReceiptEmployee)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptEmployee obj = (new JavaScriptSerializer().Deserialize(goodReceiptEmployee, typeof(GoodReceiptEmployee))) as GoodReceiptEmployee;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveGoodReceiptEmployee(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchGoodReceiptEmployee(string goodReceiptEmployee)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GoodReceiptEmployee search = (new JavaScriptSerializer().Deserialize(goodReceiptEmployee, typeof(GoodReceiptEmployee))) as GoodReceiptEmployee;
            OutMessage oMsg = (OutMessage)controller.SearchGoodReceiptEmployee(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetGoodReceiptEmp()
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetGoodReceiptEmp();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}