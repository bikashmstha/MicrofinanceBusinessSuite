using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class CompulsoryAccountsEntryController : ControllerBase
    {
        private static ICompulsoryAccountsEntryDao compulsoryAccountsEntryDao = DataAccess.CompulsoryAccountsEntryDao;

        public object Get()
        {
            return compulsoryAccountsEntryDao.Get();
        }

        public object Save(CompulsoryAccountsEntry compulsoryAccountsEntry)
        {
            return compulsoryAccountsEntryDao.Save(compulsoryAccountsEntry);
        }
        public object Search(CompulsoryAccountsEntry compulsoryAccountsEntry)
        {
            return compulsoryAccountsEntryDao.Search(compulsoryAccountsEntry);
        }
    }
}