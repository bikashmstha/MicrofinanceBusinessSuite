using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ICollectionOfflineDateDao
    {


        object SaveCollectionOfflineDate(CollectionOfflineDate collectionOfflineDate);

        object SearchCollectionOfflineDate(CollectionOfflineDate collectionOfflineDate);



        object GetCollectionOfflineDate(string OfficeCode);

    }
}
