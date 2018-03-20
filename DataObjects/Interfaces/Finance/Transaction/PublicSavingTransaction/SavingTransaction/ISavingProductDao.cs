using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Maintenance;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingProductDao
    {
        object Get();

        object SaveSavingProduct(SavingProductForSave savingProduct);

        object Search(SavingProduct savingProduct);

        object GetProductAccOpen(string productName);

        object GetSavingProduct(string ProductName);

        object GetSavingProductList(string ProductName);
    }
}
