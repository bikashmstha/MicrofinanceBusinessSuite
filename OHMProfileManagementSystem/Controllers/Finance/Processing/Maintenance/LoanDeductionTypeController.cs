using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class LoanDeductionTypeController : ControllerBase
    {
        private static ILoanDeductionTypeDao loanDeductionTypeDao = DataAccess.LoanDeductionTypeDao;

        public object Get()
        {
            return loanDeductionTypeDao.Get();
        }

        public object Save(LoanDeductionType loanDeductionType)
        {
            return loanDeductionTypeDao.Save(loanDeductionType);
        }
        public object Search(LoanDeductionType loanDeductionType)
        {
            return loanDeductionTypeDao.Search(loanDeductionType);
        }
        public object GetLoanDeduction(string LoanDeductionDesc)
        {
            return loanDeductionTypeDao.GetLoanDeduction(LoanDeductionDesc);
        }
    }
}