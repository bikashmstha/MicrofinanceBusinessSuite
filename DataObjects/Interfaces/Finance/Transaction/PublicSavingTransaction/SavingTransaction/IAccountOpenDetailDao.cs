using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAccountOpenDetailDao
    {
        object Get();

        object Save(AccountOpenDetail accountOpenDetail);

        object Search(AccountOpenDetail accountOpenDetail);

        object GetAccountOpenDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate);



    }
}
