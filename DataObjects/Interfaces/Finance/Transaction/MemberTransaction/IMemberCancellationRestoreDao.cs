using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberCancellationRestoreDao
    {
        object Get();

        object Save(MemberCancellationRestore membercancellationrestore);

        object Search(MemberCancellationRestore membercancellationrestore);

    }
}
