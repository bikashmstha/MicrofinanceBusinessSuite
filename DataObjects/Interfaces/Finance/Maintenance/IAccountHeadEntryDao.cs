using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface IAccountHeadEntryDao
    {
        List<AccountHeadEntry> SearchAccountHead(AccountHeadEntry accountHead);
        List<AccountHeadEntry> GetSearchAccountHead(string accountNo, string accountNameDesc, string groupNo);
        OutMessage SaveAccountHeadEntry(AccountHeadEntry accountHeadEntry);
        List<AccountHeadEntry> GetAccountHeadShort(AccountHeadEntry accountHead);

        object GetContraAccount(string offCode, string accountDesc);
    }
}
