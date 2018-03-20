using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class CollectionSheetMasterController:ControllerBase
    {
        private static ICollectionSheetMasterDao collectionSheetMasterDao = DataAccess.CollectionSheetMasterDao;
        public object UnenterCollectionSheetMaster(string offCode, string collectionSheetNo, string username)
        {
            return collectionSheetMasterDao.UnenterCollectionSheetMaster(offCode,collectionSheetNo,username);
        }
    }
}