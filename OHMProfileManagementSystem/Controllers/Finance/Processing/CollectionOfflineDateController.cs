using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class CollectionOfflineDateController : ControllerBase
    {
        private static ICollectionOfflineDateDao collectionOfflineDateDao = DataAccess.CollectionOfflineDateDao;



        public object SaveCollectionOfflineDate(CollectionOfflineDate collectionOfflineDate)
        {
            return collectionOfflineDateDao.SaveCollectionOfflineDate(collectionOfflineDate);
        }
        public object SearchCollectionOfflineDate(CollectionOfflineDate collectionOfflineDate)
        {
            return collectionOfflineDateDao.SearchCollectionOfflineDate(collectionOfflineDate);
        }

        public object GetCollectionOfflineDate(string OfficeCode)
        {
            return collectionOfflineDateDao.GetCollectionOfflineDate(OfficeCode);
        }

    }
}