using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class SavingDepositController : ControllerBase
    {
        private static ISavingDepositDao savingDepositDao = DataAccess.SavingDepositDao;



        public object SaveSavingDeposit(SavingDeposit savingDeposit)
        {
            return savingDepositDao.SaveSavingDeposit(savingDeposit);
        }
        public object SearchSavingDeposit(SavingDeposit savingDeposit)
        {
            return savingDepositDao.SearchSavingDeposit(savingDeposit);
        }

        public object GetSavingDeposit(string OfficeCode, string UserCode)
        {
            return savingDepositDao.GetSavingDeposit(OfficeCode, UserCode);
        }

    }
}