using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanMemberController : ControllerBase
    {
        private static ILoanMemberDao loanMemberDao = DataAccess.LoanMemberDao;

        public object Get()
        {
            return loanMemberDao.Get();
        }

        public object Save(LoanMember loanMember)
        {
            return loanMemberDao.Save(loanMember);
        }
        public object Search(LoanMember loanMember)
        {
            return loanMemberDao.Search(loanMember);
        }

        public object GetLoanMember(string offCode, string centerCode, string memberName)
        {
            return loanMemberDao.GetLoanMember(offCode, centerCode,memberName);
        }
    }
}