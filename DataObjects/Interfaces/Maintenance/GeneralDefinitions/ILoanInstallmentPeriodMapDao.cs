using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;

namespace DataObjects.Interfaces.Maintenance
{
    public interface ILoanInstallmentPeriodMapDao
    {
        List<LoanInstallmentPeriodMap> GetLoanInstallmentPeriodMap();
        OutMessage SaveLoanInstallmentPeriodMap(LoanInstallmentPeriodMap loanInstallmentPeriodMap);
    }
}
