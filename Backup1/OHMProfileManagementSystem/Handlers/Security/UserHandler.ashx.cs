using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegratedTaxSystem.Controllers;
using IntegratedTaxSystem.Controllers.Security;
 
using System.Web.SessionState;
using App.Utilities.Web.Handlers;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Security;


namespace MicrofinanceBusinessSuite.Handlers.Security
{
    /// <summary>
    /// Summary description for UserHandler
    /// </summary>
    public class UserHandler : BaseHandler
    {
       
        public HttpContext Context
        {
            get
            {

                return HttpContext.Current;
            }
        }

        

        

        
        

        public object GetUserFromSession()
        {
            LoginController controller = new LoginController();
            ExtJSResponse extResp = new ExtJSResponse();
            ExtJSResponse extRespUser = controller.GetUserFromSession();

            string response = extResp.GetResponse(extRespUser, 1);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response; ;
        }

        
       
    }
}