using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PublicSavingWithdrawController : ControllerBase
    {
        private static IPublicSavingWithdrawDao publicSavingWithdrawDao = DataAccess.PublicSavingWithdrawDao;



        public object SavePublicSavingWithdraw(PublicSavingWithdraw publicSavingWithdraw)
        {
            return publicSavingWithdrawDao.SavePublicSavingWithdraw(publicSavingWithdraw);
        }
        public object SearchPublicSavingWithdraw(PublicSavingWithdraw publicSavingWithdraw)
        {
            return publicSavingWithdrawDao.SearchPublicSavingWithdraw(publicSavingWithdraw);
        }


    }
}