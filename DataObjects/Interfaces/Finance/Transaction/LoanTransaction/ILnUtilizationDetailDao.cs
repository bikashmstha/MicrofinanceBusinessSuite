using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILnUtilizationDetailDao
    {
        object Get();

        object Save(LnUtilizationDetail lnUtilizationDetail);

        object Search(LnUtilizationDetail lnUtilizationDetail);



        object GetLnUtilizationDetail(string CenterCode);

    }
}
