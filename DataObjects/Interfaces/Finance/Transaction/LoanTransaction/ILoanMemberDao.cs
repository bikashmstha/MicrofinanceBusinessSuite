using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanMemberDao
    {
        object Get();

        object Save(LoanMember loanMember);

        object Search(LoanMember loanMember);

        object GetLoanMember(string offCode, string centerCode, string memberName);

    }
}
