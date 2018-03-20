using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MicrofinanceBusinessSuite.Controllers;
using BusinessObjects.Security;

/*
 * this class is created by info developer
 */
namespace IntegratedTaxSystem.Controllers.Security
{
    public class SessionController : ControllerBase, IRequiresSessionState
    {
        public User GetSessionUser()
        {
            return this.SessionUser;
        }
    }
}