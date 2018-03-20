using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberForChequeDao
    {
        object Get();

        object Save(MemberForCheque memberForCheque);

        object Search(MemberForCheque memberForCheque);

        object GetMemberForCheque(String offCode, string centerCode, string memberName);

    }
}
