using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingTypeDao
    {


        object SaveSavingType(SavingType savingType);

        object SearchSavingType(SavingType savingType);



        object GetSavingType(string SavingProductType);

    }
}
