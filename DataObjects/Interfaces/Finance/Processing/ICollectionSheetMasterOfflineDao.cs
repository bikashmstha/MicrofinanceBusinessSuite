using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ICollectionSheetMasterOfflineDao
    {


        object SaveCollectionSheetMasterOffline(CollectionSheetMasterOffline collectionSheetMasterOffline);

        object SearchCollectionSheetMasterOffline(CollectionSheetMasterOffline collectionSheetMasterOffline);



        object GetCollectionSheetMstOffline(string OfficeCode, string Date);

    }
}
