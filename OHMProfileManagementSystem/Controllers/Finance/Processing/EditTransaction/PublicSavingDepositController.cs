using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PublicSavingDepositController : ControllerBase
    {
        private static IPublicSavingDepositDao publicSavingDepositDao = DataAccess.PublicSavingDepositDao;



        public object SavePublicSavingDeposit(PublicSavingDeposit publicSavingDeposit)
        {
            return publicSavingDepositDao.SavePublicSavingDeposit(publicSavingDeposit);
        }
        public object SearchPublicSavingDeposit(PublicSavingDeposit publicSavingDeposit)
        {
            return publicSavingDepositDao.SearchPublicSavingDeposit(publicSavingDeposit);
        }


    }
}