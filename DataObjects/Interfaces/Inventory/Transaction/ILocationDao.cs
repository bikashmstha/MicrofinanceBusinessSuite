using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface ILocationDao
    {


        object SaveLocation(Location location);

        object SearchLocation(Location location);



        object GetLocation(string OfficeCode, string LocationDesc);

    }
}
