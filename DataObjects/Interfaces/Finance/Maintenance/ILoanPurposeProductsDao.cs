using BusinessObjects;
using BusinessObjects.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanPurposeProductsDao
    {
        List<LoanPurposeProducts> GetLoanPurposeProducts(string LoanProductCode);
        OutMessage SaveLoanPurposeProducts(LoanPurposeProducts loanPurposeProducts);
        }
}
