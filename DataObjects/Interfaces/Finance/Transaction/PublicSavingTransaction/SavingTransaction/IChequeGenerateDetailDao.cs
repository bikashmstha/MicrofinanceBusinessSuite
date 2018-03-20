using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IChequeGenerateDetailDao
    {
        object Get();

        object Save(ChequeGenerateDetail chequeGenerateDetail);

        object Search(ChequeGenerateDetail chequeGenerateDetail);

        object GetChequeGenerateDetail(string offCode, string accountNo);

    }
}
