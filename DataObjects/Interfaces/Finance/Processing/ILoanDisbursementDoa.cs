using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanDisbursementDao
    {


        object SaveLoanDisbursement(LoanDisbursement loanDisbursement);

        object SearchLoanDisbursement(LoanDisbursement loanDisbursement);



        object GetLoanDisbursement(string OfficeCode, string UserCode);

    }
}
