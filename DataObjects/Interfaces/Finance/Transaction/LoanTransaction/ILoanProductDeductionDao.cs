using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using Oracle.DataAccess.Client;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanProductDeductionDao
    {


        object SaveLoanProductDeduction(List<LoanProductDeduction> loanProductDeductions, OracleTransaction tran);

        object SearchLoanProductDeduction(LoanProductDeduction loanProductDeduction);



    }
}
