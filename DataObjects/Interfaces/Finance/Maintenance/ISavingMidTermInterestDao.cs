using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingMidTermInterestDao
    {
        List<SavingMidTermInterest> GetSavingMidTermInterest();
        OutMessage SaveSavingMidTermInterest(SavingMidTermInterest savingMidTermInterest);
    }
}
