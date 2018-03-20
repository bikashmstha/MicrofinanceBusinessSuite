using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;
namespace DataObjects.Interfaces.Finance
{
    public interface IProductForAccountCloseDao
    {
        object Get();

        object Save(ProductForAccountClose productForAccountClose);

        object Search(ProductForAccountClose productForAccountClose);

        object GetProductForAccountClose(string productName);

    }
}
