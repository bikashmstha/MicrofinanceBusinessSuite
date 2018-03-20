using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class OsItemController : ControllerBase
    {
        private static IOsItemDao osItemDao = DataAccess.OsItemDao;



        public object SaveOsItem(OsItem osItem)
        {
            return osItemDao.SaveOsItem(osItem);
        }
        public object SearchOsItem(OsItem osItem)
        {
            return osItemDao.SearchOsItem(osItem);
        }

        public object GetOsItem(string ItemDesc)
        {
            return osItemDao.GetOsItem(ItemDesc);
        }

    }
}