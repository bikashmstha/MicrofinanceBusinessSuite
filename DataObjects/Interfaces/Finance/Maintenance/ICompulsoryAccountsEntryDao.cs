using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ICompulsoryAccountsEntryDao
    {
        object Get();

        object Save(CompulsoryAccountsEntry CompulsoryAccountsEntry);

        object Search(CompulsoryAccountsEntry CompulsoryAccountsEntry);

    }
}
