using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class DepreciationController : ControllerBase
    {
        private static IDepreciationDao depreciationDao = DataAccess.DepreciationDao;

        

        public object GetCalculateDepreciation(string User, string DeprToDate, string AssetCode)
        {
            return depreciationDao.GetCalculateDepreciation(User, DeprToDate, AssetCode);
        }
        public object GetInvTransactionCalculateDepreciation(string User, string DeprToDate, string AssetCode)
        {
            return depreciationDao.GetCalculateDepreciation(User, DeprToDate, AssetCode);
        }

    }
}