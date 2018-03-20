using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IProductForDepositDao
    {
        object Get();

        object Save(ProductForDeposit productForDeposit);

        object Search(ProductForDeposit productForDeposit);

        object GetProductForDeposit(string productName);
    }
}
