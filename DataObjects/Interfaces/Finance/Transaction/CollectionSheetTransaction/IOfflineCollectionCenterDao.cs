using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IOfflineCollectionCenterDao
    {
        object Get();

        object Save(OfflineCollectionCenter offlineCollectionCenter);

        object Search(OfflineCollectionCenter offlineCollectionCenter);

        object GetOfflineCollectionCenter(string offCode, string centerName);

        object GetOfflineCollectionCenterByDate(string date, string offCode, string centerName);

    }
}
