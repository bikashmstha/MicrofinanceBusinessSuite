using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for CenterHandler
    /// </summary>
    public class CenterHandler : BaseHandler
    {

        private static CenterController controller = new CenterController();

        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string center)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Center obj = (new JavaScriptSerializer().Deserialize(center, typeof(Center))) as Center;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string center)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Center search = (new JavaScriptSerializer().Deserialize(center, typeof(Center))) as Center;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetCenterChief(string centerCode, string memberName)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetCenterChief(centerCode,memberName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCenterListLov(string offCode, string centerName)
        {


            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetCenterListLov(offCode, centerName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetCenterList(string offCode, string centerName)
        {


            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetCenterList(offCode, centerName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetTransferCenterList(string offCode, string centerName, string oldCenterCode)
        {

            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetTransferCenterList(offCode, centerName, oldCenterCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}