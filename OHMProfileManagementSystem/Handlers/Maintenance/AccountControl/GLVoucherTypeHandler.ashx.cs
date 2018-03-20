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
    /// Summary description for GLVoucherTypeHandler
    /// </summary>
    public class GLVoucherTypeHandler : BaseHandler
    {

        public object GetGLVoucherType(string officeCode, string fiscalYear)
        {
            GlVoucherTypeController controller = new GlVoucherTypeController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<GLVoucherType> lst;

            try
            {
                lst = controller.GetGLVoucherType(officeCode,fiscalYear);
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

        public object SaveGLVoucherType(string glVoucherType)
        {
            GlVoucherTypeController controller = new GlVoucherTypeController();
            ExtJSResponse resp = new ExtJSResponse();

            GLVoucherType objInstallmentPeriod = (new JavaScriptSerializer().Deserialize(glVoucherType, typeof(GLVoucherType))) as GLVoucherType;
            objInstallmentPeriod.CreatedBy = GeneralHelper.UserId;
            objInstallmentPeriod.CreatedOn = GeneralHelper.DateEnglish;

            string response = "";
            try
            {
                OutMessage obj = controller.SaveGLVoucherType(objInstallmentPeriod);
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