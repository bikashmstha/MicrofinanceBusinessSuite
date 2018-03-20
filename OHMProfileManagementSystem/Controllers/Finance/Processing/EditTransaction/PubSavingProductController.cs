using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PubSavingProductController : ControllerBase
    {
        private static IPubSavingProductDao pubSavingProductDao = DataAccess.PubSavingProductDao;



        public object SavePubSavingProduct(PubSavingProduct pubSavingProduct)
        {
            return pubSavingProductDao.SavePubSavingProduct(pubSavingProduct);
        }
        public object SearchPubSavingProduct(PubSavingProduct pubSavingProduct)
        {
            return pubSavingProductDao.SearchPubSavingProduct(pubSavingProduct);
        }

        public object GetPubSavingProd(string ProductName)
        {
            return pubSavingProductDao.GetPubSavingProd(ProductName);
        }

    }
}