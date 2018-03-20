using BusinessObjects;
using BusinessObjects.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanPurposeDao
    {
        List<LoanPurpose> GetLoanPurpose();
        OutMessage SaveLoanPurpose(LoanPurpose loanPurpose);

        object GetMfLoanPurpose(string productCode, string purposeName);
    }
}
