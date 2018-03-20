using BusinessObjects;
using BusinessObjects.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanSectorDao
    {
        List<LoanSector> GetLoanSector();
        OutMessage SaveLoanSector(LoanSector loanSector);
    }
}
