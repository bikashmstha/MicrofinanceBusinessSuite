using App.Utilities.Web.Handlers;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using BusinessObjects;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Offices;
namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters
{
    /// <summary>
    /// Summary description for VDCCoverageByOfficeHandler
    /// </summary>
    public class VDCCoverageByOfficeHandler : BaseHandler
    {

        private static VdcCoverageByOfficeController controller = new VdcCoverageByOfficeController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string vdcCoverageByOffice)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VdcCoverageByOffice obj = (new JavaScriptSerializer().Deserialize(vdcCoverageByOffice, typeof(VdcCoverageByOffice))) as VdcCoverageByOffice;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string vdcCoverageByOffice)
        {
            ExtJSResponse resp = new ExtJSResponse();
            VdcCoverageByOffice search = (new JavaScriptSerializer().Deserialize(vdcCoverageByOffice, typeof(VdcCoverageByOffice))) as VdcCoverageByOffice;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}