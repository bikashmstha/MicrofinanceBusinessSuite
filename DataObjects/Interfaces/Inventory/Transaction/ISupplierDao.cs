using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface ISupplierDao
    {


        object SaveSupplier(Supplier supplier);

        object SearchSupplier(Supplier supplier);



        object GetSupplier(string SupplierDesc);

    }
}
