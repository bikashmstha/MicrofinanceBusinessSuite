using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class UnapprovedCollectionController : ControllerBase
    {
        private static IUnapprovedCollectionDao unapprovedCollectionDao = DataAccess.UnapprovedCollectionDao;



        public object SaveUnapprovedCollection(UnapprovedCollection unapprovedCollection)
        {
            return unapprovedCollectionDao.SaveUnapprovedCollection(unapprovedCollection);
        }
        public object SearchUnapprovedCollection(UnapprovedCollection unapprovedCollection)
        {
            return unapprovedCollectionDao.SearchUnapprovedCollection(unapprovedCollection);
        }

        public object GetGetUnapprovedColl(string OfficeCode)
        {
            return unapprovedCollectionDao.GetGetUnapprovedColl(OfficeCode);
        }

    }
}