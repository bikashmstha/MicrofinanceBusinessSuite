using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class CollectionSheetPostingController : ControllerBase
    {
        private static ICollectionSheetPostingDao collectionSheetPostingDao = DataAccess.CollectionSheetPostingDao;



        public object SaveCollectionSheetPosting(CollectionSheetPosting collectionSheetPosting)
        {
            return collectionSheetPostingDao.SaveCollectionSheetPosting(collectionSheetPosting);
        }
        public object SearchCollectionSheetPosting(CollectionSheetPosting collectionSheetPosting)
        {
            return collectionSheetPostingDao.SearchCollectionSheetPosting(collectionSheetPosting);
        }
    }
}