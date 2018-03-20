using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicClientDetailDao
    {


        object SavePublicClientDetail(PublicClientDetail publicClientDetail);

        object SearchPublicClientDetail(PublicClientDetail publicClientDetail);

        object GetPubClientDetail(string OfficeCode, string MemberCode, string MemberName, string MemDateFrom, string MemDateTo);

    }
}
