using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountCloseProductController : ControllerBase
    {
        private static IPublicAccountCloseProductDao publicAccountCloseProductDao = DataAccess.PublicAccountCloseProductDao;



        public object SavePublicAccountCloseProduct(PublicAccountCloseProduct publicAccountCloseProduct)
        {
            return publicAccountCloseProductDao.SavePublicAccountCloseProduct(publicAccountCloseProduct);
        }
        public object SearchPublicAccountCloseProduct(PublicAccountCloseProduct publicAccountCloseProduct)
        {
            return publicAccountCloseProductDao.SearchPublicAccountCloseProduct(publicAccountCloseProduct);
        }

        public object GetPubAccCloseProd(string ProductName)
        {
            return publicAccountCloseProductDao.GetPubAccCloseProd(ProductName);
        }

    }
}