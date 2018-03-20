using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;
namespace DataObjects.Interfaces.Finance
{
    public interface IAccountCloseDetailDao
    {
        object Get();

        object Save(AccountCloseDetail accountCloseDetail);

        object Search(AccountCloseDetail accountCloseDetail);

        object GetAccountCloseDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate);

    }
}
