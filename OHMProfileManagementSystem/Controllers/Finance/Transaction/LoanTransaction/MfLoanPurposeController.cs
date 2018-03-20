using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfLoanPurposeController : ControllerBase
    {
        private static IMfLoanPurposeDao mfLoanPurposeDao = DataAccess.MfLoanPurposeDao;

        public object Get()
        {
            return mfLoanPurposeDao.Get();
        }

        public object Save(MfLoanPurpose mfLoanPurpose)
        {
            return mfLoanPurposeDao.Save(mfLoanPurpose);
        }
        public object Search(MfLoanPurpose mfLoanPurpose)
        {
            return mfLoanPurposeDao.Search(mfLoanPurpose);
        }

        public object GetLoanProduct(string productCode, string purposeName)
        {
            return mfLoanPurposeDao.GetLoanProduct(productCode, purposeName);
        }
    }
}