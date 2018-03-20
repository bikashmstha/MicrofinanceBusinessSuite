using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingAccountClosureDao
    {
        object SavePublicSavingAccountClosure(PublicSavingAccountClosure publicSavingAccountClosure);

        object DeletePublicSavingAccountClosure(string accountNo, string accountClosedDate, string otherIncomeVoucherNo, string username);

        object SearchPublicSavingAccountClosure(PublicSavingAccountClosure publicSavingAccountClosure);

    }
}
