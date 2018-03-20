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
    public class AccountSubCategoryController:ControllerBase
    {
        private static IAccountSubCategoryDao accountSubCategoryDao = DataAccess.AccountSubCategoryDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AccountSubCategory> GetAccountSubCategory()
        {
            List<AccountSubCategory> response;
            try
            {
                response = accountSubCategoryDao.GetAccountSubCategory();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveAccountSubCategory(AccountSubCategory accountSubCategory)
        {
            OutMessage response;
            try
            {
                response = accountSubCategoryDao.SaveAccountSubCategory(accountSubCategory);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}