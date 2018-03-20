using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeAdditionalLoanDisbursementController : ControllerBase
    {
        private static IMeAdditionalLoanDisbursementDao meAdditionalLoanDisbursementDao = DataAccess.MeAdditionalLoanDisbursementDao;

        public object Get()
        {
            return meAdditionalLoanDisbursementDao.Get();
        }

        public object Save(MeAdditionalLoanDisbursement meAdditionalLoanDisbursement)
        {
            return meAdditionalLoanDisbursementDao.Save(meAdditionalLoanDisbursement);
        }
        public object Search(MeAdditionalLoanDisbursement meAdditionalLoanDisbursement)
        {
            return meAdditionalLoanDisbursementDao.Search(meAdditionalLoanDisbursement);
        }
    }
}