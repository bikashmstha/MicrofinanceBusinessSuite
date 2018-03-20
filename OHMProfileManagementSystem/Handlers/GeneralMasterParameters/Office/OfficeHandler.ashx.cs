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

namespace MicrofinanceBusinessSuite.Handlers.GeneralMasterParameters
{
    /// <summary>
    /// Summary description for OfficeHandler
    /// </summary>
    public class OfficeHandler : BaseHandler
    {


        private static OfficeController controller = new OfficeController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object GetOffices()
        //{

        //    List<Office> lst = controller.GetOffices().ToList();
        //    return GetResponse(lst);
        //}
        public object Save(string office)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Office obj = (new JavaScriptSerializer().Deserialize(office, typeof(Office))) as Office;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object SaveOffice( string office)
        //{

        //    ExtJSResponse resp = new ExtJSResponse();
        //    Office offc = (new JavaScriptSerializer().Deserialize(office, typeof(Office))) as Office;

        //    string success = controller.SaveOffice(offc);
        //    //resp.Success = success.ToString();
        //    //resp.Message = success ? "Office Saved Successfully" : "Error Saving Office";
        //    string response = resp.GetResponse(new List<Office>(), 0);
        //    SetResponseContentType(ResponseContentTypes.JSON);
        //    return response;
        //}
        public object Search(string office)
        {
            ExtJSResponse resp = new ExtJSResponse();
            Office search = (new JavaScriptSerializer().Deserialize(office, typeof(Office))) as Office;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        //public object SearchOffice(string officeCode,string officeName)
        //{

        //    Office offc = new Office();
        //    offc.OfficeCode = officeCode;
        //    offc.OfficeName = officeName;

        //    List<Office> lst = controller.SearchOffice(offc).ToList();
        //    return GetResponse(lst);
        //}

        //private object GetResponse(List<Office> lst)
        //{
        //    ExtJSResponse resp = new ExtJSResponse();
        //    string response = resp.GetResponse(lst, lst.Count);
        //    SetResponseContentType(ResponseContentTypes.JSON);
        //    return response;
        //}
        public object GetOfficeShort()
        {
            OfficeController controller = new OfficeController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<Office> lst;

            try
            {
                lst = controller.GetOfficeShort().ToList();
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

        public object GetOfficeList(string userCode, string officeName)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetOfficeList(GeneralHelper.UserId,officeName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        
        
    }
}