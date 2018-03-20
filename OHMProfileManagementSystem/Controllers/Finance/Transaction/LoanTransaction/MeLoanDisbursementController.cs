using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeLoanDisbursementController : ControllerBase
    {
        private static IMeLoanDisbursementDao meLoanDisbursementDao = DataAccess.MeLoanDisbursementDao;

        public object Get()
        {
            return meLoanDisbursementDao.Get();
        }

        public object Save(MeLoanDisbursement meLoanDisbursement)
        {
            return meLoanDisbursementDao.Save(meLoanDisbursement);
        }
        public object Search(MeLoanDisbursement meLoanDisbursement)
        {
            return meLoanDisbursementDao.Search(meLoanDisbursement);
        }
        public object GetMeLoanMember(string offCode, string centerCode, string memberName)
        {
            return meLoanDisbursementDao.GetMeLoanMember(offCode,centerCode,memberName);
        }
    }
}