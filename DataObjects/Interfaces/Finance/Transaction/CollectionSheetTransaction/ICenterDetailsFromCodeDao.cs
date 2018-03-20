using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ICenterDetailsFromCodeDao
    {
        object Get();

        object Save(CenterDetailsFromCode centerDetailsFromCode);

        object Search(CenterDetailsFromCode centerDetailsFromCode);
        
        object GetCenterDetailsFromCode(string centerCode);

    }
}
