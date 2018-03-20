using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Maintenance.AccountControl;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Maintenance.AccountControl
{
    /// <summary>
    /// Summary description for VoucherApprovalSecurityHandler
    /// </summary>
    public class VoucherApprovalSecurityHandler : BaseHandler
    {

        public object GetVoucherApprovalSecurity(string officeCode)
        {
            VoucherApprovalSecurityController controller = new VoucherApprovalSecurityController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<VoucherApprovalSecurity> lst;

            try
            {
                lst = controller.GetVoucherApprovalSecurity(officeCode);
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

        public object SaveVoucherApprovalSecurity(string voucherApprovalSecurity)
        {
            VoucherApprovalSecurityController controller = new VoucherApprovalSecurityController();
            ExtJSResponse resp = new ExtJSResponse();

            VoucherApprovalSecurity objInstallmentPeriod = (new JavaScriptSerializer().Deserialize(voucherApprovalSecurity, typeof(VoucherApprovalSecurity))) as VoucherApprovalSecurity;
            objInstallmentPeriod.CreatedBy = GeneralHelper.UserId;
            objInstallmentPeriod.CreatedOn = GeneralHelper.DateEnglish;

            string response = "";
            try
            {
                OutMessage obj = controller.SaveVoucherApprovalSecurity(objInstallmentPeriod);
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