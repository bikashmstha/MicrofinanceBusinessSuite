using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class SectorController : ControllerBase
    {
        private static ISectorDao sectorDao = DataAccess.SectorDao;

        public object Get()
        {
            return sectorDao.Get();
        }

        public object Save(Sector sector)
        {
            return sectorDao.Save(sector);
        }
        public object Search(Sector sector)
        {
            return sectorDao.Search(sector);
        }
    }
}