using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ParticularsController : ControllerBase
    {
        private static IParticularsDao particularsDao = DataAccess.ParticularsDao;



        public object SaveParticulars(Particulars particulars)
        {
            return particularsDao.SaveParticulars(particulars);
        }
        public object SearchParticulars(Particulars particulars)
        {
            return particularsDao.SearchParticulars(particulars);
        }

        public object GetParticulars(string ParticularsDesc)
        {
            return particularsDao.GetParticulars(ParticularsDesc);
        }

    }
}