using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.References;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.References
{
    /// <summary>
    /// Summary description for MsRefrenceCodeDetailsHandler
    /// </summary>
    public class MsRefrenceCodeDetailsHandler : BaseHandler
    {

        private static MSReferenceCodeDetailsController controller = new MSReferenceCodeDetailsController();
        public object GetReferenceDetailListShort(string referenceCode)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetReferenceDetailListShort(referenceCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}