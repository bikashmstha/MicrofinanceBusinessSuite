using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class OfflineCollectionCenterController:ControllerBase
    {
        private static IOfflineCollectionCenterDao offlineCollectionCenterDao = DataAccess.OfflineCollectionCenterDao;
        public object GetOfflineCollectionCenter(string offCode, string centerName)
        {
            return offlineCollectionCenterDao.GetOfflineCollectionCenter(offCode, centerName);
        }

        public object GetOfflineCollectionCenterByDate(string date, string offCode, string centerName)
        {
            return offlineCollectionCenterDao.GetOfflineCollectionCenterByDate(date,offCode, centerName);
        }
    }
}