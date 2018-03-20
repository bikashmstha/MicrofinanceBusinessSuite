using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanDeductionDetailDao
    {


        object SaveLoanDeductionDetail(LoanDeductionDetail loanDeductionDetail);

        object SearchLoanDeductionDetail(LoanDeductionDetail loanDeductionDetail);



        object GetLoanDeductionDtl(string LoanProductCode);

    }
}
