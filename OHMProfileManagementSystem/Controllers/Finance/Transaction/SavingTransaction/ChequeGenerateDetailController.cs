using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class ChequeGenerateDetailController : ControllerBase
    {
        private static IChequeGenerateDetailDao chequeGenerateDetailDao = DataAccess.ChequeGenerateDetailDao;

        public object Get()
        {
            return chequeGenerateDetailDao.Get();
        }

        public object Save(ChequeGenerateDetail chequeGenerateDetail)
        {
            return chequeGenerateDetailDao.Save(chequeGenerateDetail);
        }
        public object Search(ChequeGenerateDetail chequeGenerateDetail)
        {
            return chequeGenerateDetailDao.Search(chequeGenerateDetail);
        }
        public object GetChequeGenerateDetail(string offCode, string accountNo)
        {
            return chequeGenerateDetailDao.GetChequeGenerateDetail(offCode,accountNo);
        }
    }
}