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
    /// Summary description for TransferWithinCenterHandler
    /// </summary>
    public class TransferWithinCenterHandler : BaseHandler
    {
        private static TransferWithinCenterController controller = new TransferWithinCenterController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string transferwithincenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferWithinCenter obj = (new JavaScriptSerializer().Deserialize(transferwithincenter, typeof(TransferWithinCenter))) as TransferWithinCenter;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string transferwithincenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            TransferWithinCenter search = (new JavaScriptSerializer().Deserialize(transferwithincenter, typeof(TransferWithinCenter))) as TransferWithinCenter;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}