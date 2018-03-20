using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;
namespace DataObjects.Interfaces.Finance
{
    public interface IMemberAccountOpenDao
    {
        object Get();

        object Save(MemberAccountOpen memberAccountOpen);

        object Search(MemberAccountOpen memberAccountOpen);

        object GetMemberAccount(string offCode, string memberName);

    }
}
