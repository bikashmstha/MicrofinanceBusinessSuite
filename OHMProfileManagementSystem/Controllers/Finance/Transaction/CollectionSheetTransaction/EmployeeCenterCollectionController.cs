using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{
    public class EmployeeCenterCollectionController : ControllerBase
    {
        private static IEmployeeCenterCollectionDao employeeCenterCollectionDao = DataAccess.EmployeeCenterCollectionDao;

        public object Get()
        {
            return employeeCenterCollectionDao.Get();
        }

        public object Save(EmployeeCenterCollection employeeCenterCollection)
        {
            return employeeCenterCollectionDao.Save(employeeCenterCollection);
        }
        public object Search(EmployeeCenterCollection employeeCenterCollection)
        {
            return employeeCenterCollectionDao.Search(employeeCenterCollection);
        }

        public object RegenerateCollectionList(string offCode)
        {
            return employeeCenterCollectionDao.RegenerateCollectionList(offCode);
        }

        public object DeleteCollectionSheetMaster(string collectionSheetNo)
        {
            return employeeCenterCollectionDao.DeleteCollectionSheetMaster(collectionSheetNo);
        }

        public object DeleteCollectionSheetMaster(List<string> collectionSheetNos)
        {
            return employeeCenterCollectionDao.DeleteCollectionSheetMaster(collectionSheetNos);
        }
    }
}