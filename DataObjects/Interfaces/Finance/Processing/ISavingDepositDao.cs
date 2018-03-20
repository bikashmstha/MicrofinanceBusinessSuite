using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingDepositDao
    {


        object SaveSavingDeposit(SavingDeposit savingDeposit);

        object SearchSavingDeposit(SavingDeposit savingDeposit);



        object GetSavingDeposit(string OfficeCode, string UserCode);

    }
}
