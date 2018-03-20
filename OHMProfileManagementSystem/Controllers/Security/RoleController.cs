using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Security;


namespace MicrofinanceBusinessSuite.Controllers.Security
{
    public class RoleController : ControllerBase
    {
        private static IRoleDao roleDao = DataAccess.RoleDao;

        public object Get()
        {
            return roleDao.Get();
        }

        public object Save(Role role)
        {
            return roleDao.Save(role);
        }
        public object Search(Role role)
        {
            return roleDao.Search(role);
        }
    }
}