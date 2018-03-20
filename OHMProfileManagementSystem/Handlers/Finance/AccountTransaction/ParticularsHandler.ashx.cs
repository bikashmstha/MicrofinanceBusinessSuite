using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.AccountTransaction
{
    /// <summary>
    /// Summary description for ParticularsHandler
    /// </summary>
    public class ParticularsHandler : BaseHandler
    {
        private static ParticularsController controller = new ParticularsController();


        public object SaveParticulars(string particulars)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Particulars obj = (new JavaScriptSerializer().Deserialize(particulars, typeof(Particulars))) as Particulars;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveParticulars(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchParticulars(string particulars)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Particulars search = (new JavaScriptSerializer().Deserialize(particulars, typeof(Particulars))) as Particulars;
            OutMessage oMsg = (OutMessage)controller.SearchParticulars(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetParticulars(string ParticularsDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetParticulars(ParticularsDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}