using BusinessObjects;
using BusinessObjects.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanSubSectorDao
    {
        List<LoanSubSector> GetLoanSubSector();
        OutMessage SaveLoanSubSector(LoanSubSector loanSubSector);
    }
}
