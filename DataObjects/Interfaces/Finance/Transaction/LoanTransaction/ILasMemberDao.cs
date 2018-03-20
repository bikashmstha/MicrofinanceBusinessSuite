using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILasMemberDao
    {
        object Get();

        object Save(LasMember lasMember);

        object Search(LasMember lasMember);

        object GetLasMember(string offCode, string clientName, string centerCode, string productCode);

    }
}
