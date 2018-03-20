using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class SavingAccountClosureController : ControllerBase
    {
        private static ISavingAccountClosureDao savingAccountClosureDao = DataAccess.SavingAccountClosureDao;

        public object Get()
        {
            return savingAccountClosureDao.Get();
        }

        public object Save(SavingAccountClosure savingAccountClosure)
        {
            return savingAccountClosureDao.Save(savingAccountClosure);
        }
        public object Search(SavingAccountClosure savingAccountClosure)
        {
            return savingAccountClosureDao.Search(savingAccountClosure);
        }
    }
}