using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanPurposeProductDetailDao
    {
        object Get();

        object Save(LoanPurposeProductDetail LoanPurposeProductDetail);

        object Search(LoanPurposeProductDetail LoanPurposeProductDetail);

    }
}
