using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class LoanDeductionDetailController : ControllerBase
    {
        private static ILoanDeductionDetailDao loanDeductionDetailDao = DataAccess.LoanDeductionDetailDao;



        public object SaveLoanDeductionDetail(LoanDeductionDetail loanDeductionDetail)
        {
            return loanDeductionDetailDao.SaveLoanDeductionDetail(loanDeductionDetail);
        }
        public object SearchLoanDeductionDetail(LoanDeductionDetail loanDeductionDetail)
        {
            return loanDeductionDetailDao.SearchLoanDeductionDetail(loanDeductionDetail);
        }

        public object GetLoanDeductionDtl(string LoanProductCode)
        {
            return loanDeductionDetailDao.GetLoanDeductionDtl(LoanProductCode);
        }

    }
}