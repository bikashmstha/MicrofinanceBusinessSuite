using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;

namespace DataObjects.Interfaces.Maintenance
{
    public interface IAccountCategoryDao
    {
        List<AccountCategory> GetAccountCategory();
        OutMessage SaveAccountCategory(AccountCategory accountCategory);
    }
}
