using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class UserOfficeController : ControllerBase
    {
        private static IUserOfficeDao userOfficeDao = DataAccess.UserOfficeDao;



        public object SaveUserOffice(UserOffice userOffice)
        {
            return userOfficeDao.SaveUserOffice(userOffice);
        }
        public object SearchUserOffice(UserOffice userOffice)
        {
            return userOfficeDao.SearchUserOffice(userOffice);
        }

        public object GetUserOffice(string UserCode, string OfficeName)
        {
            return userOfficeDao.GetUserOffice(UserCode, OfficeName);
        }

    }
}