using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IEmployeeCenterCollectionDao
    {
        object Get();

        object Save(EmployeeCenterCollection employeeCenterCollection);

        object Search(EmployeeCenterCollection employeeCenterCollection);

        object RegenerateCollectionList(string offCode);

        object DeleteCollectionSheetMaster(string collectionSheetNo);

        object DeleteCollectionSheetMaster(List<string> collectionSheetNos);

    }
}
