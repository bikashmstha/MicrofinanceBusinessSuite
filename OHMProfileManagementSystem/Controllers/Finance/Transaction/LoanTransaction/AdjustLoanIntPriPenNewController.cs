using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class AdjustLoanIntPriPenNewController : ControllerBase
    {
        private static IAdjustLoanIntPriPenNewDao adjustLoanIntPriPenNewDao = DataAccess.AdjustLoanIntPriPenNewDao;

        public object Get()
        {
            return adjustLoanIntPriPenNewDao.Get();
        }

        public object Save(AdjustLoanIntPriPenNew adjustLoanIntPriPenNew)
        {
            return adjustLoanIntPriPenNewDao.Save(adjustLoanIntPriPenNew);
        }
        public object Search(AdjustLoanIntPriPenNew adjustLoanIntPriPenNew)
        {
            return adjustLoanIntPriPenNewDao.Search(adjustLoanIntPriPenNew);
        }
    }
}