using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IOsItemDao
    {


        object SaveOsItem(OsItem osItem);

        object SearchOsItem(OsItem osItem);



        object GetOsItem(string ItemDesc);

    }
}
