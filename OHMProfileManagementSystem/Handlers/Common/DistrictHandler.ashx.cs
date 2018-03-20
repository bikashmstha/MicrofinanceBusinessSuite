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
using BusinessObjects.Common;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Handlers.Common
{
    /// <summary>
    /// Summary description for OfficeHandler
    /// </summary>
    public class DistrictHandler : BaseHandler
    {
        private static DistrictController controller = new DistrictController();

        public object SearchDistrict(string districtCode, string districtName)
        {
            DistrictController controller = new DistrictController();
            District dist = new District();
            dist.DistrictCode = districtCode;
            dist.DistrictDesc = districtName;

            List<District> lst = controller.SearchDistrict(dist).ToList();
            return GetResponse(lst);
        }

        private object GetResponse(List<District> lst)
        {
            ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }



        public object GetDistrictList(string districtName)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetDistrictList(districtName);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
       
        
    }
}