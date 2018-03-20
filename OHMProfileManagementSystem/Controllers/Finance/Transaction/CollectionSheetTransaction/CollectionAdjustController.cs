using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class CollectionAdjustController : ControllerBase
    {
        private static ICollectionAdjustDao collectionAdjustDao = DataAccess.CollectionAdjustDao;

        public object Get()
        {
            return collectionAdjustDao.Get();
        }

        public object Save(CollectionAdjust collectionAdjust)
        {
            return collectionAdjustDao.Save(collectionAdjust);
        }
        public object Search(CollectionAdjust collectionAdjust)
        {
            return collectionAdjustDao.Search(collectionAdjust);
        }

        public object GetCollectionAdjust(string clientCode)
        {
            return collectionAdjustDao.GetCollectionAdjust(clientCode);
        }
    }
}