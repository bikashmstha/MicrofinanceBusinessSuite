using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicChequeNoController : ControllerBase
    {
        private static IPublicChequeNoDao publicChequeNoDao = DataAccess.PublicChequeNoDao;



        public object SavePublicChequeNo(PublicChequeNo publicChequeNo)
        {
            return publicChequeNoDao.SavePublicChequeNo(publicChequeNo);
        }
        public object SearchPublicChequeNo(PublicChequeNo publicChequeNo)
        {
            return publicChequeNoDao.SearchPublicChequeNo(publicChequeNo);
        }

        public object GetPubChequeNo(string OfficeCode, string AccountNo)
        {
            return publicChequeNoDao.GetPubChequeNo(OfficeCode, AccountNo);
        }

    }
}