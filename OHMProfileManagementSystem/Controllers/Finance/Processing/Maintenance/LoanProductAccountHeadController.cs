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
    public class LoanProductAccountHeadController : ControllerBase
    {
        private static ILoanProductAccountHeadDao loanProductAccountHeadDao = DataAccess.LoanProductAccountHeadDao;



        public object SaveLoanProductAccountHead(LoanProductAccountHead loanProductAccountHead)
        {
            return loanProductAccountHeadDao.SaveLoanProductAccountHead(loanProductAccountHead);
        }
        public object SearchLoanProductAccountHead(LoanProductAccountHead loanProductAccountHead)
        {
            return loanProductAccountHeadDao.SearchLoanProductAccountHead(loanProductAccountHead);
        }

        public object GetLoanProAccHead(string AccountDesc)
        {
            return loanProductAccountHeadDao.GetLoanProAccHead(AccountDesc);
        }

    }
}