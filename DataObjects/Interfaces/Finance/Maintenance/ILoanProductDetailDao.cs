using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanProductDetailDao
    {


        object SaveLoanProductDetail(LoanProductDetail loanProductDetail);

        object SearchLoanProductDetail(LoanProductDetail loanProductDetail);



        object GetLoanProductDetailList(string LoanProductCode, string LoanType);

    }
}
