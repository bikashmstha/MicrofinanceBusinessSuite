using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class SupplierController : ControllerBase
    {
        private static ISupplierDao supplierDao = DataAccess.SupplierDao;



        public object SaveSupplier(Supplier supplier)
        {
            return supplierDao.SaveSupplier(supplier);
        }
        public object SearchSupplier(Supplier supplier)
        {
            return supplierDao.SearchSupplier(supplier);
        }

        public object GetSupplier(string SupplierDesc)
        {
            return supplierDao.GetSupplier(SupplierDesc);
        }

    }
}