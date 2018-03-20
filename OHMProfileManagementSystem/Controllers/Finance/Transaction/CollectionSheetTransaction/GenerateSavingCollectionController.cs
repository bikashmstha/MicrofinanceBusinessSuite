using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class GenerateSavingCollectionController
    {
        private static IGenerateSavingCollectionDao generateSavingCollectionDao = DataAccess.GenerateSavingCollectionDao;

        public object GenerateSavingCollection(string offCode, string sheetNo, string centerCode, string collectionDate)
        {
            return generateSavingCollectionDao.GenerateSavingCollection(offCode, sheetNo, centerCode, collectionDate);
        }
    }
}