using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction
{

    public class CenterDetailsFromCodeController : ControllerBase
    {
        private static ICenterDetailsFromCodeDao centerDetailsFromCodeDao = DataAccess.CenterDetailsFromCodeDao;

        public object Get()
        {
            return centerDetailsFromCodeDao.Get();
        }

        public object Save(CenterDetailsFromCode centerDetailsFromCode)
        {
            return centerDetailsFromCodeDao.Save(centerDetailsFromCode);
        }
        public object Search(CenterDetailsFromCode centerDetailsFromCode)
        {
            return centerDetailsFromCodeDao.Search(centerDetailsFromCode);
        }
        public object GetCenterDetailsFromCode(string centerCode)
        {
            return centerDetailsFromCodeDao.GetCenterDetailsFromCode(centerCode);
        }
    }
}