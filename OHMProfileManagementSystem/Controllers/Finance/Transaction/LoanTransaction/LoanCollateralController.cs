using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanCollateralController : ControllerBase
    {
        private static ILoanCollateralDao loanCollateralDao = DataAccess.LoanCollateralDao;

        
        public object SaveLoanCollateral(LoanCollateral loanCollateral)
        {
            return loanCollateralDao.SaveLoanCollateral(loanCollateral);
        }
        public object Search(LoanCollateral loanCollateral)
        {
            return loanCollateralDao.Search(loanCollateral);
        }
        public object GetLoanCollateral(string loanNo)
        {
            return loanCollateralDao.GetLoanCollateral(loanNo);
        }
    }
}