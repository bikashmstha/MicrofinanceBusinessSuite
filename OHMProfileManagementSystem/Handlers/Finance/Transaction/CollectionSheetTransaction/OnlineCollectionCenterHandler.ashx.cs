using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.CollectionSheetTransaction
{
    /// <summary>
    /// Summary description for OnlineCollectionCenterHandler
    /// </summary>
    public class OnlineCollectionCenterHandler : BaseHandler
    {
        private static OnlineCollectionCenterController controller = new OnlineCollectionCenterController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string onlineCollectionCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OnlineCollectionCenter obj = (new JavaScriptSerializer().Deserialize(onlineCollectionCenter, typeof(OnlineCollectionCenter))) as OnlineCollectionCenter;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string onlineCollectionCenter)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OnlineCollectionCenter search = (new JavaScriptSerializer().Deserialize(onlineCollectionCenter, typeof(OnlineCollectionCenter))) as OnlineCollectionCenter;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetOnlineCenters(string date, string offCode, string centerName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOnlineCenters(date,offCode,centerName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetOnlineCenterList( string offCode, string centerName)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOnlineCenterList( offCode, centerName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}