using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IQueryOnSavingAccountCloseDao
    {


        object GetQueryOnSavingAcClose(string AccountNo, string SavingProductCode, string WithdrawDate, string Username);

    }
}
