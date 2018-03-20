using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Maintenance;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance.AccountControl
{
    public class AccountCategoryController:ControllerBase
    {
        private static IAccountCategoryDao accountCategoryDao = DataAccess.AccountCategoryDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AccountCategory> GetAccountCategory()
        {
            List<AccountCategory> response;
            try
            {
                response = accountCategoryDao.GetAccountCategory();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveAccountCategory(AccountCategory accountCategory)
        {
            OutMessage response;
            try
            {
                response = accountCategoryDao.SaveAccountCategory(accountCategory);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}