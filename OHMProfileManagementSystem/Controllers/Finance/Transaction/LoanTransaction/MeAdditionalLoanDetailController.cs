using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeAdditionalLoanDetailController : ControllerBase
    {
        private static IMeAdditionalLoanDetailDao meAdditionalLoanDetailDao = DataAccess.MeAdditionalLoanDetailDao;

        public object Get()
        {
            return meAdditionalLoanDetailDao.Get();
        }

        public object Save(MeAdditionalLoanDetail meAdditionalLoanDetail)
        {
            return meAdditionalLoanDetailDao.Save(meAdditionalLoanDetail);
        }
        public object Search(MeAdditionalLoanDetail meAdditionalLoanDetail)
        {
            return meAdditionalLoanDetailDao.Search(meAdditionalLoanDetail);
        }
        public object GetMeAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {
            return meAdditionalLoanDetailDao.GetMeAdditionalLoanDetail(offCode,clientName,loanNo,dateFrom,dateTo);
        }
    }
}