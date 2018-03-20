using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IChequePrintDao
    {
        object GetNoOfChequePrint(string offCode, string savingProductCode);

        object GetAccountChequeList(string accountNo, int? fromChequeNo, int? toChequeNo);
    }
}
