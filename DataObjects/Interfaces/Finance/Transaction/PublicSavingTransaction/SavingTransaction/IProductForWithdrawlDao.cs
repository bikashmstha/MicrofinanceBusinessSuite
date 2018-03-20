using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IProductForWithdrawlDao
    {
        object Get();

        object Save(ProductForWithdrawl productForWithdrawl);

        object Search(ProductForWithdrawl productForWithdrawl);

        object GetProductForWithDrawl(string productName);

    }
}
