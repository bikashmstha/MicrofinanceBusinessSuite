using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class LoanCollectionDetailController : ControllerBase
    {
        private static ILoanCollectionDetailDao loanCollectionDetailDao = DataAccess.LoanCollectionDetailDao;

        public object Get()
        {
            return loanCollectionDetailDao.Get();
        }

        public object Save(LoanCollectionDetail loanCollectionDetail)
        {
            return loanCollectionDetailDao.Save(loanCollectionDetail);
        }
        public object Search(LoanCollectionDetail loanCollectionDetail)
        {
            return loanCollectionDetailDao.Search(loanCollectionDetail);
        }

        public object GetCollectionLoanDetail(string centerCode, string collectionSheetNo)
        {
            return loanCollectionDetailDao.GetCollectionLoanDetail(centerCode,collectionSheetNo);
        }

        public object DeleteLoanCollectionSheet(string collectionSheetNo,string user)
        {
            return loanCollectionDetailDao.DeleteLoanCollectionSheet(collectionSheetNo, user);
        }

        public object UpdateLoanCollectionSheet(LoanCollectionDetail loanCollectionDetail)
        {
            return loanCollectionDetailDao.UpdateLoanCollectionSheet(loanCollectionDetail);
        }
    }
}