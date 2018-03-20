using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAccountDetailDao
    {


        object SavePublicAccountDetail(PublicAccountDetail publicAccountDetail);

        object SearchPublicAccountDetail(PublicAccountDetail publicAccountDetail);



        object GetPubAccDetail(string OfficeCode, string ClientNo, string SavingAccountNo, string ClientName, string ProductClass, string FromDate, string ToDate);

    }
}
