using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingDepositPostingDao
    {


        object SaveSavingDepositPosting(List<SavingDepositPosting> savingDepositPostings);

        object SearchSavingDepositPosting(SavingDepositPosting savingDepositPosting);
    }
}
