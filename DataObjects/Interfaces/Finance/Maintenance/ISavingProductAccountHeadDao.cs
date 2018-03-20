using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingProductAccountHeadDao
    {


        object SaveSavingProductAccountHead(SavingProductAccountHead savingProductAccountHead);

        object SearchSavingProductAccountHead(SavingProductAccountHead savingProductAccountHead);



        object GetSavingProAccHead(string AccountDesc);

    }
}
