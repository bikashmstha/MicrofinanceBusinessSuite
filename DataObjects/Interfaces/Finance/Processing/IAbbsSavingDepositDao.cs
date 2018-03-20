using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IAbbsSavingDepositDao
    {


        object SaveAbbsSavingDeposit(AbbsSavingDeposit abbsSavingDeposit);

        object SearchAbbsSavingDeposit(AbbsSavingDeposit abbsSavingDeposit);



        object GetAbbsSavingDeposit(string OfficeCode);

    }
}
