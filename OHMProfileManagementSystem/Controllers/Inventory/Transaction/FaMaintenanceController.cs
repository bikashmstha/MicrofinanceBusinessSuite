using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;
namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class FaMaintenanceController : ControllerBase
    {
        private static IFaMaintenanceDao famaintenanceDao = DataAccess.FaMaintenanceDao;



        public object SaveFaMaintenance(FaMaintenance famaintenance)
        {
            return famaintenanceDao.SaveFaMaintenance(famaintenance);
        }
        public object SearchFaMaintenance(FaMaintenance famaintenance)
        {
            return famaintenanceDao.SearchFaMaintenance(famaintenance);
        }
    }
}