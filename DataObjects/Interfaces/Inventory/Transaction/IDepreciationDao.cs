using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IDepreciationDao
    {
        
        object GetCalculateDepreciation(string User, string DeprToDate, string AssetCode);
        object GetInvTransactionCalculateDepreciation(string User, string DeprToDate, string AssetCode);

    }
}
