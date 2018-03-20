using App.Utilities.Web.Handlers;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MicrofinanceBusinessSuite.Controllers.Common;
using BusinessObjects;
using BusinessObjects.Common;

namespace MicrofinanceBusinessSuite.Handlers.Common
{
    /// <summary>
    /// Summary description for OfficeHandler
    /// </summary>
    public class VdcHandler : BaseHandler
    {
        private static VdcController controller = new VdcController();
        public object SearchVdc(string vdcName)
        {
            Vdc vdc = new Vdc();
            vdc.VDCNPDesc = vdcName;

            List<Vdc> lst = controller.SearchVdc(vdc).ToList();
            return GetResponse(lst);
        }

        private object GetResponse(List<Vdc> lst)
        {
 	        ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }


       
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string Vdc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Vdc obj = (new JavaScriptSerializer().Deserialize(Vdc, typeof(Vdc))) as Vdc;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string Vdc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Vdc search = (new JavaScriptSerializer().Deserialize(Vdc, typeof(Vdc))) as Vdc;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetVDCShort(string Vdc)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Vdc search = (new JavaScriptSerializer().Deserialize(Vdc, typeof(Vdc))) as Vdc;
            OutMessage oMsg = (OutMessage)controller.GetVDCShort(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        

       

       
        
    }
}