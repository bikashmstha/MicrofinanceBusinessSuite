using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using MicrofinanceBusinessSuite.Controllers.Maintenance;

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters.Maintenance
{
    /// <summary>
    /// Summary description for CasteDetailHandler
    /// </summary>
    public class CasteDetailHandler : BaseHandler
    {
        private static CasteDetailController controller = new CasteDetailController();

        public object GetCasteShort(string caste)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetCasteShort(caste);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetCasteDetails()
        {
            CasteDetailController controller = new CasteDetailController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<CasteDetail> lst;

            try
            {
                lst = controller.GetCasteDetails();
                resp.Success = "true";
                response = resp.GetResponse(lst, lst.Count);

            }
            catch (Exception ex)
            {
                resp.Success = "false";
                resp.Message = ex.Message;
                response = resp.GetResponse(null, 0);
            }



            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }
        public object SaveCasteDetail(string casteDetail)
        {
            CasteDetailController controller = new CasteDetailController();
            ExtJSResponse resp = new ExtJSResponse();
            CasteDetail objCasteDetail = (new JavaScriptSerializer().Deserialize(casteDetail, typeof(CasteDetail))) as CasteDetail;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveCasteDetail(objCasteDetail);
                resp.Success = "true";
                response = resp.GetResponse(obj, 1);

            }
            catch (Exception ex)
            {

                resp.Success = "false";
                resp.Message = ex.Message;
                response = resp.GetResponse(null, 0);
            }
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;

        }


        public object GetCaste(string CasteDesc)
        {
            CasteDetailController controller = new CasteDetailController();
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCastes(CasteDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetCastes(string CasteDesc)
        {
            CasteDetailController controller = new CasteDetailController();
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetCastes(CasteDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}