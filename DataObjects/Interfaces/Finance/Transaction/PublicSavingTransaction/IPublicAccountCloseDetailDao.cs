using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAccountCloseDetailDao
    {


        object SavePublicAccountCloseDetail(PublicAccountCloseDetail publicAccountCloseDetail);

        object SearchPublicAccountCloseDetail(PublicAccountCloseDetail publicAccountCloseDetail);



        object GetPubAccCloseDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate);

    }
}
