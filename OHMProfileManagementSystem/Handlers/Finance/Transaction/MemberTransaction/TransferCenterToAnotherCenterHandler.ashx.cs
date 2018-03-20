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
    /// Summary description for TransferCenterToAnotherCenterHandler
    /// </summary>
    public class TransferCenterToAnotherCenterHandler : BaseHandler
    {
        private static TransferCenterToAnotherCenterController controller = new TransferCenterToAnotherCenterController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string TransferCenterToAnotherCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferCenterToAnotherCenter obj = (new JavaScriptSerializer().Deserialize(TransferCenterToAnotherCenter, typeof(TransferCenterToAnotherCenter))) as TransferCenterToAnotherCenter;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string TransferCenterToAnotherCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferCenterToAnotherCenter search = (new JavaScriptSerializer().Deserialize(TransferCenterToAnotherCenter, typeof(TransferCenterToAnotherCenter))) as TransferCenterToAnotherCenter;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}