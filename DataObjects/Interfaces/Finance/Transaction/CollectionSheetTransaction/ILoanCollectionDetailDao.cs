using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanCollectionDetailDao
    {
        object Get();

        object Save(LoanCollectionDetail loanCollectionDetail);

        object Search(LoanCollectionDetail loanCollectionDetail);

        object GetCollectionLoanDetail(string centerCode, string collectionSheetNo);

        object DeleteLoanCollectionSheet(string collectionSheetNo, string user);

        object UpdateLoanCollectionSheet(LoanCollectionDetail loanCollectionDetail);



    }
}
