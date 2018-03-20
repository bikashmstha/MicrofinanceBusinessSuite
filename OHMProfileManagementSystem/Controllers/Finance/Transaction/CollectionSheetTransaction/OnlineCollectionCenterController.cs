using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class OnlineCollectionCenterController : ControllerBase
    {
        private static IOnlineCollectionCenterDao onlineCollectionCenterDao = DataAccess.OnlineCollectionCenterDao;

        public object Get()
        {
            return onlineCollectionCenterDao.Get();
        }

        public object Save(OnlineCollectionCenter onlineCollectionCenter)
        {
            return onlineCollectionCenterDao.Save(onlineCollectionCenter);
        }
        public object Search(OnlineCollectionCenter onlineCollectionCenter)
        {
            return onlineCollectionCenterDao.Search(onlineCollectionCenter);
        }
        public object GetOnlineCenters(string date, string offCode, string centerName)
        {
            return onlineCollectionCenterDao.GetOnlineCenters(date,offCode,centerName);
        }
        public object GetOnlineCenterList( string offCode, string centerName)
        {
            return onlineCollectionCenterDao.GetOnlineCenterList( offCode, centerName);
        }
    }
}