using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class SavingCollectionSheetController : ControllerBase
    {
        private static ISavingCollectionSheetDao savingCollectionSheetDao = DataAccess.SavingCollectionSheetDao;

        public object Get()
        {
            return savingCollectionSheetDao.Get();
        }

        public object Save(SavingCollectionSheet savingCollectionSheet)
        {
            return savingCollectionSheetDao.Save(savingCollectionSheet);
        }
        public object Search(SavingCollectionSheet savingCollectionSheet)
        {
            return savingCollectionSheetDao.Search(savingCollectionSheet);
        }
        public object Delete(string sheetNo, string user)
        {
            return savingCollectionSheetDao.Delete(sheetNo,user);
        }
        public object Update(string sheetNo, string dataEntered, string dataEnteredDate, string welfareFundAmount, string user)
        {
            return savingCollectionSheetDao.Update(sheetNo,dataEntered,dataEnteredDate,welfareFundAmount, user);
        }
    }
}