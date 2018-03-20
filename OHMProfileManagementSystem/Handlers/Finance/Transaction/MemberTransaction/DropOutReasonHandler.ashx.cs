using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.MemberTransaction
{
    /// <summary>
    /// Summary description for DropOutReasonHandler
    /// </summary>
    public class DropOutReasonHandler : BaseHandler
    {
        private static DropOutReasonsController controller = new DropOutReasonsController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string DropOutReasons)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DropOutReasons obj = (new JavaScriptSerializer().Deserialize(DropOutReasons, typeof(DropOutReasons))) as DropOutReasons;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string DropOutReasons)
        {
            ExtJSResponse resp = new ExtJSResponse();
            DropOutReasons search = (new JavaScriptSerializer().Deserialize(DropOutReasons, typeof(DropOutReasons))) as DropOutReasons;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public  object GetCDReason(string reasonDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCDReason(reasonDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}