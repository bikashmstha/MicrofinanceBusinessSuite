using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for ABBSChargeHandler
    /// </summary>
    public class ABBSChargeHandler : BaseHandler
    {
        public object GetABBSCharge(string office,string toOffice, string abbsType)
        {
            ABBSChargeController controller = new ABBSChargeController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<ABBSCharge> lst;

            try
            {
                lst = controller.GetABBSCharge(office,toOffice,abbsType);
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

        public object SaveABBSCharge(string aBBSCharge)
        {
            ABBSChargeController controller = new ABBSChargeController();
            ExtJSResponse resp = new ExtJSResponse();

            ABBSCharge objABBSCharge = (new JavaScriptSerializer().Deserialize(aBBSCharge, typeof(ABBSCharge))) as ABBSCharge;
            objABBSCharge.CreatedBy = GeneralHelper.UserId;
            objABBSCharge.CreatedOn = GeneralHelper.DateEnglish;

            string response = "";
            try
            {
                OutMessage obj = controller.SaveABBSCharge(objABBSCharge);
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
       
    }
}