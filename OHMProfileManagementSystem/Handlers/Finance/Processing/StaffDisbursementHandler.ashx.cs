using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using MicrofinanceBusinessSuite.Controllers.Finance.Processing;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Processing
{
    /// <summary>
    /// Summary description for StaffDisbursementHandler
    /// </summary>
    public class StaffDisbursementHandler : BaseHandler
    {
        private static StaffDisbursementController controller = new StaffDisbursementController();


        public object SaveStaffDisbursement(string staffDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffDisbursement obj = (new JavaScriptSerializer().Deserialize(staffDisbursement, typeof(StaffDisbursement))) as StaffDisbursement;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveStaffDisbursement(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchStaffDisbursement(string staffDisbursement)
        {
            ExtJSResponse resp = new ExtJSResponse();
            StaffDisbursement search = (new JavaScriptSerializer().Deserialize(staffDisbursement, typeof(StaffDisbursement))) as StaffDisbursement;
            OutMessage oMsg = (OutMessage)controller.SearchStaffDisbursement(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetStaffDisbursement(string OfficeCode, string UserCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetStaffDisbursement(OfficeCode, UserCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}