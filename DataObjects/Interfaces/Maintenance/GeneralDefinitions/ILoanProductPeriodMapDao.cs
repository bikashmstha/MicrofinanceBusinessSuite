using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;

namespace DataObjects.Interfaces.Maintenance
{
    public interface ILoanProductPeriodMapDao
    {
        List<LoanProductPeriodMap> GetLoanProductPeriodMap(string loanProductCode);
        OutMessage SaveLoanProductPeriodMap(LoanProductPeriodMap loanProductPeriodMap);
    }
}
