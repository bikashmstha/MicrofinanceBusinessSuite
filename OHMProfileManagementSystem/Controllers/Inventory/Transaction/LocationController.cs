using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class LocationController : ControllerBase
    {
        private static ILocationDao locationDao = DataAccess.LocationDao;



        public object SaveLocation(Location location)
        {
            return locationDao.SaveLocation(location);
        }
        public object SearchLocation(Location location)
        {
            return locationDao.SearchLocation(location);
        }

        public object GetLocation(string OfficeCode, string LocationDesc)
        {
            return locationDao.GetLocation(OfficeCode, LocationDesc);
        }

    }
}