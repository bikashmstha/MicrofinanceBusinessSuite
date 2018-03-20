using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPubSavingDepositDetailDao
    {


        object SavePubSavingDepositDetail(PubSavingDepositDetail pubSavingDepositDetail);

        object SearchPubSavingDepositDetail(PubSavingDepositDetail pubSavingDepositDetail);



        object GetPubSavDepoDetail(string OfficeCode, long? DepositNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate);

    }
}
