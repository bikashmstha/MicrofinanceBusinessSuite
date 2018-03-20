using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class CollectionSheetMasterOnlineController : ControllerBase
    {
        private static ICollectionSheetMasterOnlineDao collectionSheetMasterOnlineDao = DataAccess.CollectionSheetMasterOnlineDao;



        public object SaveCollectionSheetMasterOnline(CollectionSheetMasterOnline collectionSheetMasterOnline)
        {
            return collectionSheetMasterOnlineDao.SaveCollectionSheetMasterOnline(collectionSheetMasterOnline);
        }
        public object SearchCollectionSheetMasterOnline(CollectionSheetMasterOnline collectionSheetMasterOnline)
        {
            return collectionSheetMasterOnlineDao.SearchCollectionSheetMasterOnline(collectionSheetMasterOnline);
        }

        public object GetCollectionSheetMstOnline(string OfficeCode)
        {
            return collectionSheetMasterOnlineDao.GetCollectionSheetMstOnline(OfficeCode);
        }

    }
}