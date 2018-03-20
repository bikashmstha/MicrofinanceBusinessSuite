using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IFundingAgencyDao
    {
        object Get();

        object Save(FundingAgency fundingAgency);

        object Search(FundingAgency fundingAgency);

    }
}
