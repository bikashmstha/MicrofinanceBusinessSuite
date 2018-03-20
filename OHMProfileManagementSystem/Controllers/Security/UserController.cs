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
    public class UserController : ControllerBase
    {
        private static GenericUserDao userDao = DataAccess.UserDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public object GetUserShort()
        {

            return userDao.GetUserShort();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public object ResetUserPassword(string officeCode, string userCode, string newPwd, string cNewPwd, string changeByOfficeCode, string changeByUserCode)
        {
            return userDao.ResetUserPassword(officeCode, userCode, newPwd, cNewPwd, changeByOfficeCode, changeByUserCode);
        }



        public object Get()
        {
            return userDao.Get();
        }

        public object Save(User user)
        {
            return userDao.Save(user);
        }
        public object Search(User user)
        {
            return userDao.Search(user);
        }

    }
}