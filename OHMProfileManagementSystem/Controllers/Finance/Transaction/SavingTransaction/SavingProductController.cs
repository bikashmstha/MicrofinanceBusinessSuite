using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class SavingProductController
    {
        private static ISavingProductDao savingProductDao = DataAccess.SavingProductDao;

        public object SaveSavingProduct(SavingProductForSave savingProduct)
        {
            return savingProductDao.SaveSavingProduct(savingProduct);
        }
        public object GetProductAccOpen(string productName)
        {
            return savingProductDao.GetProductAccOpen(productName);
        }

        public object GetSavingProduct(string productName)
        {
            return savingProductDao.GetSavingProduct(productName);
        }

        public object GetSavingProductList(string ProductName)
        {
            return savingProductDao.GetSavingProductList(ProductName);
        }
    }
}