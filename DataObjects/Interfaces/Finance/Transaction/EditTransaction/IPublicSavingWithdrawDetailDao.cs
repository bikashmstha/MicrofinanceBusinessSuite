using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingWithdrawDetailDao
    {


        object SavePublicSavingWithdrawDetail(PublicSavingWithdrawDetail publicSavingWithdrawDetail);

        object SearchPublicSavingWithdrawDetail(PublicSavingWithdrawDetail publicSavingWithdrawDetail);



        object GetPubSavWithDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate);

    }
}
