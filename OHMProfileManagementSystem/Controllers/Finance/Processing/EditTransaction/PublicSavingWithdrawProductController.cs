using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PublicSavingWithdrawProductController : ControllerBase
    {
        private static IPublicSavingWithdrawProductDao publicSavingWithdrawProductDao = DataAccess.PublicSavingWithdrawProductDao;



        public object SavePublicSavingWithdrawProduct(PublicSavingWithdrawProduct publicSavingWithdrawProduct)
        {
            return publicSavingWithdrawProductDao.SavePublicSavingWithdrawProduct(publicSavingWithdrawProduct);
        }
        public object SearchPublicSavingWithdrawProduct(PublicSavingWithdrawProduct publicSavingWithdrawProduct)
        {
            return publicSavingWithdrawProductDao.SearchPublicSavingWithdrawProduct(publicSavingWithdrawProduct);
        }

        public object GetPubSavWithProd(string ProductName)
        {
            return publicSavingWithdrawProductDao.GetPubSavWithProd(ProductName);
        }

    }
}