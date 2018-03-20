using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

// 
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects;
using BusinessObjects.Security;



/// teste
namespace MicrofinanceBusinessSuite.Controllers
{
    /// <summary>
    /// Base class for all Controllers. 
    /// Manages ClientTag, AccessToken, and RequestIds.
    /// </summary>
    public class ControllerBase
    {
        /// <summary>
        /// Client tag provided by the service provider and stored locally. 
        /// This value must be provided with every service call.
        /// </summary>
        protected static string ClientTag { get; private set; }

        /// <summary>
        /// Static constructor
        /// </summary>
        static ControllerBase()
        {
            // Retrieve ClientTag from web config file
            ClientTag = ConfigurationManager.AppSettings.Get("ClientTag");
        }

        // The access token that was returned from the service.
        // This value must be provided in every call for the duration of the session.
        //private string _accessToken;

        /// <summary>
        /// Gets or sets access token. If no token exists a new one is retrieved from service.
        /// </summary>
        protected string AccessToken
        {
            get
            {
                if (HttpContext.Current.Session["AccessToken"] == null)
                {
                    // Request a unique accesstoken from the webservice. This token is
                    // that is valid for the duration of the session.
                    //AuthenticationController controller = new AuthenticationController();
                    //HttpContext.Current.Session["AccessToken"] = controller.GetToken(); 
                }
                return (string)HttpContext.Current.Session["AccessToken"];
            }
        }

        /// <summary>
        /// Gets a new random GUID request id.
        /// </summary>
        protected string NewRequestId
        {
            get { return Guid.NewGuid().ToString(); }
        }

        /// <summary>
        /// Lazy loads BusinessObjectsClient and stores it in Session object.
        /// </summary>
        ////protected BusinessObjectsClient BusinessObjectsClient
        ////{
        ////    get
        ////    {
        ////        //if (HttpContext.Current.Session["BusinessObjectsClient"] == null)
        ////        //    HttpContext.Current.Session["BusinessObjectsClient"] = new BusinessObjectsClient();

        ////        //return HttpContext.Current.Session["BusinessObjectsClient"] as BusinessObjectsClient;

        ////        return new BusinessObjectsClient();
        ////    }
        ////}
        
        protected GenericUser User
        {
            get
            {


                if (HttpContext.Current.Session != null)
                {
                    return (HttpContext.Current.Session["User"] == null) ? null : HttpContext.Current.Session["User"] as GenericUser;

                }
                else
                {
                    return null;
                }
            }
        }

        public string Message
        {
            get
            {
                if (User == null)
                {
                    ExtJSResponse resp = new ExtJSResponse();
                    resp.Message = "User not logged in or session already expired";
                    resp.Success = "false";
                    return resp.GetResponse(null, 0);  
                }
                else
                {
                    return "";
                }
            }
        }


        //below method created by info developer
        protected User SessionUser
        {
            get
            {


                if (HttpContext.Current.Session != null)
                {
                    return (HttpContext.Current.Session["User"] == null) ? null : HttpContext.Current.Session["User"] as User;

                }
                else
                {
                    return null;
                }
            }
        }



    }
}
