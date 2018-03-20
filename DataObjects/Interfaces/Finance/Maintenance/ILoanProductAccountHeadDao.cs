using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanProductAccountHeadDao
    {


        object SaveLoanProductAccountHead(LoanProductAccountHead loanProductAccountHead);

        object SearchLoanProductAccountHead(LoanProductAccountHead loanProductAccountHead);



        object GetLoanProAccHead(string AccountDesc);

    }
}
