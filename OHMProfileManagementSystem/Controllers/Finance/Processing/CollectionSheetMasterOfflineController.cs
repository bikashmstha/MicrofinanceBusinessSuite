using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class CollectionSheetMasterOfflineController : ControllerBase
    {
        private static ICollectionSheetMasterOfflineDao collectionSheetMasterOfflineDao = DataAccess.CollectionSheetMasterOfflineDao;



        public object SaveCollectionSheetMasterOffline(CollectionSheetMasterOffline collectionSheetMasterOffline)
        {
            return collectionSheetMasterOfflineDao.SaveCollectionSheetMasterOffline(collectionSheetMasterOffline);
        }
        public object SearchCollectionSheetMasterOffline(CollectionSheetMasterOffline collectionSheetMasterOffline)
        {
            return collectionSheetMasterOfflineDao.SearchCollectionSheetMasterOffline(collectionSheetMasterOffline);
        }

        public object GetCollectionSheetMstOffline(string OfficeCode, string Date)
        {
            return collectionSheetMasterOfflineDao.GetCollectionSheetMstOffline(OfficeCode, Date);
        }

    }
}