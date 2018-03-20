using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;
 
using MicrofinanceBusinessSuite.Controllers;
using BusinessObjects.Security;
using BusinessObjects.Messages;
using DataObjects;
using DataObjects.Security;


namespace IntegratedTaxSystem.Controllers.Security
{
    /// <summary>
    /// Controller class for  Security.
    /// </summary>
    /// <remarks>
    /// MV Pattern: Model View Controller Pattern.
    /// This is a 'loose' implementation of the MVC pattern.
    /// </remarks>
    public class LogInOutController : ControllerBase
    {
        private static ILoginDao loginDao = DataAccess.LoginDao;
        //public bool Loginn()
        //{
        //    TaxPayer tp = (TaxPayer)System.Web.HttpContext.Current.Session["User"];
        //    return BusinessObjectsClient.Loginn(tp);
            
        //}
        public GenericUser Login(GenericUser user)
        {
            LoginRequest request = new LoginRequest();
            request.User = user;


            GenericUser response = loginDao.LogIn(user);

            return response;
        }

        /// <summary>
        /// Logout from from the system.
        /// </summary>
        /// <returns>Success or failure flag.</returns>
        //public bool Logout()
        //{
        //    LogoutRequest request = new LogoutRequest();
        //    request.RequestId = NewRequestId;
        //    request.ClientTag = ClientTag;
        //    request.AccessToken = AccessToken;

        //    LogoutResponse response = BusinessObjectsClient.GetApplications(request);

        //    return (response.Acknowledge == AcknowledgeType.Success);
        //}
    }
}